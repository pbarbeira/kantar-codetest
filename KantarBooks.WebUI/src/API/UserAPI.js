import API from "./APICentral";

const apiRoute = 'api/User'

export default class UserAPI {
  static async GetAuthors(){
    return await API.Get(`${apiRoute}/author`)
  }

  static async GetPublishers(){
    return await API.Get(`${apiRoute}/publisher`);
  }
}