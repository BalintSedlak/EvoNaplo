import React, { useEffect } from 'react'

const options = [
    { value: '2022/1', label: 'Actual' },
    { value: '2021/2', label: '2021/2' },
    { value: '2021/1', label: '2021/1' },
    { value: '', label: 'All Semester' },
]

export const SemesterFilter = ({filter, setFilter}) => {

    useEffect(()=>{setFilter("2022/1");},[])

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
