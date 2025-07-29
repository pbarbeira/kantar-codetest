import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Modal, Row } from "react-bootstrap";

const BorrowModal = ({Show, FormData, OnSaveBorrowClick: OnBorrowSaveClick, OnSaveDeliverClick: OnDeliverSaveClick, OnHide}) => {
  const [id, setId] = useState("");
  const [title, setTitle] = useState("");
  const [borrowed, setBorrowed] = useState("");

  useEffect(() => {
    if(Object.keys(FormData).length > 0){
      setTitle(FormData.Title)
      setId(FormData.Id || "");
      setBorrowed(FormData.Borrowed);
    }
  }, [FormData]);
  

  const onSaveChanges = () => {   
    if(!borrowed){
      OnBorrowSaveClick(id);
    }else{
      OnDeliverSaveClick(id);
    }
    OnHide();
  }


  return(
    <Modal show={Show} onHide={OnHide}>
        <Modal.Header closeButton>
          <Modal.Title>{borrowed ? "Deliver Book" : "Borrow Book"}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Container fluid>
            <Row>
              <Col>{id}</Col>
              <Col>{title}</Col>
            </Row>
          </Container>

        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={OnHide}>
            Close
          </Button>
          <Button variant="primary" onClick={onSaveChanges}>
            {borrowed ? 'Deliver' : 'Borrow'}
          </Button>
        </Modal.Footer>
    </Modal>
  )
}

export default BorrowModal;