import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Restaurant } from 'src/models/restaurant';
import { HttpClient } from '@angular/common/http';
import { ApiSettings } from 'src/api-settings';


@Injectable({
    providedIn: 'root'
})
export class RestaurantService {
    private httpClient: HttpClient;
    constructor(httpClient: HttpClient){
        this.httpClient = httpClient;
    }

    public getAllRestaurants(): Observable<Restaurant[]> {
        return this.httpClient.get<Restaurant[]>(ApiSettings.API_ROOT_PATH + ApiSettings.RESTAURANT_PATH);
    }

    public postRestaurant(restaurant: Restaurant) {
        return this.httpClient.post<any>(ApiSettings.API_ROOT_PATH + ApiSettings.RESTAURANT_PATH, restaurant);
    }
}