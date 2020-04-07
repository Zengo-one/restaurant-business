import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/models/restaurant';
import { Food } from 'src/models/food';
import { Ingredient } from 'src/models/ingredient';
import { Router } from '@angular/router';
import { RestaurantService } from 'src/services/restaurant.service';
import { AddressService } from 'src/services/address.service';
import { Address } from 'src/models/address';
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

  public addresses: Address[];
  public newAddress: Address;
  public isAddingAddress: boolean;

  constructor(private router: Router,
    private restaurantService: RestaurantService,
    private addressService: AddressService) { }

  ngOnInit(): void {
    this.newRestaurant = new Restaurant();
    this.newRestaurant.menu = [];
    this.newFood = new Food();
    this.newFood.ingredients = [];
    this.newIngredient = new Ingredient();
    this.newAddress = new Address();

    this.isAddingAddress = false;
    this.addressService.getAllAddresses().subscribe(
      result => this.addresses = result
    );
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
    this.newFood.ingredients = [];
  }

  public onCreateIngredient(): void{
    this.newFood.ingredients.push(this.newIngredient);
    this.newIngredient = new Ingredient();
  }

  public onOpenAddAddress(){
    this.isAddingAddress = true;
  }

  onCreateAddress(){
    this.addressService.postAddress(this.newAddress).subscribe(
      _ => this.addressService.getAllAddresses().subscribe(
        addresses => this.addresses = addresses
      )
    );
    this.isAddingAddress = false;
  }
}

