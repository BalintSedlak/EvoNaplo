import React, { useCallback, useState } from 'react';
import { DragDropContext, DraggableLocation } from 'react-beautiful-dnd';
import Column from './Column';

const SemesterOpening = () => {
    const projects = [
        {
            id: 0, name: 'Project0', students: [
                { id: 0, title: 'Student0' },
                { id: 1, title: 'Student1' },
                { id: 2, title: 'Student2' },
                { id: 3, title: 'Student3' }
            ]
        },
        {
            id: 1, name: 'Project1', students: [
                { id: 4, title: 'Student4' },
                { id: 5, title: 'Student5' },
                { id: 6, title: 'Student6' },
                { id: 7, title: 'Student7' }
            ]
        },
        {
            id: 2, name: 'Project2', students: [
                { id: 8, title: 'Student8' },
                { id: 9, title: 'Student9' },
                { id: 10, title: 'Student10' },
                { id: 11, title: 'Student11' }
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
                    cards={project.students}
                />
                )}
            </div>
        </DragDropContext>
    )
}

export default SemesterOpening
