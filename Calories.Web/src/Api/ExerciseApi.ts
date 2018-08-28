import { CaloriesApiBase } from "./CaloriesApiBase";
import rp from "request-promise-native"
import { HttpMethod } from "./HttpMethod";
import { ExerciseType } from "../Models/ExerciseType";

export class ExerciseApi extends CaloriesApiBase 
{
   constructor()
   {
       super("Exercise");
   } 

   InsertExercise(date: Date, exerciseTypeID: Number, calories: Number) : rp.RequestPromise
   {
       var options = this.createBaseOptions(HttpMethod.POST);

       options.body = {
           date: date,
           exerciseTypeID: exerciseTypeID,
           calories: calories
       }

       return rp(options);
   }

   GetAllExerciseTypes() : Promise<ExerciseType[]>
   {
       var options = this.createBaseOptions(HttpMethod.GET, "Types");

       return this.createPromiseRequest<ExerciseType[]>(options);
   }
}