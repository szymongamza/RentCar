import React from 'react';
import logo from './logo.svg';
import './App.css';
import OurVehicles from './components/OurVehicles';
import NavBar from './components/NavBar';
import VehicleModelsCarousel from './components/VehicleModelsCarousel';
import SearchBar from './components/SearchBar';
const handleSearch = (fromDate: string, toDate: string) => {
  // Make API call with fromDate and toDate values
  // Update searchResults state with API response
};

function App() {
  return (
    <div>
    <VehicleModelsCarousel/>
    <SearchBar onSearch={handleSearch}/>
    </div>
  );
}

export default App;
