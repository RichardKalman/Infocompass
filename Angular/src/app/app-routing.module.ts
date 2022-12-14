import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleAddUpdateComponent } from './vehicle-add-update/vehicle-add-update.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';

const routes: Routes = [

  { path: '', component: VehicleListComponent, pathMatch: 'full' },
  { path: 'letrehozas', component: VehicleAddUpdateComponent, pathMatch: 'full' },
  { path: 'modosit/:id', component: VehicleAddUpdateComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
