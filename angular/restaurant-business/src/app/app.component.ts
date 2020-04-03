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
    this.restaurants = [
      new Restaurant
      ('1', 'resta', 'Kosmichna 25, Kharkiv', 'Ukraine', 
        [new Food('soup', 10.50, 
          [new Ingredient('mushrooms', '50g'), new Ingredient('carrot', '30g')])]),
      new Restaurant
      ('2', 'dolche', 'Pushkina 1, Kharkiv', 'Ukraine', 
        [new Food('pizza with pineapples', 8, 
          [new Ingredient('pineapples', '50g'), new Ingredient('meat', '60g')])]),   
    ];
    //this.restaurantService.getAllRestaurants();
  }  
}
