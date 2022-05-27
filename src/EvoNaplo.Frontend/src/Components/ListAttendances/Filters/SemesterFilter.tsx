import React from 'react'

const options = [
    { value: '', label: 'All' },
    { value: '2021/1', label: '2021/1' },
    { value: '2022/1', label: '2022/1' },
    { value: '2022/2', label: '2022/2' },
]

export const SemesterFilter = ({ column }) => {
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
