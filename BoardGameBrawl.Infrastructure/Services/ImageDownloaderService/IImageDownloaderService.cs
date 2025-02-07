namespace BoardGameBrawl.Infrastructure.Services.ImageDownloader
{
    public interface IImageDownloaderService
    {
        public Task<byte[]?> DownloadImageAsync(string url);
    }
}
