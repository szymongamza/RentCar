import { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Carousel from 'react-bootstrap/Carousel';
import './OfficesCarousel.css';
import { OfficeResource } from '../interfaces';
import Spinner from 'react-bootstrap/Spinner';
import officeService from '../services/officeService';

function OfficesCarousel() {
    const [offices, setOffices] = useState<OfficeResource[]>([]);
    const [error, setError] = useState({});

    useEffect(() => {
      const fetchOffices = () => {
        officeService.GetAll()
        .then((response: any) => {
          const data = response.data;
          setOffices(data);
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
      };
      fetchOffices();
    }, []);
  
    if (offices.length ==0) {
      return (
        <div className="d-flex justify-content-center align-items-center mt-10" >
          <Spinner animation="border" variant="primary" />
        </div>
      )
    }


  return (
    <div className='carousel-wrapper'>
    <Carousel>
        {offices.map((office)=>(
            <Carousel.Item key={office.id}>
                <img
                  className="d-block w-100"
                  src={office.imagePath}
                  alt={office.officeName}
                />
                <Carousel.Caption>
                    <h3>{office.officeName}</h3>
                    <p>{office.address}</p>
                    <p>{office.phoneNumber}</p>
                    <p>{office.timeOpen.slice(0,5)} till {office.timeClose.slice(0,5)}</p>
                </Carousel.Caption>
            </Carousel.Item>
        ))}
    </Carousel>
    </div>
  );
}

export default OfficesCarousel;