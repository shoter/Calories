import { ApiBase } from "./ApiBase";

export class CaloriesApiBase extends ApiBase {
    constructor(controllerName: string) {
        const url : string = (process.env.REACT_APP_BACKEND_HOST as string); 
        super("http://localhost:9999/", controllerName); 
    }
}