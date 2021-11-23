const initialData = {
    tasks: {
        'task-1': { id: 'task-1', content: 'Gipsz Jakab' },
        'task-2': { id: 'task-2', content: 'Arnold St. Fukery' },
        'task-3': { id: 'task-3', content: 'Richard Culenormal' },
        'task-4': { id: 'task-4', content: 'Joe Breinfahrt' },
    },
    columns: {
        'column-1': {
            id: 'column-1',
            title: 'Project1',
            taskIds: ['task-1', 'task-2', 'task-3', 'task-4'],
        },
        'column-2': {
            id: 'column-2',
            title: 'Project2',
            taskIds: [],
        },
        'column-3': {
            id: 'column-3',
            title: 'Project3',
            taskIds: [],
        },
    },
    // Facilitate reordering of the columns
    columnOrder: ['column-1', 'column-2', 'column-3'],
};

export default initialData;
