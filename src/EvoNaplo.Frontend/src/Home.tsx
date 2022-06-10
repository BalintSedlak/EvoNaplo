import React, { useEffect, useState } from 'react';
import ISession from './ISession';
import { Sun } from 'react-bootstrap-icons';

export default function Home({ session }: { session: ISession }) {
    if (session.id > 0) {
        return (
            <div>
                <h1>Welcome to Evonaplo!</h1>
                <p className="text-justify">
                    You are at the homepage of EvoNaplo.

                    What is EvoNaplo, you may ask?
                    EvoNaplo is an online diary for Evosoft's talent program: EvoCampus.

                    The EvoCampus talent program offers a place for developers to learn new skills and perfect the skills they already posess.
                    It is a great place to learn new things from web to software developement and all other skills. Learning is done through simulated projects, which are proposed by Evosoft or the students.
                    For the projects the students form a team and get assigned one or more mentors.

                    At the end of each semester, students showcase what they learned, how they figured out the details of the projects and what they are planning to do in the future.

                    Our project, EvoNaplo, strives to administrate all aspects of this talent program, from students, through projects to attandances and reviews and a lot more.
                    While creating this much of EvoNaplo, we have already learned a tremendous amount and we hope to continue building, developing and perfecting this website, and in the meantime of course: learn a lot.</p>
                <h1><Sun/></h1>
            </div>
        );
    }
    return (
        //Redirect
        <div className="alert alert-warning">You must be logged in to continue.</div>
    );
};