import React, { useCallback, useState } from 'react';
import {
  Container,
  Row,
  Col,
  Form,
  Button,
  Table
} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import api from '../../services/api';

function Home() {
  const[order, setOrder] = useState('');
  const[output, setOutput] = useState('');
  const[result, setResult] = useState([]);

  const handleOrder = useCallback(async () => {

    try {
      const response = await api.post(`orders?inputOrder=${order}`);

      setOutput(response.data);
  
      const resultInfo = {
        input: order,
        output: response.data,
      }
  
      result.push(resultInfo);
  
      setResult([...result]);
      setOrder('');
    } catch (error) {
      setOutput('Invalid order');
      setOrder('');
    }
   
  }, [order, output, setOutput, setOrder, setResult, result]);

  return (
    <Container>
      <Row>
        <Col md={{ span: 8, offset: 2 }}>
          <Row>
            <Col>
              <h1>Restaurant Order App</h1>
            </Col>
          </Row>
          <br ></br>
          <Row>
          <Col>
            <Form>
              <Form.Row>
                <Form.Group as={Col} md={4} controlId="formGridEmail">
                  <Form.Label>Your order</Form.Label>
                  <Form.Control type="text" placeholder="Place your order"
                       value={order}
                       onChange={e => setOrder(e.target.value)}
                  />
                </Form.Group>

                <Form.Group as={Col} controlId="formGridPassword">
                  <Form.Label>Outcome</Form.Label>
                  <Form.Control type="text" readOnly={true} 
                     value={output}
                     onChange={e => setOutput(e.target.value)}
                  />
                </Form.Group>
              </Form.Row>

              <Button variant="primary" type="button" onClick={handleOrder}>
                Submit
              </Button>
            </Form>
          </Col>
        </Row>
        <br ></br>
          <Row>
            <Col>
                 <Table striped bordered hover>
                    <thead>
                      <tr>
                        <th>Input</th>
                        <th>Output</th>
                      </tr>
                    </thead>
                    <tbody>
                      {result && result.map( info => (
                        <tr>
                          <td>{info.input}</td>
                          <td>{info.output}</td>
                        </tr>
                      ))}           
                    </tbody>
                  </Table>
            </Col>
          </Row>

        </Col>
      </Row>
    </Container>
  );
}

export default Home;
