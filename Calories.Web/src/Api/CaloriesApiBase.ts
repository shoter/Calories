import { ApiBase } from "./ApiBase";

export class CaloriesApiBase extends ApiBase {
    constructor(controllerName: string) {
        super("http://10.144.78.142/", controllerName);
    }
}