import React, { Component, useEffect, useState } from 'react';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';

import '@atlaskit/css-reset';
import styled from 'styled-components';
import initialData from './initial-data';
import Column from './Column';

const Container = styled.div`
  display: flex;
`;

export default function SemesterStartStudentPage() {
    const [projectFields, updateprojectFields] = useState({});
    const [studentProjectToEdit, setStudentProjectToEdit] = useState();

    useEffect(() => {
        fetch('api/ProjectStudent/ProjectsStudents')
            .then(response => response.json())
            .then(json => updateprojectFields(json))
    }, []);

    useEffect(() => {
        console.log(projectFields);
    }, [projectFields]);

    useEffect(() => {

        if (studentProjectToEdit !== undefined) {
            console.log(JSON.stringify(studentProjectToEdit));
            fetch('api/ProjectStudent/ProjectsStudentsChanged', { method: 'PUT', body: JSON.stringify(studentProjectToEdit), headers: { "Content-Type": "application/json" } })
                .then(function (data) {
                    //setSuccess(true);
                })
                .catch(function (error) {
                    //setSuccess(false);
                });
        }
    }, [studentProjectToEdit]);

    function handleOnDragEnd(result) {
        const { destination, source, draggableId } = result;

        if (!destination) {
            return;
        }

        if (
            destination.droppableId === source.droppableId &&
            destination.index === source.index
        ) {
            return;
        }

        const start = projectFields.columnProjects[source.droppableId - 1];
        const finish = projectFields.columnProjects[destination.droppableId - 1];

        if (start === finish) {
            //const newTaskIds = Array.from(start.columnProjects);
            //newTaskIds.splice(source.index, 1);
            //newTaskIds.splice(destination.index, 0, draggableId);

            //const newColumn = {
            //    ...start,
            //    taskIds: newTaskIds,
            //};

            //const newState = {
            //    ...projectFields,
            //    columnProjects: {
            //        ...projectFields.columnProjects,
            //        [newColumn.id]: newColumn,
            //    },
            //};

            //updateprojectFields(newState);
            return;
        }

        // Moving from one list to another
        const startTaskIds = Array.from(start.projectStudentIds);
        startTaskIds.splice(source.index, 1);
        const newStart = {
            ...start,
            taskIds: startTaskIds,
        };

        const finishTaskIds = Array.from(finish.projectStudentIds);
        finishTaskIds.splice(destination.index, 0, draggableId);
        const newFinish = {
            ...finish,
            taskIds: finishTaskIds,
        };

        var cp = projectFields.columnProjects;
        cp.find(obj => obj.id == destination.droppableId).projectStudentIds.push(draggableId);
        cp.find(obj => obj.id == source.droppableId).projectStudentIds.splice(source.index, 1);

        const newState = {
            ...projectFields,
            columnProjects: cp
        }
        updateprojectFields(newState);

        setStudentProjectToEdit({ studentId: +draggableId, fromProjectId: +source.droppableId, toProjectId: +destination.droppableId });
    };

    if ('columnOrder' in projectFields && 'columnProjects' in projectFields) {
        if (false) {

        }
        return (
            <div>
                <h2>Managing users on projects</h2>
                <p>Hint: Drag and drop the users to the selected project.</p>
                <DragDropContext onDragEnd={handleOnDragEnd}>
                    <div class="grid-table justify-content-center">
                        {projectFields.columnOrder.map(columnId => {
                            let column = projectFields.columnProjects.find(obj =>
                                obj.id === columnId);
                            let tasks = column.projectStudentIds.map(
                                taskId => projectFields.usersOnProject.find(obj => obj.id == taskId),
                            );


                            return <Column key={column.id} column={column} tasks={tasks} />;
                        })}
                    </div>
                </DragDropContext>
            </div>
        );
    }
    else {
        return (
            <p>Loading data..</p>
        );
    }
}