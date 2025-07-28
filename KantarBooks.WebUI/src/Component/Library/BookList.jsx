import { useState } from "react";
import BookItem from "./BookItem";
import SearchBar from "./SearchBar";
import { Button, Col, Container, Row } from "react-bootstrap";

const BookList = ({Books, OnCreateBookClick, BookItemActions}) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [filterOptions, setFilterOptions] = useState({
    publisher: false,
    author: false,
    name: true,
    exact: false,
  });

  const updateFilterCallback = (filterOptions) =>{
    setFilterOptions(filterOptions);
  }

  const updateSearchCallback = (searchTerm) => {
    setSearchTerm(searchTerm);
  }


  const matchAuthor = (book) => {
    return book.author.name.includes(searchTerm);
  }

  const matchTitle = (book) => {
    return book.name.includes(searchTerm);
  }

  const filterResult = (book) => {
    return matchAuthor(book) || matchTitle(book)
  }

  return(
    <div>
      <Container>
        <Row>
          <Col xs={10}>
            <SearchBar
              FilterOptions = {filterOptions}
              FilterCallback = {updateFilterCallback}
              SearchCallback = {updateSearchCallback}
            />
          </Col>
          <Col xs={2} className="text-end g-0">
            <Button onClick={OnCreateBookClick}>
              Create
            </Button>
          </Col>
        </Row>
      </Container>  
      <div>
        <Container fluid className="border rounded booklist-container">
          <Row className='list-header padding-top-5px'>
            <Col xs = {6} md = {3} lg={3} xl={2}><h5>Code</h5></Col>
            <Col xs = {0} md = {6} lg={4} xl={4} className="d-none d-md-block"><h5>Name</h5></Col>
            <Col xs = {0} md = {0} lg={3} xl={2} className="d-none d-lg-block"><h5>Author</h5></Col>
            <Col xs = {0} md = {0} lg={0} xl={2} className="d-none d-xl-block"><h5>Publisher</h5></Col>
            <Col xs = {6} md = {3} lg={2} xl={2}></Col>
          </Row>
          {Books.map((book, idx) => {
            if(searchTerm.length === 0 || filterResult(book)){
              return <BookItem
                RowClass={idx % 2 == 0 ? "list-item-even" : "list-item-odd"}
                key={`book-${idx}`}
                Data={book}
                Actions={BookItemActions}
              />
            }
          })}
        </Container>
      </div>
    </div>
  )
}

export default BookList;