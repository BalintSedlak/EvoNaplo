import React, { Component, useEffect, useState } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import GetObjectPropValuesMonitor from '../../components/GetObjectPropValues/GetObjectPropValuesMonitor';
import Accordion from '../../components/Accordion/Accordion';
import ListTable from '../ListTable';
import UnauthorizedPage from '../../components/Unauthorized'

export default function StudentsPage() {
    const [data, setData] = useState([]);
    const [q, setQ] = useState("");
    const fetchUrl = '/Semesters';

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

    useEffect(() => {
        fetch('api/Semester' + fetchUrl)
            .then(response => response.json())
            .then(json => setData(json))
            //.then(json => console.log(json))
    }, []);

    
    function search(rows) {
        return rows.filter(row => row.startDate.toLowerCase().indexOf(q.toLowerCase()) > -1)
    }

    if (session !== undefined) {
        if (session.title !== "Unauthorized") {
            if (session.role !== "Student") {
                return (
                    <div>
                        Filter: <input type="text" value={q} onChange={(e) => setQ(e.target.value)} />
                        <a href="/AddSemesterPage" style={{ float: 'right' }}>
                            <input type="button" value="Add Semester" />
                        </a>
                        <br />
                        <br />
                        <ListTable data={search(data)} headings={["Start date", "End date", "IsAppliable"]} url={'api/Semester'} />
                    </div>
                );
            }
        }
    }           
     return (
        <UnauthorizedPage />
    );
}