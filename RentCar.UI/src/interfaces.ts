export interface VehicleResourceQueryResult{
    totalItems: number,
    items: VehicleResource[]
  }

export interface VehicleResource{
    id:	number,
    registrationNumber?:	string,
    imagePath?: string,
    dailyPrice:	number,
    description?:	string,
    year:	string,
    status?:	boolean,
    vehicleModel: VehicleModelResource
  }
  export  interface VehicleModelResource{
    id:	number,
    modelName?:	string,
    description?:	string,
    imagePath: string,
    numberOfSeats:	number,
    rangeInKilometers:	number,
    cargoCapacityInLitres:	number,
    manufacturer: ManufacturerResource
  }

  export interface ManufacturerResource{
    id:	number,
    manufacturerName:	string
  }


