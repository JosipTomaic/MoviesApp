namespace MoviesApp.Model.Common
{
    public interface IAPIGenreResult
    {
        IEnumerable<IAPIGenre> Genres { get; set; }
    }
}
