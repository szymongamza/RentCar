import React, { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

interface SearchFormProps {
  onSearch: (fromDate: string, fromTime: string, toDate: string, toTime: string) => void;
}

function SearchBar({ onSearch }: SearchFormProps) {
  const [fromDate, setFromDate] = useState('');
  const [fromTime, setFromTime] = useState('');
  const [toDate, setToDate] = useState('');
  const [toTime, setToTime] = useState('');

  const handleFromDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFromDate(event.target.value);
  };

  const handleFromTimeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFromTime(event.target.value);
  };

  const handleToDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setToDate(event.target.value);
  };

  const handleToTimeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setToTime(event.target.value);
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    onSearch(fromDate, fromTime, toDate, toTime);
  };

  return (
    <div>
        <h1 className='text-center'>Check availability:</h1>
    <Form onSubmit={handleSubmit} className="mx-auto w-50 mt-5 text-center">
        <Row>
            <Col>
      <Form.Group controlId="fromDate">
        <Form.Label>Pickup date:</Form.Label>
        <Form.Control
          type="date"
          value={fromDate}
          onChange={handleFromDateChange}
        />
      </Form.Group>
      </Col>
      <Col>
      <Form.Group controlId="fromTime">
      <Form.Label>Pickup time:</Form.Label>
        <Form.Control
          type="time"
          value={fromTime}
          onChange={handleFromTimeChange}
        />
      </Form.Group>
      </Col>
      </Row>

      <Row>
            <Col>
      <Form.Group controlId="toDate">
        <Form.Label>Drop off date:</Form.Label>
        <Form.Control
          type="date"
          value={toDate}
          onChange={handleToDateChange}
        />
      </Form.Group>
      </Col>
      <Col>
      <Form.Group controlId="toTime">
      <Form.Label>Drop off time:</Form.Label>
        <Form.Control
          type="time"
          value={toTime}
          onChange={handleToTimeChange}
        />
      </Form.Group>
      </Col>
      </Row>


      <Button variant="primary" type="submit" size='lg' className="mt-3">
        Search
      </Button>
    </Form>
    </div>
  );
}

export default SearchBar;
