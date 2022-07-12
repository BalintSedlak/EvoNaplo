import React from 'react'

export const ListAttendancesProjectFilter = ({ column }) => {
    const {filterValue, setFilter} = column;
    return (
        <span>
            <input value={filterValue || ''} onChange={(e) => setFilter(e.target.value)} />
        </span>
        
    )
}
