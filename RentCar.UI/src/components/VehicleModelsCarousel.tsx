import { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Carousel from 'react-bootstrap/Carousel';
import './VehicleModelsCarousel.css';
import {Button} from 'react-bootstrap';


function VehicleModelsCarousel() {
    const [vehiclesModels, setVehiclesModels] = useState<VehicleModelResource[]>([]);
    const [error, setError] = useState({});

    interface VehicleModelResourceQueryResult{
        totalItems: number,
        items: VehicleModelResource[]
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
      const fetchVehiclesModels = async () => {
        const response = await fetch(
          `http://localhost:5245/api/VehicleModels`
        );
        const data: VehicleModelResourceQueryResult = await response.json();
        setVehiclesModels(data.items);
      };
      fetchVehiclesModels();
    }, []);


  return (
    <div className='carousel-wrapper'>
    <Carousel>
        {vehiclesModels.map((vehicleModel)=>(
            <Carousel.Item key={vehicleModel.id}>
                <img
                  className="d-block w-100"
                  src={vehicleModel.imagePath}
                  alt={vehicleModel.manufacturer.manufacturerName + vehicleModel.modelName}
                />
                <Carousel.Caption>
                    <h3>{vehicleModel.manufacturer.manufacturerName}</h3>
                    <p>{vehicleModel.modelName}</p>
                </Carousel.Caption>
            </Carousel.Item>
        ))}
    </Carousel>
    </div>
  );
}

export default VehicleModelsCarousel;