
import http from "../http-common";
import {VehicleModelResourceQueryResult} from "../interfaces";

class VehicleModelService {
  GetVehicleModels() {
    return http.get<VehicleModelResourceQueryResult>(`/VehicleModels`);
  }
}

export default new VehicleModelService();
