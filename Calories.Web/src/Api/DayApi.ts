import { CaloriesApiBase } from "./CaloriesApiBase";
import rp from "request-promise-native";
import { HttpMethod } from "./HttpMethod";

export interface DaySummary 
{
    calories: number,
    exerciseCalories: number,
    allowedIntakeLeft: number
    weight? : number
};

export class DayApi extends CaloriesApiBase {
    constructor() {
        super("day");
    }

    GetSummary(date: Date) : Promise<DaySummary> {
        let option: rp.Options = this.createBaseOptions(HttpMethod.GET, date.toUTCString());

        return this.createPromiseRequest<DaySummary>(option);
    }
    
}