import React from 'react';

export default function SearchClearButton(props) {
    const {
        handleClear
    } = props;

    return (
        <button className="btn btn-primary position-relative" type="button" onClick={handleClear}>
            <i className="fa-sharp fa-solid fa-xmark"></i>
        </button>
    )
}