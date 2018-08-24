import { CaloriesApiBase } from "./CaloriesApiBase";
import rp from "request-promise-native";
import { HttpMethod } from "./HttpMethod";

export class WeightApi extends CaloriesApiBase {
    constructor() {
        super("weight");
    }

    InsertWeight(weight: Number, date: Date) : rp.RequestPromise<{}> {
        let options: rp.Options = this.createBaseOptions(HttpMethod.POST);

        options.body = {
            weight: weight,
            date: date
        };

       return rp(options);
    }

    HasWeightToday() : rp.RequestPromise<{}> {
        let option: rp.Options = this.createBaseOptions(HttpMethod.GET, "HasWeightToday");

        return rp(option);
    }

    GetWeight(date: Date) : Promise<Number | null> {
        let option: rp.Options = this.createBaseOptions(HttpMethod.GET, date.toUTCString());

        return this.createPromiseRequest<Number | null>(option);
    }
}
