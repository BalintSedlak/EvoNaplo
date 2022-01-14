import React from "react";

import './DropdownMenu.css'

function DropdownMenu(props) {
    return (
        <div className="Dropdownmenu">
            <p className="DropdownmenuTitle">{props.title}</p>
            <div className="DropdownmenuContent">
                {props.content}
            </div>
        </div>
    );
}

export default DropdownMenu;
