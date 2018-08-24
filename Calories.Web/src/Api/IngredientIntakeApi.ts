import { CaloriesApiBase } from "./CaloriesApiBase";
import { HttpMethod } from "./HttpMethod";
import rp from "request-promise-native";
import { IngredientIntake } from "../Models/IngredientIntake";

export class IngredientIntakeApi extends CaloriesApiBase {
    constructor() {
        super("IngredientIntake");
    }

   insertIngredientIntake(ingredientID: Number, date: Date, weight: Number) : rp.RequestPromise {
       var options = this.createBaseOptions(HttpMethod.POST);

       options.body = {
           ingredientID: ingredientID,
           date: date,
           weight: weight
       };

       return  rp(options);
   } 

   getIngredientIntakeForDay(date: Date) : Promise<IngredientIntake[]> {
       var options = this.createBaseOptions(HttpMethod.GET, date.toUTCString());

       return this.createPromiseRequest<IngredientIntake[]>(options);
   }
}