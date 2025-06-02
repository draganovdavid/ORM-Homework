namespace Application.Interfaces
{
    public interface IMovieImporterService
    {
        Task ImportMoviesAsync(string csvFilePath);
    }
}
