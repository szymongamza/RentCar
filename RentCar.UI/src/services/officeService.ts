
import http from "../http-common";
import {OfficeResource} from "../interfaces";

class OfficeService {
  GetAll() {
    return http.get<OfficeResource[]>(`/Offices`);
  }
}

export default new OfficeService();
