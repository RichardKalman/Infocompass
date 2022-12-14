import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { UpsertVehicleDto, VehicleDto } from '../Enpoints.g';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-vehicle-add-update',
  templateUrl: './vehicle-add-update.component.html',
  styleUrls: ['./vehicle-add-update.component.css']
})
export class VehicleAddUpdateComponent implements OnInit {

  selectedId: string = "";

  formGroup: FormGroup = new FormGroup({
    name: new FormControl("", Validators.required),
    cost: new FormControl("", Validators.required),
    year: new FormControl("", Validators.required)
  })
  selectedVehicle: VehicleDto | undefined;

  get name(){
    return this.formGroup.get("name") as FormControl;
  }
  get cost(){
    return this.formGroup.get("cost") as FormControl;
  }
  get year(){
    return this.formGroup.get("year") as FormControl;
  }
  constructor(private vehicleService: VehicleService, private router:Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    let routeParam = this.route.snapshot.paramMap.get('id');
    if (routeParam != null){
      this.selectedId = routeParam;
      this.vehicleService.getById(this.selectedId).pipe(take(1)).subscribe(t => {

        this.selectedVehicle = t;
        this.name.setValue(this.selectedVehicle?.name);
        this.cost.setValue(this.selectedVehicle?.cost);
        this.year.setValue(this.selectedVehicle?.year);

      });


    }
  }

  onSubmit() {
    let formValue: UpsertVehicleDto = this.formGroup.value;

    if(this.selectedVehicle){
      formValue.id = this.selectedId;
      this.vehicleService.updateVehicle(formValue).pipe(take(1)).subscribe(t => this.router.navigate([""]));
    }
    else{
      this.vehicleService.createVehicle(formValue).pipe(take(1)).subscribe(t => this.router.navigate([""]));
    }
    console.log(formValue);
  }

}
