import React from 'react'

const options = [
    { value: '', label: 'All' },
    { value: 'Kap', label: 'Kap' },
    { value: 'Jelenetkezett', label: 'Jelentkezett' },
    { value: 'Nincs', label: 'Nincs' },
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
