import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from "react";
import TimeService from "../services/timeService"
import Spinner from 'react-bootstrap/Spinner';
import './SearchBar.css';
interface Props {
  selectedStartDateTime: string,
   selectedEndDateTime: string
}

function SearchBar(props: Props) {
  const navigate = useNavigate();

  const [fromDateTime, setFromDate] = useState(props.selectedStartDateTime);
  const [toDateTime, setToDate] = useState(props.selectedEndDateTime);
  const [showModal, setShowModal] = useState(false);
  const [time, setTime] = useState("");
  

  const handleFromDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFromDate(event.target.value);
  };


  const handleToDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setToDate(event.target.value);
  };


  const isAfter = (fromDateTime: string, toDateTime: string, ) => {
    const fromDateTimeObj = new Date(`${fromDateTime}`);
    const toDateTimeObj = new Date(`${toDateTime}`);
    return toDateTimeObj > fromDateTimeObj;
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (isAfter(fromDateTime,toDateTime)) {
      navigate(
        `/availability?fromDateTime=${fromDateTime}&toDateTime=${toDateTime}`
      );
      navigate(0);
    } else {
      setShowModal(true);
    }
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };



  useEffect(() => {
    const fetchTime = () => {
      TimeService.getTime()
      .then((response: any) => {
        setTime(response.data.slice(0,16));
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
    };
    fetchTime();
  }, []);

  if (!time) {
    return (
      <div className="d-flex justify-content-center align-items-center mt-10" >
        <Spinner animation="border" variant="primary" />
      </div>
    )
  }


  return (
    <div className="container text-center">
    <Form onSubmit={handleSubmit} className="mx-auto w-50 mt-3 text-center">
      <Form.Group controlId="fromDate">
        <Form.Label>Pickup date:</Form.Label>
        <Form.Control
          type="datetime-local"
          value={fromDateTime}
          min={time}
          onChange={handleFromDateChange}
        />
      </Form.Group>

      <Form.Group controlId="toDate">
        <Form.Label>Drop off date:</Form.Label>
        <Form.Control
          type="datetime-local"
          value={toDateTime}
          min={time}
          onChange={handleToDateChange}
        />
      </Form.Group>


      <Button variant="primary" type="submit" size='lg' className="mt-3">
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
