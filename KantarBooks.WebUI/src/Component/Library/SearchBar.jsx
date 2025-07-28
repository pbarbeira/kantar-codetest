import { useState } from "react";
import { ButtonGroup, Col, Container, Form, Row, ToggleButton } from "react-bootstrap";
import { MdSearch } from "react-icons/md";

const SearchBar = (props) => {
  const [input, setInput] = useState("");
  const [filterOptions, setFilterOptions] = useState(
    props.FilterOptions !== undefined ? props.FilterOptions : {}
  );

  const onChangeInput = (input) => {
    props.SearchCallback(input);
    setInput(input);
  }

  const onChangeFilter = () => {
    console.log("hi");
  }

  return(
    <Container fluid>
      <Row className="align-items-center pb-2">
        <Col xs={5}>
          <Row className="align-items-center">
            <Col xs={2}>
              <MdSearch size={24}/>
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
        <Col xs={6}>
          <Row className="text-start">
            <Col>
              Title
            </Col>
            <Col>
              Author
            </Col>
            <Col xs={4}/>
          </Row>
        </Col>
      </Row>
    </Container>
  )
}

export default SearchBar;