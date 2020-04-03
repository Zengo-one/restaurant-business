import { Ingredient } from './ingredient';

export class Food {
    constructor(name: string, cost: number, ingredients: Ingredient[]) {
        this.name = name;
        this.cost = cost;
        this.ingredients = ingredients;
    }
    name: string;
    cost: number;
    ingredients: Ingredient[];
}