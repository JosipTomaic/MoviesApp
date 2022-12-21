import React from 'react';
import { OverlayTrigger, Tooltip } from "react-bootstrap";

export default function MovieItem(props) {
    const {
        movie
    } = props;

    return (
        <tr>
            <td>{movie.tmdbId}</td>
            <td>{movie.title}</td>
            <td>{movie.releaseDate}</td>
            <td>{movie.genres}</td>
            <td>{movie.directors}</td>
            <td>
                <OverlayTrigger
                    placement="bottom"
                    overlay={
                        <Tooltip>
                            {movie.actors}
                        </Tooltip>
                    }
                >
                    <span className="text-nowrap bd-highlight text-truncate actors-cell-truncated">
                        {movie.actors}
                    </span>
                </OverlayTrigger>
            </td>
            <td>{movie.popularity}</td>
        </tr>
    )
}