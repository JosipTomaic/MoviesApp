class MoviesService {

    async getMovies(searchTerm) {
        const response = await fetch(`https://localhost:7059/api/Movies/movies${searchTerm !== '' ? `?searchTerm=${searchTerm}` : ''}`, {
            method: 'get',
            headers: {
                'Accept': 'application-json'
            }
        });

        const responseJson = await response.json();

        if (responseJson != null) {
            return responseJson.map(movie => {
                const movieMapped = {
                    tmdbId: movie.tmbdId,
                    title: movie.originalTitle,
                    releaseDate: new Date(movie.releaseDate).toLocaleDateString('en-US', { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' }),
                    genres: movie.movieGenres.map(movieGenreItem => movieGenreItem.genre.name).join(','),
                    directors: movie.crewMemberMovieCredits.filter(cmmc => cmmc.movieCredit.name === 'Director')
                        .map(cmmc => cmmc.crewMember.name).join(','),
                    actors: movie.crewMemberMovieCredits.filter(cmmc => cmmc.movieCredit.name === 'Actor')
                        .map(cmmc => cmmc.crewMember.name).join(','),
                    popularity: movie.popularity
                }

                return movieMapped;
            });
        }

        return responseJson;
    }
}

const moviesService = new MoviesService();

export {
    moviesService
};