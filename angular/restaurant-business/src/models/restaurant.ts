import { Food } from './food';

export class Restaurant {
    constructor(id: string, name: string, address: string, country: string, menu: Food[]){
        this.id = id;
        this.name = name;
        this.address = address;
        this.country = country;
        this.menu = menu;
    }
    id: string;
    name: string;
    address: string;
    country: string;
    menu: Food[];
}