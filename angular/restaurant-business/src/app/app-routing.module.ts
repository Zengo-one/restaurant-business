import { NgModule } from '@angular/core';
import { RestaurantListComponent } from './restaurant-list/restaurant-list.component';
import { RestaurantCreateComponent } from './restaurant-list/restaurant-create/restaurant-create.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    { path: 'new', component: RestaurantCreateComponent},
    { path: '', component: RestaurantListComponent, pathMatch: 'full' },
  ];
  
@NgModule({
    declarations: [],
    imports: [
      [RouterModule.forRoot(routes)]
    ],
    exports: [RouterModule]
  })
export class AppRoutingModule { }