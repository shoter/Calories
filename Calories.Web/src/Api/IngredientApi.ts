import { CaloriesApiBase } from "./CaloriesApiBase";
import { Ingredient } from "../Models/Ingredient";
import rp from "request-promise-native";
import { HttpMethod } from "./HttpMethod";

export class IngredientApi extends CaloriesApiBase {
    constructor()
    {
        super("Ingredient");
    }

    InsertIngredient(ingredient: Ingredient) : rp.RequestPromise
    {
        var options = this.createBaseOptions(HttpMethod.POST);

        options.body = ingredient;

        return rp(options);
    }

    
}