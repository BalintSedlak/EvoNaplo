import React, { Component } from 'react';
//import NavMenu from './NavMenu';

export default function Layout(props:any) {
    return (
        <div>
            {/* <NavMenu/> */}
            <div>
                {props.children}
            </div>
        </div>
    );
}