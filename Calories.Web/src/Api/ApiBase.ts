import { Options, RequestPromise } from "request-promise-native";
import urljoin from "url-join";
import { HttpMethod } from "./HttpMethod";
export class ApiBase {
  controllerName: string;
  baseUrl: string;
  constructor(baseUrl: string, controllerName: string) {
    this.controllerName = controllerName;
    this.baseUrl = baseUrl;
  }

  getUrl(): string {
    return urljoin(this.baseUrl, "api", this.controllerName);
  }

  createBaseOptions(method: HttpMethod): Options {
    let options: Options = {
      url: this.getUrl(),
      method: "post"
    };

    if (method != HttpMethod.GET) options.json = true;

    return options;
  }
}
