#nullable disable
namespace BoardGameBrawl.Infrastructure.Services.ImageDownloader
{
    public class ImageDownloaderService : IImageDownloaderService
    {
        private readonly HttpClient _httpClient;

        public ImageDownloaderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return null;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (HttpRequestException ex)
            {
                // Log error (e.g., invalid URL, network issues)
                Console.WriteLine($"Error downloading image: {ex.Message}");
                return null;
            }
        }
    }
}
