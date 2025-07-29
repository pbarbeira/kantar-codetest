import API from "./APICentral"

const apiRoute = 'api/Book'

export default class BookAPI {
  static async GetAll(){
    return await API.Get(apiRoute);
  }

  static async AddOrUpdateBook(book){
    console.log(book);
    return await API.Post(apiRoute, book);
  }

  static async BorrowBook(bookCode, userCode){
    return await API.Post(`${apiRoute}/${bookCode}/borrow`, userCode);
  }

  static async DeliverBook(bookCode, userCode){
    return await API.Post(`${apiRoute}/${bookCode}/deliver`, userCode);
  }

  static async DeleteBook(bookCode){
    return await API.Delete(`${apiRoute}/${bookCode}`);
  }
}