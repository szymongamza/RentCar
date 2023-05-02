
import http from "../http-common";
import {BookingResource, SaveBookingResource} from "../interfaces";

class BookingService {
  create(data: SaveBookingResource) {
    return http.post<BookingResource>(`/Bookings`, data);
  }
}

export default new BookingService();
