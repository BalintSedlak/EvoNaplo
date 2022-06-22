import React from 'react'
import { Card } from 'react-bootstrap'

export const EditStudentInformation = () => {
  return (
    <>
        <Card className='m-5'>
          <Card.Header>Profile Data:</Card.Header>
          <Card.Body>
            <blockquote className="blockquote mb-0">
              <p> Full Name: Kis Béla</p>
              <p> Email</p>
              <p> Phone Number</p>
              <p> Studies: Egyetem</p>
              <p> Technologies: C#</p>
              <p> Fb Group</p>
              <p> Scholarship: No</p>
              <p> Internship </p>
            </blockquote>
          </Card.Body>
        </Card>

    </>
  )
}
