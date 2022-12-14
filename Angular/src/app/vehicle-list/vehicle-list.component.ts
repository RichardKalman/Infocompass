import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, take } from 'rxjs';
import { VehicleDto } from '../Enpoints.g';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit,OnDestroy {


  vehicleSubscription: Subscription = new Subscription();
  vehicleList: VehicleDto[] = [];
  constructor(private vehicleService: VehicleService, private router: Router) { }


  ngOnInit(): void {
    this.vehicleSubscription = this.vehicleService.getAllVehicle().subscribe(t => this.vehicleList= t );
  }

  ngOnDestroy(): void {
    this.vehicleSubscription.unsubscribe();
  }

  createNavigate() {
    this.router.navigate(["/letrehozas"]);
  }
  updateNavigate(id: string) {
    this.router.navigate([`/modosit/${id}`]);
  }
  deleteById(id: string) {
    console.log("meghív")
    this.vehicleService.deleteById(id).pipe(take(1)).subscribe(t => {
      this.vehicleList = this.vehicleList.filter(v => v.id !== id);
    });

  }

}
