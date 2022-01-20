import React, { useState } from 'react';
import { DragDropContext } from 'react-beautiful-dnd';
import Column from './Column';

const SemesterOpening = () => {
    const projects = [
        {
            id: 1, name: 'Project1', students: [
                { id: 1, name: 'Student1' },
                { id: 2, name: 'Student2' },
                { id: 3, name: 'Student3' },
                { id: 4, name: 'Student4' }
            ]
        },
        {
            id: 2, name: 'Project2', students: [
                { id: 5, name: 'Student5' },
                { id: 6, name: 'Student6' },
                { id: 7, name: 'Student7' },
                { id: 8, name: 'Student8' }
            ]
        },
        {
            id: 3, name: 'Project3', students: [
                { id: 9, name: 'Student9' },
                { id: 10, name: 'Student10' },
                { id: 11, name: 'Student11' },
                { id: 12, name: 'Student12' }
            ]
        }
    ]

    // // using useCallback is optional
    // const onBeforeCapture = useCallback(() => {
    //     /*...*/
    // }, []);
    // const onBeforeDragStart = useCallback(() => {
    //     /*...*/
    // }, []);
    // const onDragStart = useCallback(() => {
    //     /*...*/
    // }, []);
    // const onDragUpdate = useCallback(() => {
    //     /*...*/
    // }, []);
    // const onDragEnd = useCallback(() => {
    //     // the only one that is required
    // }, []);


    return (
        // <DragDropContext
        //     onBeforeCapture={onBeforeCapture}
        //     onBeforeDragStart={onBeforeDragStart}
        //     onDragStart={onDragStart}
        //     onDragUpdate={onDragUpdate}
        //     onDragEnd={onDragEnd}
        // >
            <div>
                {projects.map(project => <Column
                    id={project.id}
                    title={project.name}
                    students={project.students}
                />
                )}
            </div>
        // </DragDropContext>
    )
}

export default SemesterOpening
