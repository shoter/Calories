import { CaloriesApiBase } from "./CaloriesApiBase";
import { Ingredient } from "../Models/Ingredient";
import rp from "request-promise-native";
import { HttpMethod } from "./HttpMethod";
import { ApiPromise } from "./ApiBase";
import { NewIngredient } from "../Models/NewIngredient";

export class IngredientApi extends CaloriesApiBase {
    constructor()
    {
        super("Ingredient");
    }

    InsertIngredient(ingredient: NewIngredient) : rp.RequestPromise
    {
        var options = this.createBaseOptions(HttpMethod.POST);

        options.body = ingredient;

        return rp(options);
    }

    GetAllIngredients() : ApiPromise<Ingredient[]>
    {
        var options = this.createBaseOptions(HttpMethod.GET, "GetAll");

        return this.createPromiseRequest<Ingredient[]>(options);
    }

    
}