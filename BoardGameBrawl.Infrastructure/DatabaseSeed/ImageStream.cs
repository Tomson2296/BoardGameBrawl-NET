#nullable disable
namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class ImageStream : IImageStream
    {
        public async Task<byte[]> ReadImageStreamAsync(string filePath)
        {
            try
            {
                byte[] byteImage = await File.ReadAllBytesAsync(filePath, CancellationToken.None);

                return byteImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during opening of file: " + ex.Message);

                return Array.Empty<byte>();
            }
        }
    }
}
