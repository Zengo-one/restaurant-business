import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/models/restaurant';
import { Food } from 'src/models/food';
import { Ingredient } from 'src/models/ingredient';
import { Router } from '@angular/router';
import { RestaurantService } from 'src/services/restaurant.service';
@Component({
  selector: 'app-restaurant-create',
  templateUrl: './restaurant-create.component.html',
  styleUrls: ['./restaurant-create.component.scss']
})
export class RestaurantCreateComponent implements OnInit {
  public newRestaurant: Restaurant;
  public newFood: Food;
  public newIngredient: Ingredient;
  public someText: string;

  constructor(private router: Router,
    private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.newRestaurant = new Restaurant();
    this.newRestaurant.menu = [];
    this.newFood = new Food();
    this.newFood.ingredients = [];
    this.newIngredient = new Ingredient();
  }

  public onCreateRestaurant(): void{
    this.restaurantService.postRestaurant(this.newRestaurant)
    .subscribe(
      _ => {
        this.router.navigate(['']);
      }
    );
  }

  public onCreateFood(): void{
    this.newRestaurant.menu.push(this.newFood);
    this.newFood = new Food();
  }

  public onCreateIngredient(): void{
    this.newFood.ingredients.push(this.newIngredient);
    this.newIngredient = new Ingredient();
  }
}

