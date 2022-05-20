import React from 'react'

const options = [
    { value: '', label: 'All Semester' },
    { value: '2022/1', label: 'Actual' },
    { value: '2021/2', label: '2021/2' },
    { value: '2021/1', label: '2021/1' },
]

export const SemesterFilter = ({filter, setFilter}) => {
    return (
        <>
            <span>
                <select value={filter || ''} onChange={(e) => setFilter(e.target.value)}>
                    {options.map((option) => (
                        <option value={option.value} >{option.label}</option>
                    ))}
                </select>

            </span>
        </>

    )
}
