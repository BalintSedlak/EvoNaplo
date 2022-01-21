import React, { useState } from 'react';
import { Draggable } from 'react-beautiful-dnd';
import IStudent from './IStudent';

const Card = (student: IStudent, index: number) => {
    return (
        <Draggable draggableId="draggable-1" index={0}>
            {(provided, snapshot) => (
                <div
                    ref={provided.innerRef}
                    {...provided.draggableProps}
                    {...provided.dragHandleProps}
                >
                    <h4>My draggable</h4>
                </div>
            )}
        </Draggable>
    )
}

export default Card;