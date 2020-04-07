import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ApiSettings } from 'src/api-settings';
import { Address } from 'src/models/address';

@Injectable({
    providedIn: 'root'
})
export class AddressService {
    constructor(private httpClient: HttpClient){
    }

    public getAllAddresses() {
        return this.httpClient.get<Address[]>(ApiSettings.API_ROOT_PATH + ApiSettings.ADDRESS_PATH);
    }

    public postAddress(address: Address) {
        return this.httpClient.post<any>(ApiSettings.API_ROOT_PATH + ApiSettings.ADDRESS_PATH, address);
    }
}