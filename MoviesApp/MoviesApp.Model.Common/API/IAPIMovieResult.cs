namespace MoviesApp.Model.Common
{
    public interface IAPIMovieResult
    {
        int Page { get; set; }
        int TotalPages { get; set; }
        int TotalResults { get; set; }
        IEnumerable<IAPIMovie> Results { get; set; }
    }
}
