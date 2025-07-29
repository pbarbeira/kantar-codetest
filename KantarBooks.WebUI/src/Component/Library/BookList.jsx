import { useState } from "react";
import BookItem from "./BookItem";
import SearchBar from "./SearchBar";
import { Button, Col, Container, Row } from "react-bootstrap";

const BookList = ({Books, OnCreateBookClick, BookItemActions}) => {
  const filterOptions = ["title", "author"]

  const [searchTerm, setSearchTerm] = useState("");
  const [filterAttribute, setFilterAttribute] = useState("title");

  const updateFilterCallback = (attribute) =>{
    setFilterAttribute(attribute);
  }

  const updateSearchCallback = (searchTerm) => {
    setSearchTerm(searchTerm);
  }


  const filterResult = (book) => {
    switch(filterAttribute){
      case 'title': return book.title.includes(searchTerm);
      case 'author': return book.author.name.includes(searchTerm);
    }
  }

  return(
    <div>
      <Container>
        <Row>
          <Col xs={10} className="ps-0">
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
            <Col xs = {6} md = {3} lg={3} xl={2}><h5>#Id</h5></Col>
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