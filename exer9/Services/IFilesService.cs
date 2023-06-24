public interface IFilesService
{
    Task Delete(string name);
    Task Upload(string name, Stream content);
    Task<byte[]> Download(string filename);
    Uri GetDownloadLink(string filename);
}