import React, { Component, useEffect, useState } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import GetObjectPropValuesMonitor from '../../components/GetObjectPropValues/GetObjectPropValuesMonitor';
import Accordion from '../../components/Accordion/Accordion';
import ListTable from '../ListTable';
import UnauthorizedPage from '../../components/Unauthorized';

export default function AdminsPage() {
    const [data, setData] = useState([]);
    const [q, setQ] = useState("");
    const fetchUrl = '/Admins';

    useEffect(() => {
        fetch('api/User' + fetchUrl)
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
        return rows.filter(row => row.name.toLowerCase().indexOf(q.toLowerCase()) > -1)
    }

    if (session !== undefined) {
        if (session.title !== "Unauthorized") {
            if (session.role === "Admin" && Object.keys(data).length > 0) {
                return (
                    <div>
                        Filter: <input type="text" value={q} onChange={(e) => setQ(e.target.value)} />
                        <br />
                        <br />
                        <ListTable data={search(data)} headings={["Name", "Activity", "Email", "Phone"]} role={session.role} url={'api/User'} />
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
