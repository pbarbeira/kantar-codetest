import { useEffect, useState } from "react";
import BookCmd from "../../Command/BookCmd";
import BookList from "./BookList";
import BookModal from "../Modals/BookModal";
import BorrowModal from "../Modals/BorrowModal";
import DeleteModal from "../Modals/DeleteModal";
import MessageModal from "../Modals/MessageModal";

const BOOK_MODAL = 'create-modal'
const BORROW_MODAL = 'borrow-modal'
const DELETE_MODAL = 'delete-modal'
const SUCCESS_MSG = 'success-msg'
const FAILURE_MSG = 'failure-msg'

const LibraryDashboard = () =>{
  const [bookList, setBookList] = useState([]);
  const [show, setShow] = useState("");
  const [form, setForm] = useState({});
  const [message, setMessage] = useState({});

  useEffect(()=>{
    const fetchBooks = async ()=>{
      try{
        const books = await BookCmd.GetBooks();
        setBookList(books);
      }catch(e){
        console.log(e)
      };
    }
    fetchBooks();
  }, [])

  const setSuccessMessage = (successMsg) => {
    setMessage(successMsg);
    setShow(SUCCESS_MSG)
  }

  const setFailureMessage = (errorMsg) => {
    setMessage(errorMsg);
    setShow(FAILURE_MSG)
  }

  const updateBookList = (book, 
    notFoundCallback = ()=>{ throw new Error(`Error: book does not exit!`) }
  ) => {
    const idx = bookList.findIndex(x => x.code === book.code);
    if(idx !== -1){
      bookList[idx] = book;
    }else{
      notFoundCallback();
    }
    setBookList([...bookList]);
  }

  const onBookSaveClick = (book) => {
    BookCmd.SaveBook(book,
      (result) => {
        updateBookList(result, 
          () => bookList.push(result)
        )
        setSuccessMessage("Book was successfully saved!");
      }, 
      (e) => setFailureMessage(`There was an error saving the book: ${e.message}`)
    );
  }

  const onBorrowSaveClick = (bookCode, userCode) => {
    BookCmd.BorrowBook(bookCode, userCode, 
      (result) => {
        updateBookList(result)
        setSuccessMessage("Book was successfully borrowed!");
      }, 
      (e) => setFailureMessage(`There was an error borrowing the book: ${e.message}`)
    )
  }

  const onDeliverSaveClick = (bookCode, userCode) => {
    BookCmd.DeliverBook(bookCode, userCode, 
      (result) => {
        updateBookList(result)
        setSuccessMessage("Book was successfully borrowed!");
      }, 
      (e) => setFailureMessage(`There was an error borrowing the book: ${e.message}`)
    )
  }

  const onDeleteSaveClick = (bookCode) => {
    BookCmd.DeleteBook(bookCode, 
      (result) => {
        setBookList([...bookList.filter(x => x.code !== result)]);
        setSuccessMessage("Book was successfully deleted!");
      },
      (e) => {
        setFailureMessage(`There was an error deleting the book: ${e.message}`);
      });
  }

  const onCreateBookClick = () => {
    setForm({
      Id: 0,
      Title: "",
      Code: "",
      Author: {},
      Publisher: {},
      Borrower: ""
    });
    setShow(BOOK_MODAL);
  }

  const onUpdateBookClick = (book) => {
    setShow(BOOK_MODAL);
    setForm({
      Id: book.id,
      Title: book.title,
      Code: book.code,
      Author: book.author,
      Publisher: book.publisher
    });
  }

  const onBorrowBookClick = (book) =>{
    setForm({
      Id: book.id,
      Title: book.title,
      BookCode: book.code,
      Borrower: book.borrower !== undefined ? book.borrower.code : ""
    })
    setShow(BORROW_MODAL);
  }

  const onDeleteBookClick = (book) =>{
    setForm({
      Code: book.code,
      Borrower: ""
    })
    setShow(DELETE_MODAL);
  }

  const onModalClose = () => {
    setShow("");
  }

  return(
      <>
        <BookList
          Books={bookList}
          OnCreateBookClick={onCreateBookClick}
          BookItemActions={{
            OnUpdateBookClick: onUpdateBookClick,
            OnBorrowBookClick: onBorrowBookClick,
            OnDeleteBookClick: onDeleteBookClick
          }}
        />

        <BookModal 
          Show={show === BOOK_MODAL}
          FormData={form}
          Title={form.Name === '' ? 'Create Book' : 'Update Book'}
          OnSaveClick={onBookSaveClick}
          OnHide={onModalClose}
        />
        <BorrowModal 
          Show={show === BORROW_MODAL}
          FormData={form}
          OnSaveBorrowClick={onBorrowSaveClick}
          OnSaveDeliverClick={onDeliverSaveClick}
          OnHide={onModalClose}
        />
        <DeleteModal 
          Show={show === DELETE_MODAL}
          Code={form.Code}
          OnDeleteClick={onDeleteSaveClick}
          OnHide={onModalClose}
        />
        <MessageModal
          Show={show === SUCCESS_MSG || show == FAILURE_MSG}
          Message={message}
          OnHide={onModalClose}
        />
      </>
  )
}

export default LibraryDashboard;