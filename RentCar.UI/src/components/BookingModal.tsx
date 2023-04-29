import { Modal, Button, Form, Dropdown } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import {
  VehicleResource,
  VehicleModelResource,
  ManufacturerResource,
  OfficeResource,
  BookingResource,
} from "../interfaces";
import bookingService from "../services/bookingService";
import React, { useState } from "react";
import Stack from 'react-bootstrap/Stack';
import { useNavigate } from "react-router-dom";
import Alert from "react-bootstrap/Alert";

interface BookingProps {
  vehicle: VehicleResource;
  startDateTime: string;
  endDateTime: string;
  offices: OfficeResource[];
}

const BookingModal = (props: BookingProps) => {
  const navigate = useNavigate();
  const [show, setShow] = useState(false);
  const [selectedPickUpOffice, setSelectedPickUpOffice] =
    useState<OfficeResource | null>(null);
  const [selectedDropOffOffice, setSelectedDropOffOffice] =
    useState<OfficeResource | null>(null);
  const [userName, setUserName] = useState("");
  const [userSurname, setUserSurname] = useState("");
  const [emailAddress, setEmailAddress] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [bookingResponse, setBookingResponse] = useState<BookingResource | null>(null)
  const [showResult, setShowResult] = useState(false);
  const [error, setError] = useState('')
  const [showError, setShowError] = useState(false)

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleCloseResult = () => {
    setShowResult(false);
    navigate(0);
  };
  const handleShowResult = () => setShowResult(true);

  function handleSelectPickUpOffice(selectedId: string | null) {
    if (selectedId !== null) {
      const selectedPickUpOfficeIdInt = parseInt(selectedId);
      const selectedPickUpOffice = props.offices.find(
        (office) => office.id === selectedPickUpOfficeIdInt
      );
      setSelectedPickUpOffice(selectedPickUpOffice || null);
      setShowError(false)
    }
  }

  function handleSelectDropOffOffice(selectedId: string | null) {
    if (selectedId !== null) {
      const selectedDropOffOfficeIdInt = parseInt(selectedId);
      const selectedDropOffOffice = props.offices.find(
        (office) => office.id === selectedDropOffOfficeIdInt
      );
      setSelectedDropOffOffice(selectedDropOffOffice || null);
      setShowError(false)
    }
  }

  const handleUserNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUserName(event.target.value);
  };

  const handleUserSurnameChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setUserSurname(event.target.value);
  };
  
  const handleEmailAddressChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setEmailAddress(event.target.value);
  };

  const handlePhoneNumberChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setPhoneNumber(event.target.value);
  };

  const dayStart = new Date(props.startDateTime);
  const dayEnd = new Date(props.endDateTime);
  const miliseconds = Math.floor(dayEnd.getTime() - dayStart.getTime());

  function calculateDaysFromMilliseconds(milliseconds: number): number {
    const millisecondsInDay = 86400000; // 1000 ms * 60 sec * 60 min * 24 hours
    const days = Math.floor(milliseconds / millisecondsInDay);
    if (milliseconds % millisecondsInDay > 0) {
      return days + 1;
    } else {
      return days;
    }
  }
  const days = calculateDaysFromMilliseconds(miliseconds);

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    // Get the form data and store it in an object
    const formData = {
      vehicleId: props.vehicle.id,
      pickUpOfficeId: selectedPickUpOffice?.id,
      dropOffOfficeId: selectedDropOffOffice?.id,
      pickUpTime: props.startDateTime,
      dropOffTime: props.endDateTime,
      userName: userName,
      userSurname: userSurname,
      emailAddress: emailAddress,
      phoneNumber: phoneNumber,
    };
    
       const postBooking = () => {
          bookingService.create(formData)
          .then((response: any) => {
            console.log(response.data);
            setBookingResponse(response.data)
          })
          .catch((error) => {
            console.log(error);
            setError(error.response.data.messages[0]);
            setShowError(true);
          });
       };
      postBooking();
    if(showError){
      handleClose();
      handleShowResult();
    }

  };

  return (
    <>
      <Button variant="primary" className="w-100 mt-3" onClick={handleShow}>
        Book it!
      </Button>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>
            Booking {props.vehicle.vehicleModel.manufacturer.manufacturerName} {props.vehicle.vehicleModel.modelName}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
        <img
                src={props.vehicle.imagePath}
                className="card-img-top"
                alt="vehicle"
              />
          <h1 className="">TOTAL COST: ${props.vehicle.dailyPrice*days}</h1>
          <Form onSubmit={handleSubmit}>
            <Stack direction="horizontal">
            <Form.Group controlId="pickUpOfficeId" className="me-auto">
              <Form.Label>Select pick up place:  </Form.Label>
              <Dropdown
                onSelect={(eventKey) => handleSelectPickUpOffice(eventKey)}
              >
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                  {selectedPickUpOffice
                    ? selectedPickUpOffice.officeName
                    : "Select an office"}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  {props.offices.map((office) => (
                    <Dropdown.Item key={office.id} eventKey={office.id}>
                      {office.officeName}
                    </Dropdown.Item>
                  ))}
                </Dropdown.Menu>
              </Dropdown>
            </Form.Group>

            <Form.Group controlId="dropOffOfficeId" className="ms-auto">
              <Form.Label>Select drop off place:    </Form.Label>
              <Dropdown
                onSelect={(eventKey) => handleSelectDropOffOffice(eventKey)}
              >
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                  {selectedDropOffOffice
                    ? selectedDropOffOffice.officeName
                    : "Select an office"}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  {props.offices.map((office) => (
                    <Dropdown.Item key={office.id} eventKey={office.id}>
                      {office.officeName}
                    </Dropdown.Item>
                  ))}
                </Dropdown.Menu>
              </Dropdown>
            </Form.Group>
            </Stack>

            <Form.Group controlId="userName">
              <Form.Label>First Name</Form.Label>
              <Form.Control type="text" placeholder="Enter first name" value={userName} onChange={handleUserNameChange} required/>
            </Form.Group>

            <Form.Group controlId="userSurname">
              <Form.Label>Last Name</Form.Label>
              <Form.Control type="text" placeholder="Enter last name" value={userSurname} onChange={handleUserSurnameChange} required/>
            </Form.Group>

            <Form.Group controlId="emailAddress">
              <Form.Label>Email Address</Form.Label>
              <Form.Control type="email" placeholder="Enter email address" value={emailAddress} onChange={handleEmailAddressChange} required/>
            </Form.Group>

            <Form.Group controlId="phoneNumber">
              <Form.Label>Phone Number</Form.Label>
              <Form.Control type="tel" placeholder="Enter phone number" value={phoneNumber} onChange={handlePhoneNumberChange} required/>
            </Form.Group>

            {error && <Alert className="mt-3" show={showError} variant="danger" onClose={() => setShowError(false)} dismissible>
        <Alert.Heading>Oh snap! You got an error!</Alert.Heading>{error}</Alert>}

            <Stack>
            <Button variant="primary" type="submit" className="mt-3" disabled={showError}>
              Submit
            </Button>
            <Button variant="secondary" onClick={handleClose} className="mt-3">
              Cancel
            </Button>
            </Stack>
          </Form>
        </Modal.Body>
        <Modal.Footer></Modal.Footer>
      </Modal>

      <Modal show={showResult} onHide={handleCloseResult}>
        <Modal.Header closeButton>
          <Modal.Title>
            Booking Success! Reservation ID: {bookingResponse?.id}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
        <img
                src={props.vehicle.imagePath}
                className="card-img-top"
                alt="vehicle"
              />
          <h4>You have booked {bookingResponse?.vehicle.vehicleModel.manufacturer.manufacturerName} {bookingResponse?.vehicle.vehicleModel.modelName}</h4>
          <h4>Total price: ${bookingResponse?.totalCost}</h4>
          <h4>Pickup date: {props.startDateTime.replace("T", " ")} </h4>
          <h4>Drop off date: {props.endDateTime.replace("T", " ")}</h4>
          <h4>Check your email for further instructions:</h4>
          <h3> {bookingResponse?.emailAddress}</h3>
        </Modal.Body>
        <Modal.Footer>
        <Button variant="secondary" onClick={handleCloseResult} className="mt-3">
              OK
            </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default BookingModal;
