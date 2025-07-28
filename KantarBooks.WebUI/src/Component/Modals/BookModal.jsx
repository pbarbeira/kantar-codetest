import { useContext, useEffect, useState } from "react";
import { Button, Form, Modal } from "react-bootstrap";
import UserCmd from "../../Command/UserCmd";
import { DataContext } from "../../DataContext";

const BookModal = ({Show, Title, FormData, OnSaveClick, OnHide}) => {
  const {authors, publishers } = useContext(DataContext);

  const [name, setName] = useState("");
  const [code, setCode] = useState("");
  const [author, setAuthor] = useState({});
  const [publisher, setPublisher] = useState({});

  useEffect(() => {
    if(FormData){
      setName(FormData.Name || "");
      setCode(FormData.Code || "");
      setAuthor(FormData.Author || {});
      setPublisher(FormData.Publisher || {});
    }
  }, [FormData]);

  const onNameChange = (name) => {
    setName(name);
  }

  const onAuthorChange = (authorIdx) => {
    const author = authors[authorIdx];
    setAuthor(author);
  }

  const onPublisherChange = (publisherIdx) => {
    const publisher = publishers[publisherIdx];
    setPublisher(publisher);
  }

  const onSave = () =>{
    const form = {
      Name: name,
      Code: code,
      Author: author,
      Publisher: publisher
    }
    OnHide();
    OnSaveClick(form);
  }

  const authorIndex = authors.findIndex(x => x.code == author.code);
  const publisherIndex = publishers.findIndex(x => x.code == publisher.code);

  return(
    <Modal show={Show} onHide={OnHide}>
        <Modal.Header closeButton>
          <Modal.Title>{Title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="book-modal-name" className="pt-3">
              <Form.Label className="m-1">Book Name:</Form.Label>
              <Form.Control type="text"
                placeholder="Enter book name"
                value={name}
                onChange={(e)=>{ onNameChange(e.target.value) }} 
              />
            </Form.Group>
          
            <Form.Group controlId="book-modal-author" className="pt-3">
              <Form.Label className="m-1">Book Author:</Form.Label>
              <Form.Select aria-label="Select author"
                value={authorIndex}
                onChange={(e)=>{ onAuthorChange(e.target.value) }}
              >
                <option key="author-option-default" value={-1} disabled>Select an author...</option>
                {authors.map((author, idx) => (
                  <option key={`author-option-${idx}`} value={idx}>{author.name}</option>
                ))}
              </Form.Select>
            </Form.Group>

            <Form.Group controlId="book-modal-publisher" className="pt-3">
              <Form.Label className="m-1">Book Publisher:</Form.Label>
                <Form.Select aria-label="Select publisher"
                  value={publisherIndex}
                  onChange={(e)=>{ onPublisherChange(e.target.value) }}
                >
                  <option key="publisher-option-default" value={-1} disabled>Select a publisher...</option>
                  {publishers.map((publisher, idx) => (
                    <option key={`publisher-option-${idx}`} value={idx}>{publisher.name}</option>
                  ))}
                </Form.Select>
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={OnHide}>
            Close
          </Button>
          <Button onClick={onSave}>
            Save Changes
          </Button>
        </Modal.Footer>
    </Modal>
  )
}

export default BookModal;