import { createContext, useEffect, useState } from "react";
import UserCmd from "./Command/UserCmd";

export const DataContext = createContext();

export const DataProvider = ({ children }) => {
  const [authors, setAuthors] = useState([]);
  const [publishers, setPublishers] = useState([])

  useEffect(()=>{
    const fetchAuthors = async ()=>{
      try{
        const authors = await UserCmd.GetAuthors();
        setAuthors(authors);
      } catch(e){
        console.error(e);
      }
    }
    const fetchPublishers = async()=>{
      try{
        const publishers = await UserCmd.GetPublishers();
        setPublishers(publishers);
      } catch(e){
        console.error(e);
      }
    }
    fetchAuthors();
    fetchPublishers();
  }, [])

  return (
    <DataContext.Provider value={{ authors, publishers }}>
      {children}
    </DataContext.Provider>
  )
}