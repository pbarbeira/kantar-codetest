import API from "./APICentral";

const apiRoute = 'api/Agent'

export default class AgentAPI {
  static async GetAgents(){
    return await API.Get(`${apiRoute}`)
  }
}