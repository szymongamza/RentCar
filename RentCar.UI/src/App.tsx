import './App.css';
import NavBar from './components/NavBar';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from './components/Home';
import OfficesCarousel from './components/OfficesCarousel';
import Availability from './components/Availability';


function App() {
  return (

    <Router>
      <NavBar/>
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/offices" element={<OfficesCarousel/>}/>
        <Route path="/availability" element={<Availability />} />
      </Routes>
    </Router>

  );
}

export default App;
