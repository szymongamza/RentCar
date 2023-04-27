import SearchBar from "./SearchBar";
import VehicleModelsCarousel from "./VehicleModelsCarousel";
import React, { useState, useEffect } from "react";
import TimeService from "../services/timeService"
import Spinner from 'react-bootstrap/Spinner';

function Home() {
  const [time, setTime] = useState("");

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
    <div>
      <VehicleModelsCarousel></VehicleModelsCarousel>
      <h2 className='text-center'>Check availability:</h2>
      <SearchBar selectedStartDateTime={time} selectedEndDateTime={time}/>
    </div>
  );
}

export default Home;