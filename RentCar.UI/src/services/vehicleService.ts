
import http from "../http-common";
import {VehicleResourceQueryResult} from "../interfaces";

class VehicleService {
  QueryVehicles(page: number, itemsPerPage: number, fromDateTime: string, toDateTime: string) {
    return http.get<VehicleResourceQueryResult>(`/Vehicles?page=${page}&itemsPerPage=${itemsPerPage}&StartDateTime=${fromDateTime}&EndDateTime=${toDateTime}&Status=true`);
  }
}

export default new VehicleService();
