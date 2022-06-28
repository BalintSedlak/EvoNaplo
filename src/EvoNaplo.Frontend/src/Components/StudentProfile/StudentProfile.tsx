import React, { useState } from 'react'
import { ButtonGroup, ToggleButton } from 'react-bootstrap';
import ISession from '../../ISession';
import { UnauthorizedModal } from '../UI/UnauthorizedModal';
import { EditStudentProfile } from './EditStudentProfile/EditStudentProfile';
import  ViewStudentProfile  from './ViewStudentProfile/ViewStudentProfile';
import classes from './StudentProfile.module.css'

//https://localhost:3000/Components/StudentProfile/StudentProfile
//props: student id
export const StudentProfile = ({ session }: { session: ISession }) => {

  const [editStudentProfile, setEditStudentProfile] = useState('1');


  if (session.id > 0) {

    const buttonElements = [
      { name: 'View', value: '1' },
      { name: 'Edit', value: '2' }
    ]

    //TODO: fetch the student data from backend with the given id

    return (
      <>
        <div>
          <ButtonGroup className={classes.toggleButtonPosition}>
            {buttonElements.map((radio, idx) => (
              <ToggleButton
                key={idx}
                id={`radio-${idx}`}
                type="radio"
                variant={idx % 2 ? 'outline-success' : 'outline-danger'}
                name="radio"
                value={radio.value}
                checked={editStudentProfile === radio.value}
                onChange={(e) => setEditStudentProfile(e.currentTarget.value)}
              >
                {radio.name}
              </ToggleButton>
            ))}
          </ButtonGroup>
        </div>
        <div>
          {/*szebb lenne ha magán a komponensen belűl változna a dolog, egyelőre legyen szétszedve a 2 mert egyszerűbb most még úgy megcsinálni*/}
          {editStudentProfile === '1' ? <ViewStudentProfile /> : <EditStudentProfile />}
        </div>
      </>
    )
  }
  else {
    return <UnauthorizedModal />
  }
}
