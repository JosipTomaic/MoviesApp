import React from 'react';
import { Pagination } from 'react-bootstrap';

export default function Paging(props) {
    const {
        pageNumber,
        totalPages,
        setPageNumber
    } = props;

    return (
        <Pagination>
            {totalPages > 1 ?
                <>
                    <Pagination.First onClick={() => setPageNumber(1)} disabled={pageNumber === 1} />
                    <Pagination.Prev onClick={() => setPageNumber(pageNumber - 1)} disabled={pageNumber === 1} />
                </>
                : null
            }
            {[...Array(totalPages)].map((x, idx) => {
                return <Pagination.Item key={idx} onClick={() => setPageNumber(idx + 1)} active={pageNumber === (idx + 1)}>{idx + 1}</Pagination.Item>
            })}
            {totalPages > 1 ?
                <>
                    <Pagination.Next onClick={() => setPageNumber(pageNumber + 1)} disabled={pageNumber === totalPages} />
                    <Pagination.Last onClick={() => setPageNumber(totalPages)} disabled={pageNumber === totalPages} />
                </>
                : null
            }
        </Pagination>
    )
}