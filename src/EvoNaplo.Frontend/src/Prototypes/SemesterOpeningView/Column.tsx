import React, { useState } from 'react';
import { Droppable } from 'react-beautiful-dnd';
import Card from './Card';
import IColumn from './IColumn';

import ICard from './ICard';

const Column = (project: IColumn) => {

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

    return (
        <div style={getColumnStyle()}>
            <p>{project.title}</p>
                <Droppable droppableId={project.id.toString()}>
                    {(provided, snapshot) => (
                        <div
                            {...provided.droppableProps}
                            ref={provided.innerRef}
                            style={getListStyle(snapshot.isDraggingOver)}
                        >
                            {project.cards.map((student, cardIndex) => (
                                <Card draggableId={student.id} title={student.title} index={cardIndex} />
                            ))}
                        </div>
                    )}
                </Droppable>
        </div>
    )
}

export default Column;