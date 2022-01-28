import React, { useCallback, useState } from 'react';
import { DragDropContext, DraggableLocation } from 'react-beautiful-dnd';
import Column from './Column';
import IStudent from './IStudent';

const SemesterOpening = () => {
    const projects = [
        {
            id: 0, name: 'Project0', students: [
                { id: 0, name: 'Student0' },
                { id: 1, name: 'Student1' },
                { id: 2, name: 'Student2' },
                { id: 3, name: 'Student3' }
            ]
        },
        {
            id: 1, name: 'Project1', students: [
                { id: 4, name: 'Student4' },
                { id: 5, name: 'Student5' },
                { id: 6, name: 'Student6' },
                { id: 7, name: 'Student7' }
            ]
        },
        {
            id: 2, name: 'Project2', students: [
                { id: 8, name: 'Student8' },
                { id: 9, name: 'Student9' },
                { id: 10, name: 'Student10' },
                { id: 11, name: 'Student11' }
            ]
        }
    ]

    const [getProjects, setProjects] = useState(projects);

    const reorder = (projects: any[], source: DraggableLocation, destination: DraggableLocation): any[] => {
        const sourceProject = projects.find(project => project.id == source.droppableId);
        const destinationProject = projects.find(project => project.id == destination.droppableId);
        
        const [movedElement] = sourceProject.students.splice(source.index, 1);
        destinationProject.students.splice(destination.index, 0, movedElement);

        projects[Number(source.droppableId)] = sourceProject;
        projects[Number(destination.droppableId)] = destinationProject;

        return projects;
    };

    const onDragEnd = useCallback((result: any) => {
        // dropped outside the list
        if (!result.destination) {
            return;
        }

        const projects = reorder(
            getProjects,
            result.source,
            result.destination
        );

        setProjects(projects)
    }, []);


    return (
        <DragDropContext onDragEnd={onDragEnd}>
            <div>
                {getProjects.map(project => <Column
                    id={project.id}
                    title={project.name}
                    students={project.students}
                />
                )}
            </div>
        </DragDropContext>
    )
}

export default SemesterOpening
