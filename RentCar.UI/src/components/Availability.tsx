import { useState, useEffect } from 'react';
import {Button, Pagination} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useLocation } from 'react-router-dom';
import SearchBar from './SearchBar';

function Availability() {
    const [vehicles, setVehicles] = useState<VehicleResource[]>([]);
    const [page, setPage] = useState<number>(1);
    const [itemsPerPage, setItemsPerPage] = useState<number>(9);
    const [error, setError] = useState({});
    const [totalItems, setTotalItems] = useState<number>(0);
    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const fromDate = searchParams.get('fromDate') ?? '';
    const fromTime = searchParams.get('fromTime') ?? '';
    const toDate = searchParams.get('toDate') ?? '';
    const toTime = searchParams.get('toTime') ?? '';

    interface VehicleResourceQueryResult{
      totalItems: number,
      items: VehicleResource[]
    }

    interface VehicleResource{
      id:	number,
      registrationNumber?:	string,
      imagePath?: string,
      dailyPrice:	number,
      description?:	string,
      year:	string,
      status?:	boolean,
      vehicleModel: VehicleModelResource
    }

    interface VehicleModelResource{
      id:	number,
      modelName?:	string,
      description?:	string,
      imagePath: string,
      numberOfSeats:	number,
      rangeInKilometers:	number,
      cargoCapacityInLitres:	number,
      manufacturer: ManufacturerResource
    }

    interface ManufacturerResource{
      id:	number,
      manufacturerName:	string
    }

    useEffect(() => {
        const fromDateTime = new Date(`${fromDate}T${fromTime}`).toISOString();
        const toDateTime = new Date(`${toDate}T${toTime}`).toISOString();
        const url = encodeURI(`http://localhost:5245/api/Vehicles?page=${page}&itemsPerPage=${itemsPerPage}&StartDateTime=${fromDateTime}&EndDateTime=${toDateTime}`)
      const fetchVehicles = async () => {
        const response = await fetch(url);
        const data: VehicleResourceQueryResult = await response.json();
        setVehicles(data.items);
        setTotalItems(data.totalItems);
      };
      fetchVehicles();
    }, [page, itemsPerPage, fromDate, fromTime, toDate, toTime]);

    const handlePrevPage = () => {
      setPage((prev) => prev- 1 );
    };
  
    const handleNextPage = () => {
      setPage((prev) => prev + 1);
    };

    const hasNextPage = () => {
      return (page * itemsPerPage) < totalItems;
    };

    const hasPreviousPage = () => {
      return page == 1;
    };

  return (
    <div className="container">
        <SearchBar></SearchBar>
    <h1 className="mt-3 mb-3">Available Vehicles</h1>
    <Pagination className="mt-3">
      <Pagination.Prev onClick={handlePrevPage} disabled={!hasPreviousPage()} />
      {Array.from({ length: Math.ceil(totalItems / itemsPerPage) }, (_, i) => (
        <Pagination.Item key={i + 1} active={page === i + 1} onClick={() => setPage(i + 1)}>
          {i + 1}
        </Pagination.Item>
      ))}
      <Pagination.Next onClick={handleNextPage} disabled={!hasNextPage()} />
    </Pagination>
    <Row xs={1} md={2} lg={3} className="g-4">
      {vehicles.map((vehicle) => (
        <Col key={vehicle.id}>
          <div className="card h-100">
            <img src={vehicle.imagePath} className="card-img-top" alt="vehicle" />
            <div className="card-body">
              <h5 className="card-title">{vehicle.vehicleModel.modelName}</h5>
              <p className="card-text">{vehicle.vehicleModel.manufacturer.manufacturerName}</p>
              <p className="card-text">{vehicle.vehicleModel.numberOfSeats} seats</p>
              <p className="card-text">{vehicle.vehicleModel.rangeInKilometers}km of range</p>
              <p className="card-text">{vehicle.vehicleModel.cargoCapacityInLitres}L of cargo space</p>
              <p className="card-text">${vehicle.dailyPrice} per day</p>
              <Button variant="primary" className="w-100 mt-3">Book</Button>
            </div>
          </div>
        </Col>
      ))}
    </Row>
    <Pagination className="mt-3">
      <Pagination.Prev onClick={handlePrevPage} disabled={hasPreviousPage()} />
      {Array.from({ length: Math.ceil(totalItems / itemsPerPage) }, (_, i) => (
        <Pagination.Item key={i + 1} active={page === i + 1} onClick={() => setPage(i + 1)}>
          {i + 1}
        </Pagination.Item>
      ))}
      <Pagination.Next onClick={handleNextPage} disabled={!hasNextPage()} />
    </Pagination>
  </div>
  );
}

export default Availability;