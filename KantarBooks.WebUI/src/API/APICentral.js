const host = "http://localhost";
const port = 5000;

export default class API {
  static async Get(route){
    const res = await fetch(`${host}:${port}/${route}`, {
      method: 'GET'
    });
    if(!res.ok){
      throw new Error(res.statusText);
    }
    return res.json();
  }

  static async Post(route, body){
    const res = await fetch(`${host}:${port}/${route}`, {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json' 
      },
      body: JSON.stringify(body)
    });
    if (!res.ok) {
      throw new Error(`Error ${res.status}`);
    }
    return res.json();
  }

  static async Delete(route){
    const res = await fetch(`${host}:${port}/${route}`, { 
      method: 'DELETE' 
    });
    if (!res.ok){
      throw new Error(`Error ${res.status}`);
    }
  }
}