import { ValidatorBase } from "../ValidatorBase";
import { Ingredient } from "../../Models/Ingredient";
import { ValidationResult } from "../ValidationResult";

export class IngredientValidator extends ValidatorBase
{
    validate(ing: Ingredient) : ValidationResult
    {
        let result = ValidationResult.prototype.success;

        if(ing.name.length === 0)
           result.addError("Name is required!"); 

        return result;
    }
}