import { useContext, useEffect, useState } from "react";
import { Button, Form, Modal } from "react-bootstrap";
import { DataContext } from "../../DataContext";

const BookModal = ({Show, Title, FormData, OnSaveClick, OnHide}) => {
  const {authors, publishers } = useContext(DataContext);

  const [id, setId] = useState(0);
  const [title, setTitle] = useState("");
  const [author, setAuthor] = useState({});
  const [publisher, setPublisher] = useState({});
  const [errorFlags, setErrorFlags] = useState({
    title: false,
    author: false,
    publisher: false
  });

  useEffect(() => {
    if(FormData){
      setId(FormData.Id || 0);
      setTitle(FormData.Title || "");
      setAuthor(FormData.Author || {});
      setPublisher(FormData.Publisher || {});
      resetFlags();
    }
  }, [FormData]);

  const onNameChange = (name) => {
    setErrorFlags(flags => ({
      ...flags,
      title: false
    }));
    setTitle(name);
  }

  const onAuthorChange = (authorIdx) => {
    const author = authors[authorIdx];
    setErrorFlags(flags => ({
      ...flags,
      author: false
    }));
    setAuthor(author);
  }

  const onPublisherChange = (publisherIdx) => {
    const publisher = publishers[publisherIdx];
    setErrorFlags(flags => ({
      ...flags,
      publisher: false
    }));
    setPublisher(publisher);
  }

  const checkFlags = (flags) => {
    return flags.title || flags.author || flags.publisher;
  }

  const resetFlags = () => {
    setErrorFlags({
      title: false,
      author: false,
      publisher: false
    })
  }

  const onSave = () =>{
    const flags = {
      title: title === "",
      author: Object.keys(author).length === 0,
      publisher: Object.keys(publisher).length === 0 
    }
    if(checkFlags(flags)){
      setErrorFlags(flags);
      return;
    }
    const form = {
      Id: id,
      Title: title,
      Author: author,
      Publisher: publisher,
      Borrowed: false
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
              <Form.Label className="m-1">Book Title:</Form.Label>
              <Form.Control type="text"
                placeholder="Enter book title"
                value={title}
                onChange={(e)=>{ onNameChange(e.target.value) }} 
              />
              {errorFlags.title ? 
                <div className="book-modal-error">
                  Book must have a title!
                </div>
              : <></>}
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
              {errorFlags.author ? 
                <div className="book-modal-error">
                  Book must have an author!
                </div>
              : <></>}
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
              {errorFlags.publisher ? 
                <div className="book-modal-error">
                  Book must have a publisher!
                </div>
              : <></>}
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