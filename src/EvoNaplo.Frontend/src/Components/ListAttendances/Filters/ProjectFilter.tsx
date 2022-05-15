import React from 'react'

export const ProjectFilter = ({ column }) => {
    const {filterValue, setFilter} = column;
    return (
        <span>
            <input value={filterValue || ''} onChange={(e) => setFilter(e.target.value)} />
        </span>
        
    )
}
