import React, { useEffect } from 'react';

function GetObjectPropValuesMonitor(obj) {

    const listItems = Object.entries(obj).map(([key, value]) =>
        <tr key={key} class="ListRow">
            <td>
                {key}
            </td>
            <td>
                {value}
            </td>
        </tr>
    );
    return (
        <table>
            {listItems}
        </table>
    );
}

export default GetObjectPropValuesMonitor;