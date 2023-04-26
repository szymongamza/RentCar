import './App.css';
import NavBar from './components/NavBar';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from './components/Home';
import OurVehicles from './components/OurVehicles';
import OfficesCarousel from './components/OfficesCarousel';


function App() {
  return (

    <Router>
      <NavBar/>
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/cars" element={<OurVehicles/>}/>
        <Route path="/offices" element={<OfficesCarousel/>}/>
      </Routes>
    </Router>

  );
}

export default App;
