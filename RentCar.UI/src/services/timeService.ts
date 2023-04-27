
import http from "../http-common";

class TimeService {
  getTime() {
    return http.get<string>("/Datetime");
  }
}

export default new TimeService();
