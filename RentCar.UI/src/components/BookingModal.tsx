import React, { useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { VehicleResource, VehicleModelResource, ManufacturerResource } from "../interfaces";

interface BookingProps{
    vehicle: VehicleResource,
    startDateTime: string,
    endDateTime: string
};

const BookingModal = (props: BookingProps) => {
    const [show, setShow] = useState(false);
    const [pickUpOfficeId, setPickUpOfficeId] = useState(1);
    const [dropOffOfficeId, setDropOffOfficeId] = useState(1);
    const [userName, setUserName] = useState('');
    const [userSurname, setUserSurname] = useState('');
    const [emailAddress, setEmailAddress] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handlePickUpOfficeIdChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPickUpOfficeId(parseInt(event.target.value));
      };
    
      const handleDropOffOfficeIdChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDropOffOfficeId(parseInt(event.target.value));
      };
    
      const handleUserNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUserName(event.target.value);
      };
    
      const handleUserSurnameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUserSurname(event.target.value);
      };

      const handleEmailAddressChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmailAddress(event.target.value);
      };

      const handlePhoneNumberChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPhoneNumber(event.target.value);
      };



    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
      
        // Get the form data and store it in an object
        const formData = {
          vehicleId: props.vehicle.id,
          pickUpOfficeId: pickUpOfficeId,
          dropOffOfficeId: dropOffOfficeId,
          pickUpTime: props.startDateTime,
          dropOffTime: props.endDateTime,
          userName: userName,
          userSurname: userSurname,
          emailAddress: emailAddress,
          phoneNumber: phoneNumber
        };
      
        // Make a POST request to the API endpoint using axios
        axios.post("your-api-endpoint-url", formData)
          .then(() => {
            // Handle successful response
            console.log("send");
          });
      
        // Close the modal
        handleClose();
      };

  
    return (
      <>
        <Button variant="primary" className="w-100 mt-3" onClick={handleShow}>
          Add Booking
        </Button>
  
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Add Booking</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <p>{props.vehicle.id}</p>
            <Form onSubmit={handleSubmit}>  
              <Form.Group controlId="pickUpOfficeId">
                <Form.Label>Pick-up office ID</Form.Label>
                <Form.Control type="number" value={pickUpOfficeId} onChange={handlePickUpOfficeIdChange} placeholder="Enter pick-up office ID" />
              </Form.Group>
  
              <Form.Group controlId="dropOffOfficeId">
                <Form.Label>Drop-off office ID</Form.Label>
                <Form.Control type="text" placeholder="Enter drop-off office ID" />
              </Form.Group>
  
              <Form.Group controlId="userName">
                <Form.Label>First Name</Form.Label>
                <Form.Control type="text" placeholder="Enter first name" />
              </Form.Group>
  
              <Form.Group controlId="userSurname">
                <Form.Label>Last Name</Form.Label>
                <Form.Control type="text" placeholder="Enter last name" />
              </Form.Group>
  
              <Form.Group controlId="emailAddress">
                <Form.Label>Email Address</Form.Label>
                <Form.Control type="email" placeholder="Enter email address" />
              </Form.Group>
  
              <Form.Group controlId="phoneNumber">
                <Form.Label>Phone Number</Form.Label>
                <Form.Control type="text" placeholder="Enter phone number" />
              </Form.Group>

              <Button variant="primary" type="submit">
                 Submit
              </Button>
            <Button variant="secondary" onClick={handleClose}>
              Cancel
            </Button>
            </Form>
          </Modal.Body>
          <Modal.Footer>

          </Modal.Footer>
        </Modal>
      </>
    );
  };
  
  export default BookingModal;