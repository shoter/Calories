import { ApiBase } from "./ApiBase";

export class CaloriesApiBase extends ApiBase {
    constructor(controllerName: string) {
        const url : string = (process.env.REACT_APP_BACKEND_HOST as string); 
        let ip = window.location.host.split(":")[0];
        let baseUrl = "http://" + ip + ":19999";
        super(baseUrl, controllerName); 
    }
}