import React from "react";
import { MovieItem } from ".";

export default function MoviesList(props) {
    const {
        data
    } = props;

    return data.map(movie => {
        return <MovieItem key={movie.tmdbId} movie={movie} />
    });
}