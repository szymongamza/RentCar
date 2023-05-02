import { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import Carousel from "react-bootstrap/Carousel";
import "./VehicleModelsCarousel.css";
import Spinner from "react-bootstrap/Spinner";
import vehicleModelService from "../services/vehicleModelService";
import {
  VehicleModelResourceQueryResult,
  VehicleModelResource,
  ManufacturerResource,
} from "../interfaces";

function VehicleModelsCarousel() {
  const [vehiclesModels, setVehiclesModels] = useState<VehicleModelResource[]>(
    []
  );

  useEffect(() => {
    const fetchVehicleModels = () => {
      vehicleModelService
        .GetVehicleModels()
        .then((response: any) => {
          const data = response.data;
          setVehiclesModels(data.items);
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    };
    fetchVehicleModels();
  }, []);

  if (vehiclesModels.length === 0) {
    return (
      <div className="d-flex justify-content-center align-items-center mt-10">
        <Spinner animation="border" variant="primary" />
      </div>
    );
  }

  return (
    <div className="carousel-wrapper">
      <Carousel>
        {vehiclesModels.map((vehicleModel) => (
          <Carousel.Item key={vehicleModel.id}>
            <img
              className="d-block w-100"
              src={vehicleModel.imagePath}
              alt={
                vehicleModel.manufacturer.manufacturerName +
                vehicleModel.modelName
              }
            />
            <Carousel.Caption>
              <h3>
                {vehicleModel.manufacturer.manufacturerName}{" "}
                {vehicleModel.modelName}
              </h3>
              <p>Number of seats: {vehicleModel.numberOfSeats}</p>
              <p>Range: {vehicleModel.rangeInKilometers}km</p>
            </Carousel.Caption>
          </Carousel.Item>
        ))}
      </Carousel>

    </div>
    
  );
}

export default VehicleModelsCarousel;
