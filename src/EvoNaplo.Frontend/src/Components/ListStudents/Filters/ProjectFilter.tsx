import React from 'react'

const options = [
    { value: '', label: 'All Project' },
    { value: 'EvoNaplo', label: 'EvoNaplo' },
    { value: 'EvoRPG', label: 'EvoRPG' },
    { value: 'EvoFlix', label: 'EvoFlix' },
]

export const ProjectFilter = ({ column }) => {
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
