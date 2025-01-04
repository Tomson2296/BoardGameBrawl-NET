namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public interface IImageStream
    {
        public Task<byte[]> ReadImageStreamAsync(string filePath);
    }
}
