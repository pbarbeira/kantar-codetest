import { Button, Modal } from "react-bootstrap";

const MessageModal = ({Show, Message, OnHide}) =>{
  return(
    <Modal show={Show} onHide={OnHide}>
        <Modal.Header closeButton>
          <Modal.Title>Info</Modal.Title>
        </Modal.Header>
        <Modal.Body>{Message}</Modal.Body>
        <Modal.Footer>
          <Button variant="primary" onClick={OnHide}>
            OK
          </Button>
        </Modal.Footer>
    </Modal>
  )
}

export default MessageModal;