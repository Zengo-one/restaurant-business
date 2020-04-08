import { Food } from './food';
import { Address } from './address';

export class Restaurant {
    id: string;
    name: string;
    address: Address;
    menu: Food[];
}