import { useState } from "react";
import { Col, Container, Form, Row } from "react-bootstrap";
import { MdSearch } from "react-icons/md";

const SearchBar = ({FilterOptions, FilterCallback, SearchCallback}) => {
  const [input, setInput] = useState("");
  const [filter, setFilter] = useState("title");

  const onChangeInput = (input) => {
    SearchCallback(input);
    setInput(input);
  }

  const onChangeFilter = (e) => {
    setFilter(e);
    FilterCallback(e);
  };

  return(
    <Container fluid>
      <Row className="align-items-center pb-2">
        <Col xs={5}>
          <Row className="align-items-center">
            <Col xs={1} className="p-0 text-start">
              <MdSearch size={24} className="p-0"/>
            </Col>
            <Col className="m-0 p-0">
              <Form>
                <Form.Group>
                  <Form.Control type="text"
                    placeholder="Enter search term..."
                    value={input}
                    onChange={(e) => onChangeInput(e.target.value)}  
                  />
                </Form.Group>
              </Form>
            </Col>
          </Row>
        </Col>
        <Col xs={1}><b>Filter</b></Col>
        <Col xs={6}>
          <Form>
          <Row className="text-start">
              {FilterOptions.map((opt, idx) =>{
                return (
                  <Col key={`filter-option-${idx}`} xs={3} className="p-0">
                    <Form.Check
                      type="radio"
                      label={String(opt).charAt(0).toUpperCase() + String(opt).slice(1)}
                      name="filterRadio"
                      value={opt}
                      checked={opt === filter}
                      onChange={(e) => onChangeFilter(e.target.value)}
                    />
                  </Col>
                )
              })}

            </Row>
          </Form>
        </Col>
      </Row>
    </Container>
  )
}

export default SearchBar;