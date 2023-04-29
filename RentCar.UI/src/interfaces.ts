export interface VehicleResourceQueryResult {
  totalItems: number;
  items: VehicleResource[];
}

export interface VehicleModelResourceQueryResult {
  totalItems: number;
  items: VehicleModelResource[];
}

export interface VehicleResource {
  id: number;
  registrationNumber?: string;
  imagePath?: string;
  dailyPrice: number;
  description?: string;
  year: string;
  status?: boolean;
  vehicleModel: VehicleModelResource;
}
export interface VehicleModelResource {
  id: number;
  modelName?: string;
  description?: string;
  imagePath: string;
  numberOfSeats: number;
  rangeInKilometers: number;
  cargoCapacityInLitres: number;
  manufacturer: ManufacturerResource;
}

export interface ManufacturerResource {
  id: number;
  manufacturerName: string;
}

export interface OfficeResource {
  id: number;
  officeName: string;
  phoneNumber: string;
  address: string;
  timeOpen: string;
  timeClose: string;
  imagePath: string;
  description: string;
}

export interface BookingResource {
  id: number;
  vehicle: VehicleResource;
  pickUpOffice: OfficeResource;
  dropOffOffice: OfficeResource;
  pickUpTime: string;
  dropOffTime: string;
  totalCost: number;
  userName: string;
  userSurname: string;
  emailAddress: string;
  phoneNumber: string;
}

export interface SaveBookingResource {
  vehicleId: number;
  pickUpOfficeId?: number;
  dropOffOfficeId?: number;
  pickUpTime: string;
  dropOffTime: string;
  userName: string;
  userSurname: string;
  emailAddress: string;
  phoneNumber: string;
}
