import React, { useState, useEffect } from 'react';
import { Container, Table } from 'react-bootstrap';
import { moviesService } from '../services';
import { MoviesList, Paging, Search } from '.';

export default function Home() {
  const [moviesData, setMoviesData] = useState({ movies: [], totalPages: 0 });
  const [loadingState, setLoadingState] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [inputValue, setInputValue] = useState('');
  const [pageNumber, setPageNumber] = useState(1);

  const handleKeyUp = e => {
    if (e.key === 'Enter') {
      setSearchTerm(e.target.value);
      setPageNumber(1);
    }
  }

  const handleClear = () => {
    setInputValue('');
    setSearchTerm('');
    setPageNumber(1);
  }

  const onDispose = () => {
    setMoviesData({ movies: [], totalPages: 0 });
    setLoadingState(false);
  }

  useEffect(() => {
    const fetchData = async () => {
      setLoadingState(true);
      const response = await moviesService.getMovies(searchTerm, pageNumber);

      if (response != null) {
        setMoviesData(response);
        setLoadingState(false);
      }
    }

    fetchData();

    return () => onDispose();
  }, [searchTerm, pageNumber]);

  if (loadingState) {
    return <h1>Loading...</h1>
  }

  if (moviesData.movies.length === 0) {
    return <h1>There are no movies to show. Please come back again later.</h1>
  }


  return <Container fluid>
    <Search inputValue={inputValue} setInputValue={setInputValue} handleKeyUp={handleKeyUp} handleClear={handleClear} />
    <Table striped bordered hover size='sm'>
      <thead>
        <tr>
          <th>#TMDBID</th>
          <th>Original title</th>
          <th>Release date</th>
          <th>Genre</th>
          <th>Director</th>
          <th>Actors</th>
          <th>Popularity</th>
        </tr>
      </thead>
      <tbody>
        <MoviesList data={moviesData.movies} />
        <Paging pageNumber={pageNumber} setPageNumber={setPageNumber} totalPages={moviesData.totalPages} />
      </tbody>
    </Table>
  </Container>
}