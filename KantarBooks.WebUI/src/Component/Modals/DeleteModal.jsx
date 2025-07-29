import { Button, Modal } from "react-bootstrap";

const DeleteModal = ({Show, Id, OnDeleteClick, OnHide}) => {
  return(
    <Modal show={Show} onHide={OnHide}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Modal</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure you want to delete this book?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={()=>{ OnDeleteClick(Id) }}>
            Yes
          </Button>
          <Button variant="primary" onClick={OnHide}>
            No
          </Button>
        </Modal.Footer>
    </Modal>
  )
}

export default DeleteModal;