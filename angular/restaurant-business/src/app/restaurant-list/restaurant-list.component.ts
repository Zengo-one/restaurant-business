import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/services/restaurant.service';
import { Restaurant } from 'src/models/restaurant';
import { Router } from '@angular/router';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.scss']
})
export class RestaurantListComponent implements OnInit {
  public restaurants: Restaurant[];

  constructor(
    private restaurantService: RestaurantService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.restaurantService.getAllRestaurants().subscribe(
      restaurants => this.restaurants = restaurants
      );
  }

  public onCreateRestaurantClick() {
    this.router.navigate(['new']);
  }
}
