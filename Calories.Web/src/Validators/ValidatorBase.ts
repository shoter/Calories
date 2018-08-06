import { ValidationError } from "./ValidationError";
import { ValidationResult } from "./ValidationResult";



export abstract class ValidatorBase 
{

    constructor()
    {
    }

    abstract validate(validatedObject: any) : ValidationResult;
}