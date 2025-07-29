import { createContext, useEffect, useState } from "react";
import AgentCmd from "./Command/AgentCmd";

export const DataContext = createContext();

export const DataProvider = ({ children }) => {
  const [authors, setAuthors] = useState([]);
  const [publishers, setPublishers] = useState([])

  useEffect(()=>{
    const fetchAgents = async ()=>{
      try{
        const agents = await AgentCmd.GetAgents();
        setAuthors(agents.authors);
        setPublishers(agents.publishers);
      } catch(e){
        console.error(e);
      }
    }
    fetchAgents();
  }, [])

  return (
    <DataContext.Provider value={{ authors, publishers }}>
      {children}
    </DataContext.Provider>
  )
}