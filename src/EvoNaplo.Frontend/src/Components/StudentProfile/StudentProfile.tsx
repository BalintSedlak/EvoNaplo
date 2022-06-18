import React, { useState } from 'react'
import { ButtonGroup, ToggleButton } from 'react-bootstrap';
import ISession from '../../ISession';
import { UnauthorizedModal } from '../UI/UnauthorizedModal';
import { EditStudentProfile } from './EditStudentProfile/EditStudentProfile';
import { ViewStudentProfile } from './ViewStudentProfile/ViewStudentProfile';

export const StudentProfile = ({ session }: { session: ISession }) => {

  const [editStudentProfile, setEditStudentProfile] = useState('1');
  

  if (session.id > 0) {

    const buttonElements = [
      {name: 'View', value: '1'},
      {name: 'Edit', value: '2'}
    ]

    const toggleEditProfil = () => {

    }

    

    return (
      <>
       <ButtonGroup>
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
        {editStudentProfile==='1' ? <ViewStudentProfile/> : <EditStudentProfile/>}
      </>
    )
  }
  else {
    return <UnauthorizedModal />
  }
}
