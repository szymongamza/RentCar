import SearchBar from "./SearchBar";
import VehicleModelsCarousel from "./VehicleModelsCarousel";

function Home() {
  return (
    <div>
        <VehicleModelsCarousel></VehicleModelsCarousel>
        <h2 className='text-center'>Check availability:</h2>
        <SearchBar/>
    </div>
  );
}

export default Home;
