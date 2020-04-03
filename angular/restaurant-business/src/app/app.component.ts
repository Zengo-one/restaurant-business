import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/services/restaurant.service';
import { Restaurant } from 'src/models/restaurant';
import { Observable } from 'rxjs';
import { Food } from 'src/models/food';
import { Ingredient } from 'src/models/ingredient';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  private restaurantService: RestaurantService;
  public restaurants: Restaurant[];

  constructor(restaurantService: RestaurantService) {
    this.restaurantService = restaurantService;
  }

  ngOnInit(): void {
    this.restaurantService.getAllRestaurants().subscribe(
      restaurants => this.restaurants = restaurants
      );
  }  
}
