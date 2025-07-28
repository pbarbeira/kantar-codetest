import BookAPI from "../API/BookAPI";

export default class BookCmd {
  static async GetBooks(){
    return await BookAPI.GetAll();
  }

  static SaveBook(book, successCallback, errorCallback){
    BookAPI.AddOrUpdateBook(book)
    .then(result => successCallback(result))
    .catch(e => errorCallback(e))
  }

  static async BorrowBook(bookCode, userCode, successCallback, errorCallback){
    BookAPI.BorrowBook(bookCode, userCode )
      .then(result => successCallback(result))
      .catch(e => errorCallback(e))
  }

  static async DeliverBook(bookCode, userCode, successCallback, errorCallback){
    BookAPI.DeliverBook(bookCode, userCode)
    .then(result => successCallback(result))
    .catch(e => errorCallback(e))
  }

  static DeleteBook(bookCode, successCallback, errorCallback){
    BookAPI.DeleteBook(bookCode)
      .then(result => successCallback(result))
      .catch(e => errorCallback(e))
  }
}