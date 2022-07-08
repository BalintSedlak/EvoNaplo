import { Card, } from "react-bootstrap";

export default function Comments({ data }: { data: string[] }) {

  return (<Card  className="mb-2"style={{ width: '18rem' }} text={'white'} bg={'success'}>
    <Card.Body>
    <blockquote className="blockquote mb-0">
        <Card.Title>{data[0]}</Card.Title>
        <Card.Text>
          {data[1]}
        </Card.Text>
        <footer className="blockquote-footer">
          {data[2]}
        </footer>
      </blockquote>
    </Card.Body>
  </Card>);
}