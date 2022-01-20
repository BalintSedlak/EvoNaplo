import React, { useState } from 'react';
import { Droppable, Draggable } from 'react-beautiful-dnd';
import { DragDropContext } from 'react-beautiful-dnd';
import Card from './Card';
import IColumn from './IColumn';

import IStudent from './IStudent';

const Column = (project: IColumn) => {

    const [getStudents, setStudents] = useState(project.students);

    const reorder = (list: IStudent[], startIndex: any, endIndex: any): IStudent[] => {
        const result = Array.from(list);
        const [removed] = result.splice(startIndex, 1);
        result.splice(endIndex, 0, removed);

        return result;
    };

    function onDragEnd(result: any) {
        // dropped outside the list
        if (!result.destination) {
            return;
        }

        const students = reorder(
            getStudents,
            result.source.index,
            result.destination.index
        );

        setStudents(students)
    }

    const grid = 8;

    const getListStyle = (isDraggingOver: Boolean) => ({
        background: isDraggingOver ? "lightblue" : "lightgrey",
        padding: grid,
        width: 250
    });

    const getColumnStyle = () => ({
        background: "green",
        padding: grid,
        width: 250
    });

    const getItemStyle = (isDragging: boolean, draggableStyle: any) => ({
        // some basic styles to make the items look a bit nicer
        userSelect: "none",
        padding: grid * 2,
        margin: `0 0 ${grid}px 0`,

        // change background colour if dragging
        background: isDragging ? "lightgreen" : "grey",

        // styles we need to apply on draggables
        ...draggableStyle
    });

    return (
        <div style={getColumnStyle()}>
            <p>{project.title}</p>
            <DragDropContext onDragEnd={onDragEnd}>
                <Droppable droppableId={project.id.toString()}>
                    {(provided, snapshot) => (
                        <div
                            {...provided.droppableProps}
                            ref={provided.innerRef}
                            style={getListStyle(snapshot.isDraggingOver)}
                        >
                            {getStudents.map((student, index) => (
                                <Draggable key={student.id} draggableId={student.id.toString()} index={index}>
                                    {(provided, snapshot) => (
                                        <div
                                            ref={provided.innerRef}
                                            {...provided.draggableProps}
                                            {...provided.dragHandleProps}
                                            style={getItemStyle(
                                                snapshot.isDragging,
                                                provided.draggableProps.style
                                            )}
                                        >
                                            {student.name}
                                        </div>
                                    )}
                                </Draggable>
                            ))}
                            {provided.placeholder}
                        </div>
                    )}
                </Droppable>
            </DragDropContext>
        </div>
    )
}

export default Column;



// {project.students.map(student =>
//     <Card
//         id={student.id}
//         name={student.name}

//     />
// )}