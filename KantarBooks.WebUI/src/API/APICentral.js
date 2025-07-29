const host = "http://localhost";
const port = 5000;

const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1MTYyMzkwMjJ9.xbdL7b8XRYCyJ4j8IpD3EXnwYoiX7MU1lgYp0Z9vltk"

export default class API {
  static async Get(route){
    const res = await fetch(`${host}:${port}/${route}`, {
      method: 'GET',
      headers: { 
        'Authorization': `Bearer ${token}`,
      },
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
        'Authorization': `Bearer ${token}`,
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
      method: 'DELETE',
      headers: { 
        'Authorization': `Bearer ${token}`,
      }, 
    });
    if (!res.ok){
      throw new Error(`Error ${res.status}`);
    }
  }
}