import { CaloriesApiBase } from "./CaloriesApiBase";
import { SizeType } from "../Models/SizeType";
import { HttpMethod } from "./HttpMethod";

export class SizeApi extends CaloriesApiBase 
{
    constructor()
    {
        super("size");
    }

    GetSizeTypes() : Promise<SizeType[]>
    {
        var options = this.createBaseOptions(HttpMethod.GET, "SizeType");

        return this.createPromiseRequest(options);
    }

    GetSizeType(sizeTypeID: Number) : Promise<SizeType>
    {
        var options = this.createBaseOptions(HttpMethod.GET, "SizeType", sizeTypeID.toString());

        return this.createPromiseRequest(options);
    }
}