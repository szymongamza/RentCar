import { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Carousel from 'react-bootstrap/Carousel';
import './OfficesCarousel.css';


function OfficesCarousel() {
    const [offices, setOffices] = useState<OfficeResource[]>([]);
    const [error, setError] = useState({});

    interface OfficeResource{
      id: number,
      officeName:	string,
      phoneNumber: string,
      address: string,
      timeOpen:	string,
      timeClose: string,
      imagePath: string,
      description:	string
    }



    useEffect(() => {
      const fetchOffices = async () => {
        const response = await fetch(
          `http://localhost:5245/api/Offices`
        );
        const data = await response.json();
        setOffices(data);
      };
      fetchOffices();
    }, []);


  return (
    <div className='carousel-wrapper'>
    <Carousel>
        {offices.map((office)=>(
            <Carousel.Item key={office.id}>
                <img
                  className="d-block w-100"
                  src={"office1.jpg"}
                  alt={office.officeName}
                />
                <Carousel.Caption>
                    <h3>{office.officeName}</h3>
                    <p>{office.address}</p>
                    <p>{office.phoneNumber}</p>
                    <p>{office.timeOpen} till {office.timeClose}</p>
                </Carousel.Caption>
            </Carousel.Item>
        ))}
    </Carousel>
    </div>
  );
}

export default OfficesCarousel;