import rp from "request-promise-native";
import urljoin from "url-join";
import { HttpMethod } from "./HttpMethod";
import { resolve } from "url";
export interface ApiPromise<T> extends Promise<T>
{

}

export class ApiBase {
  controllerName: string;
  baseUrl: string;
  constructor(baseUrl: string, controllerName: string) {
    this.controllerName = controllerName;
    this.baseUrl = baseUrl;
  }

  getUrl(...parts: string[]): string {
    return urljoin(this.baseUrl,  "api", this.controllerName, ...parts);
  }

  createBaseOptions(method: HttpMethod, ...urlParts: string[]): rp.Options {
    let options: rp.Options = {
      url: this.getUrl(...urlParts),
      method: method
    };

    if (method != HttpMethod.GET) options.json = true;

    return options;
  }



  createPromiseRequest<T>(options: rp.Options)
  {
    return new Promise<T>((resolve, reject) => {
        rp(options)
        .then((value:any) => {
           let t:T = JSON.parse(value); //Hack?
           resolve(t);
        })
        .catch(reject);
    });
    
  } 

}