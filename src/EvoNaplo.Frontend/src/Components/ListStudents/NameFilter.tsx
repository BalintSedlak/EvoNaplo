import React from 'react'

export const NameFilter = ({ column }) => {
    const {filterValue, setFilter} = column;
    return (
        <span>
            <input value={filterValue || ''} onChange={(e) => setFilter(e.target.value)} />
        </span>
        
    )
}
