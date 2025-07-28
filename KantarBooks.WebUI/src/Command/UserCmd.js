import UserAPI from "../API/UserAPI";

export default class UserCmd {
  static async GetAuthors(){
    return await UserAPI.GetAuthors();
  }

  static async GetPublishers(){
    return await UserAPI.GetPublishers();
  }
}