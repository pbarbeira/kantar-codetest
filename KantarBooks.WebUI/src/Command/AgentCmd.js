import AgentAPI from "../API/AgentAPI";

export default class AgentCmd {
  static async GetAgents(){
    return await AgentAPI.GetAgents();
  }
}