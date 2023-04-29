import { useState, useEffect } from "react";
import { Button, Pagination } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { useLocation } from "react-router-dom";
import SearchBar from "./SearchBar";
import BookingModal from "./BookingModal";
import Spinner from "react-bootstrap/Spinner";
import {
  VehicleModelResource,
  VehicleResourceQueryResult,
  VehicleResource,
  ManufacturerResource,
  OfficeResource,
} from "../interfaces";
import vehicleService from "../services/vehicleService";
import officeService from "../services/officeService";

function Availability() {
  const [vehicles, setVehicles] = useState<VehicleResource[]>([]);
  const [page, setPage] = useState<number>(1);
  const [itemsPerPage, setItemsPerPage] = useState<number>(9);
  const [totalItems, setTotalItems] = useState<number>(0);
  const [offices, setOffices] = useState<OfficeResource[]>([]);
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);
  const fromDateTime = searchParams.get("fromDateTime") ?? "";
  const toDateTime = searchParams.get("toDateTime") ?? "";

  const handlePrevPage = () => {
    setPage((prev) => prev - 1);
  };

  const handleNextPage = () => {
    setPage((prev) => prev + 1);
  };

  const hasNextPage = () => {
    return page * itemsPerPage < totalItems;
  };

  const hasPreviousPage = () => {
    return page == 1;
  };

  useEffect(() => {
    const fetchVehicles = () => {
      vehicleService
        .QueryVehicles(page, itemsPerPage, fromDateTime, toDateTime)
        .then((response: any) => {
          const data = response.data;
          setVehicles(data.items);
          setTotalItems(data.totalItems);
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    };
    const fetchOffices = () => {
      officeService
        .GetAll()
        .then((response: any) => {
          const data = response.data;
          setOffices(data);
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    };

    fetchVehicles();
    fetchOffices();
  }, [page, fromDateTime, toDateTime]);

  if (vehicles.length == 0) {
    return (
      <div className="d-flex justify-content-center align-items-center mt-10">
        <Spinner animation="border" variant="primary" />
      </div>
    );
  }

  return (
    <div className="container">
      <SearchBar
        selectedStartDateTime={fromDateTime}
        selectedEndDateTime={toDateTime}
      />
      <h1 className="mt-3 mb-3">Available Vehicles</h1>
      <Pagination className="mt-3">
        <Pagination.Prev
          onClick={handlePrevPage}
          disabled={!hasPreviousPage()}
        />
        {Array.from(
          { length: Math.ceil(totalItems / itemsPerPage) },
          (_, i) => (
            <Pagination.Item
              key={i + 1}
              active={page === i + 1}
              onClick={() => setPage(i + 1)}
            >
              {i + 1}
            </Pagination.Item>
          )
        )}
        <Pagination.Next onClick={handleNextPage} disabled={!hasNextPage()} />
      </Pagination>
      <Row xs={1} md={2} lg={3} className="g-4">
        {vehicles.map((vehicle) => (
          <Col key={vehicle.id}>
            <div className="card h-100">
              <img
                src={vehicle.imagePath}
                className="card-img-top"
                alt="vehicle"
              />
              <div className="card-body">
                <h5 className="card-title">{vehicle.vehicleModel.modelName}</h5>
                <p className="card-text">
                  {vehicle.vehicleModel.manufacturer.manufacturerName}
                </p>
                <p className="cart-text">Production year: {vehicle.year}</p>
                <p className="card-text">
                  {vehicle.vehicleModel.numberOfSeats} seats
                </p>
                <p className="card-text">
                  {vehicle.vehicleModel.rangeInKilometers}km of range
                </p>
                <p className="card-text">
                  {vehicle.vehicleModel.cargoCapacityInLitres}L of cargo space
                </p>
                <p className="card-text">${vehicle.dailyPrice} per day</p>
                <BookingModal
                  vehicle={vehicle}
                  startDateTime={fromDateTime}
                  endDateTime={toDateTime}
                  offices={offices}
                />
              </div>
            </div>
          </Col>
        ))}
      </Row>
      <Pagination className="mt-3">
        <Pagination.Prev
          onClick={handlePrevPage}
          disabled={hasPreviousPage()}
        />
        {Array.from(
          { length: Math.ceil(totalItems / itemsPerPage) },
          (_, i) => (
            <Pagination.Item
              key={i + 1}
              active={page === i + 1}
              onClick={() => setPage(i + 1)}
            >
              {i + 1}
            </Pagination.Item>
          )
        )}
        <Pagination.Next onClick={handleNextPage} disabled={!hasNextPage()} />
      </Pagination>
    </div>
  );
}

export default Availability;
