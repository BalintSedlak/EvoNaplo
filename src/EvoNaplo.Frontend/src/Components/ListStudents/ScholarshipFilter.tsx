import React from 'react'

const options = [
    { value: '', label: 'All' },
    { value: 'Yes', label: 'Yes' },
    { value: 'Maybe', label: 'Maybe' },
    { value: 'No', label: 'No' },
]

export const ScholarshipFilter = ({ column }) => {
    const { filterValue, setFilter } = column;
    return (
        <>
            <span>
                <select value={filterValue || ''} onChange={(e) => setFilter(e.target.value)}>
                    {options.map((option) => (
                        <option value={option.value} >{option.label}</option>
                    ))}
                </select>

            </span>
        </>

    )
}
