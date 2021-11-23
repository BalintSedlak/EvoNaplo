import React, { Component, useEffect, useState } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import GetObjectPropValuesMonitor from '../../components/GetObjectPropValues/GetObjectPropValuesMonitor';
import Accordion from '../../components/Accordion/Accordion';
import ListTable from '../ListTable';
import UnauthorizedPage from '../../components/Unauthorized';

export default function ProjectsPage() {
    const [data, setData] = useState([]);
    const [q, setQ] = useState("");
    const fetchUrl = '/Projects';


    useEffect(() => {
        fetch('api/Project' + fetchUrl)
            .then(response => response.json())
            .then(json => setData(json))
    }, []);

    const [session, setSession] = useState();
    useEffect(() => {
        (
            async () => {
                const response = await fetch('api/Session', { method: 'GET' });
                const content = await response.json();

                await setSession(content);
            }
        )();
    }, []);

    function search(rows) {
        return rows.filter(row => row.projectName.toLowerCase().indexOf(q.toLowerCase()) > -1)
    }

    if (session !== undefined) {
        if (session.title !== "Unauthorized") {
            if (session.role !== "Student") {
                return (
                    <div>
                        Filter: <input type="text" value={q} onChange={(e) => setQ(e.target.value)} />
                        <a href="/AddProjectPage" style={{ float: 'right' }}>
                            <input type="button" value="Add Project" />
                        </a>
                        <br />
                        <br />
                        <ListTable data={search(data)} headings={["Project name", "Description", "Source link", "Technologies", "Semester Id"]} role={session.role} url={'api/Project'} />
                    </div>
                );
            }
            return (
                <p>No data available</p>
            );
        }
    }
    return (
        <UnauthorizedPage />
    );
}
