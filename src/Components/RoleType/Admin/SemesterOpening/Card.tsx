import React, { useState } from 'react';
import { Draggable } from 'react-beautiful-dnd';
import ICard from './ICard';

const grid = 8;

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

const Card = (Content: ICard) => {
    return (
        <Draggable key={Content.draggableId} draggableId={Content.draggableId.toString()} index={Content.index}>
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
                    {Content.title}
                </div>
            )}
        </Draggable>
    )
}

export default Card;


