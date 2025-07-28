import { Button, Col, Row } from "react-bootstrap";
import { MdEdit, MdDelete, MdCloudUpload, MdCloudDownload } from "react-icons/md";

const BookItem = ({Data, RowClass, Actions}) => {
  return(
    <Row className = {`${RowClass} padding-top-5px padding-bot-5px`}>
      <Col xs = {6} md = {3} lg={3} xl={2} >{Data.code}</Col>
      <Col xs = {0} md = {6} lg={4} xl={4} className="d-none d-md-block text-truncate">{Data.name}</Col>
      <Col xs = {0} md = {0} lg={3} xl={2} className="d-none d-lg-block">{Data.author.name}</Col>
      <Col xs = {0} md = {0} lg={0} xl={2} className="text-truncate d-none d-xl-block">{Data.publisher.name}</Col>
      <Col xs = {6} md = {3} lg={2} xl={2}>
        <Row className="align-items-center">
          <Col xs={4}></Col>
          <Col xs={2} className="g-0">
            <Button 
              variant="link"
              className="p-0"
              onClick={() => Actions.OnBorrowBookClick(Data)} size="sm">
              {Data.borrower === undefined ? 
                <MdCloudDownload size={24}/> 
                : 
                <MdCloudUpload size={24}/>}
            </Button>
          </Col>
          <Col xs={1}></Col>
          <Col xs={2} className="g-0">
            <Button variant="link"
              className="p-0"
              onClick={() => Actions.OnUpdateBookClick(Data)} size="sm">
              <MdEdit size={24}/>
            </Button>
          </Col>
          <Col xs={2} className="g-0">
            <Button variant="link" 
              className="p-0" 
              onClick={() => Actions.OnDeleteBookClick(Data)} size="sm">
              <MdDelete size={24}/>
            </Button>
          </Col>
        </Row>
      </Col>
    </Row>
  )
}

export default BookItem;