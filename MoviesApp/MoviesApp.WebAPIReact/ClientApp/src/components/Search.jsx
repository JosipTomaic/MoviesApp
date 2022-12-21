import React from 'react';
import { Input } from 'reactstrap';
import SearchClearButton from './SearchClearButton';

export default function Search(props) {
    const {
        inputValue,
        setInputValue,
        handleKeyUp,
        handleClear
    } = props;

    return (
        <div className='input-group'>
            <Input
                className="my-2"
                placeholder="Type a search term and press enter on keyboard"
                aria-label="Searchterm"
                aria-describedby="search-field"
                value={inputValue}
                onChange={e => setInputValue(e.target.value)}
                onKeyUp={handleKeyUp}
            />
            <SearchClearButton handleClear={handleClear} />
        </div>
    )
}