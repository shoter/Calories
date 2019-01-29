import { ApiBase } from "./ApiBase";

export class CaloriesApiBase extends ApiBase {
    constructor(controllerName: string) {
        super("http://localhost:20510/", controllerName); 
    }
}