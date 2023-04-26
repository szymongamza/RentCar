import SearchBar from "./SearchBar";
import VehicleModelsCarousel from "./VehicleModelsCarousel";
const handleSearch = (fromDate: string, toDate: string) => {
    // Make API call with fromDate and toDate values
    // Update searchResults state with API response
  };

function Home() {
  return (
    <div>
        <VehicleModelsCarousel></VehicleModelsCarousel>
        <SearchBar onSearch={handleSearch}></SearchBar>
    </div>
  );
}

export default Home;
