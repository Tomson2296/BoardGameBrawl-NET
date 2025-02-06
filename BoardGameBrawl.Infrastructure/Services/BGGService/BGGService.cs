using BoardGameBrawl.Domain.Value_objects;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Xml.Serialization;

namespace BoardGameBrawl.Infrastructure.Services.BGGService
{
    public class BGGService : IBGGService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BGGService> _logger;

        public BGGService(IHttpClientFactory httpClientFactory,
            ILogger<BGGService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<BoardgameItemResponse?> GetBGGBoardGameInfoAsync(int bggBoardgameId)
        {
            var retryCount = 0;
            const int maxRetries = 5;
            const int initialDelayMs = 1000;

            string apiUrl = $"https://boardgamegeek.com/xmlapi2/thing?type=boardgame&stats=1&id={bggBoardgameId}";

            try
            {
                using var client = _httpClientFactory.CreateClient("BoardGameGeekClient");

                while (true)
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        await using var stream = await response.Content.ReadAsStreamAsync();
                        return DeserializeBoardGame(stream);
                    }

                    if (response.StatusCode != HttpStatusCode.Accepted || retryCount >= maxRetries)
                    {
                        LogErrorResponseAsync(response);
                        return null;
                    }

                    var delay = initialDelayMs * (int)Math.Pow(2, retryCount);
                    _logger.LogWarning("Retry {RetryCount} for BGG ID {BggId}. Delaying {Delay}ms",
                        retryCount + 1, bggBoardgameId, delay);

                    await Task.Delay(delay);
                    retryCount++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        private BoardgameItemResponse? DeserializeBoardGame(Stream stream)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(BoardgameItemResponse));
                using var reader = new StreamReader(stream);
                return (BoardgameItemResponse?)serializer.Deserialize(reader);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "XML deserialization failed");
                return null;
            }
        }

        private async void LogErrorResponseAsync(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogError("BGG API Error: {StatusCode} - {Content}",
                    response.StatusCode, content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read error content");
            }
        }


        public async Task<BoardgameCollectionResponse?> GetUserBGGCollectionInfoAsync(string bggUsername)
        {
            const int maxRetries = 5;
            const int initialDelayMs = 1000;
            var retryCount = 0;
            var lowerUserName = bggUsername.ToLowerInvariant();
            var apiPath = $"collection?username={lowerUserName}&own=1&subtype=boardgame&excludesubtype=boardgameexpansion";

            try
            {
                using var client = _httpClientFactory.CreateClient("BoardGameGeekClient");

                while (true)
                {
                    var response = await client.GetAsync(apiPath);

                    if (response.IsSuccessStatusCode)
                    {
                        await using var stream = await response.Content.ReadAsStreamAsync();
                        return DeserializeBoardGameCollection(stream);
                    }

                    if (response.StatusCode != HttpStatusCode.Accepted || retryCount >= maxRetries)
                    {
                        await LogCollectionError(response, bggUsername);
                        return null;
                    }

                    var delay = initialDelayMs * (int)Math.Pow(2, retryCount);
                    _logger.LogWarning("Retrieving collection for {UserName} - Retry {RetryCount} in {Delay}ms",
                        bggUsername, retryCount + 1, delay);

                    await Task.Delay(delay);
                    retryCount++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch BGG collection for user {UserName}", bggUsername);
                return null;
            }
        }

        private BoardgameCollectionResponse? DeserializeBoardGameCollection(Stream stream)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(BoardgameCollectionResponse));
                using var reader = new StreamReader(stream);
                return (BoardgameCollectionResponse?)serializer.Deserialize(reader);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "XML deserialization failed for collection data");
                return null;
            }
        }

        private async Task LogCollectionError(HttpResponseMessage response, string userName)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogError("BGG Collection API Error for {UserName}: {StatusCode} - {Content}",
                    userName, response.StatusCode, content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read error content for user {UserName}", userName);
            }
        }
    }
}
