import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Modal, Row } from "react-bootstrap";

const BorrowModal = ({Show, FormData, OnSaveBorrowClick, OnSaveDeliverClick, OnHide}) => {
  const [bookName, setBookName] = useState("");
  const [bookCode, setBookCode] = useState("");
  const [borrowerCode, setBorrowerCode] = useState("");
  const [userCode, setUserCode] = useState("");
  const [borrowFlag, setBorrowFlag] = useState(true);
   const [errorFlag, setErrorFlag] = useState(false);

  useEffect(() => {
    if(Object.keys(FormData).length > 0){
      setBookName(FormData.Name)
      setBookCode(FormData.BookCode || "");
      setBorrowerCode(FormData.Borrower.code);
      setBorrowFlag(FormData.Borrower === "");
    }
  }, [FormData]);
  
  const onUserCodeChange = (userCode)=>{
    setUserCode(userCode);
    setErrorFlag(false);
  }

  const onSaveChanges = () => {   
    if(borrowFlag){
      OnSaveBorrowClick(bookCode, userCode);
    }else{
      if(userCode !== borrowerCode){
        setErrorFlag(true);
        return;
      }
      OnSaveDeliverClick(bookCode, userCode);
    }
    OnHide();
  }


  return(
    <Modal show={Show} onHide={OnHide}>
        <Modal.Header closeButton>
          <Modal.Title>{borrowFlag ? "Borrow Book" : "Deliver Book"}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Container fluid>
            <Row>
              <Col>{bookCode}</Col>
              <Col>{bookName}</Col>
            </Row>
            <Form>
              <Form.Group>
                <Row className="align-items-center">
                  <Col xs={4}>
                    <Form.Label>User: </Form.Label>
                  </Col>
                  <Col xs={8}>
                    <Form.Control type="text"
                      placeholder="Enter user code"
                      value={userCode}
                      onChange={(e)=> onUserCodeChange(e.target.value)}
                    />
                    {errorFlag ? <div className="borrow-error-msg">Wrong user code!</div> : ''}
                  </Col>
                </Row>
              </Form.Group>
            </Form>
          </Container>

        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={OnHide}>
            Close
          </Button>
          <Button variant="primary" onClick={onSaveChanges}>
            Save Changes
          </Button>
        </Modal.Footer>
    </Modal>
  )
}

export default BorrowModal;