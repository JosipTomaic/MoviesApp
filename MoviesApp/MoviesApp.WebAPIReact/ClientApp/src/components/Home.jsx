import React, { useState, useEffect } from 'react';
import { Button, Container, Table } from 'react-bootstrap';
import { moviesService } from '../services';
import { MoviesList } from '.';
import { Input } from 'reactstrap';

export default function Home() {
  const [movies, setMovies] = useState([]);
  const [loadingState, setLoadingState] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');
  const [inputValue, setInputValue] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      const response = await moviesService.getMovies(searchTerm);

      if (response != null) {
        setMovies(response);
      }
    }

    fetchData();

    return () => {
      setMovies([]);
      setLoadingState(false);
    }
  }, [searchTerm]);

  if (loadingState) {
    return <h1>Loading...</h1>
  }

  return <Container fluid>
    <div className='input-group'>
      <Input
        className="my-2"
        placeholder="Type a search term and press enter on keyboard"
        aria-label="Searchterm"
        aria-describedby="search-field"
        value={inputValue}
        onChange={e => setInputValue(e.target.value)}
        onKeyUp={e => {
          if (e.key === 'Enter') {
            setSearchTerm(e.target.value);
          }
        }}
      />
      <button className="btn btn-primary position-relative" type="button" onClick={() => {
        setInputValue('');
        setSearchTerm('');
      }}>
        <i className="fa-sharp fa-solid fa-xmark"></i>
      </button>
    </div>
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
        <MoviesList data={movies} />
      </tbody>
    </Table>
  </Container>
}