import { Injectable } from '@angular/core';
import { UpsertVehicleDto, VehicleClient } from '../Enpoints.g';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private vehicleClient: VehicleClient) { }

  getAllVehicle(){
    return this.vehicleClient.getAllVehicle();
  }
  createVehicle(upsertVehicleDto:UpsertVehicleDto){
    return this.vehicleClient.create(upsertVehicleDto);
  }

  updateVehicle(upsertVehicleDto:UpsertVehicleDto){
    return this.vehicleClient.update(upsertVehicleDto);
  }

  getById( id: string){
    return this.vehicleClient.getById(id);
  }
  deleteById(id:string){
    return this.vehicleClient.delete(id);
  }
}
