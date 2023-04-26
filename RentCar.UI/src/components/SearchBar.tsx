import React, { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Modal from 'react-bootstrap/Modal';

interface SearchFormProps {
  onSearch: (fromDate: string, fromTime: string, toDate: string, toTime: string) => void;
}

function SearchBar({ onSearch }: SearchFormProps) {
  const currentDate = new Date().toISOString().substr(0, 10);

  const [fromDate, setFromDate] = useState('');
  const [fromTime, setFromTime] = useState('');
  const [toDate, setToDate] = useState('');
  const [toTime, setToTime] = useState('');
  const [showModal, setShowModal] = useState(false);

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

  const isAfter = (fromDate: string, fromTime: string, toDate: string, toTime: string) => {
    const fromDateTime = new Date(`${fromDate}T${fromTime}`);
    const toDateTime = new Date(`${toDate}T${toTime}`);
    return toDateTime > fromDateTime;
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (isAfter(fromDate, fromTime, toDate, toTime)) {
      onSearch(fromDate, fromTime, toDate, toTime);
    } else {
      setShowModal(true);
    }
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };

  return (
    <div>
        <h2 className='text-center'>Check availability:</h2>
    <Form onSubmit={handleSubmit} className="mx-auto w-50 mt-3 text-center">
        <Row>
            <Col>
      <Form.Group controlId="fromDate">
        <Form.Label>Pickup date:</Form.Label>
        <Form.Control
          type="date"
          value={fromDate}
          min={currentDate}
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
          min={currentDate}
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


      <Button variant="primary" type="submit" size='lg' className="mt-3 mb-3">
        Search
      </Button>
    </Form>
    
    <Modal show={showModal} onHide={handleCloseModal}>
      <Modal.Header closeButton>
        <Modal.Title>Error</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        The selected drop off time must be after the selected pickup time.
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleCloseModal}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
    </div>
  );
}

export default SearchBar;
