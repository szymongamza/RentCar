import { useState, useEffect } from 'react';
import {Button} from 'react-bootstrap';
import {Stack} from 'react-bootstrap';
import './OurVehicles.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

function OurVehicles() {
    const [vehicles, setVehicles] = useState<VehicleResource[]>([]);
    const [page, setPage] = useState<number>(1);
    const [itemsPerPage, setItemsPerPage] = useState<number>(10);
    const [error, setError] = useState({});
    const [totalItems, setTotalItems] = useState<number>(0);

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
      const fetchVehicles = async () => {
        const response = await fetch(
          `http://localhost:5245/api/Vehicles?page=${page}&itemsPerPage=${itemsPerPage}`
        );
        const data: VehicleResourceQueryResult = await response.json();
        setVehicles(data.items);
        setTotalItems(data.totalItems);
      };
      fetchVehicles();
    }, [page, itemsPerPage]);

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
    <div>
    <Container>
      <Row xs={2} md={5} className="g-4">
        {vehicles.map((vehicle) => (
          <Col key={vehicle.id}>
            <div className="card h-100">
              <img src={vehicle.imagePath} className="card-img-top" alt={vehicle.vehicleModel.modelName} />
              <div className="card-body">
                <h5 className="card-title">{vehicle.vehicleModel.modelName}</h5>
                <p className="card-text">{vehicle.registrationNumber}</p>
              </div>
            </div>
          </Col>
        ))}
      </Row>
    </Container>
        <Stack direction="horizontal" gap={2}>
          <Button onClick={handlePrevPage} disabled={hasPreviousPage()}>Previous</Button>
          <Button onClick={handleNextPage} disabled={!hasNextPage()}>Next</Button>
        </Stack>
        </div>
  );
}

export default OurVehicles;