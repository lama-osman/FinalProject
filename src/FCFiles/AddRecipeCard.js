import {React, useState} from 'react';
import { Card, Col, Button } from 'react-bootstrap';
import GetIngredientsInRecipes from './GetIngredientsInRecipes';
function AddRecipeCard(props) {
  console.log("ADDCard ", props.card)
  const [value, setValue] = useState(false);

  const ShowCard = () => {
    console.log("show func"+props.card.Recipe_id);
    setValue(true);
  }
  return (
    <div>
      <Col key={props.card.Recipe_id} style={{ padding: 5 }}>
        <Card style={{ width: '18rem', fontSize: 14, color: 'black' }} key={props.card.Recipe_id}>
          <Card.Img variant="top" src={props.card.Image_url} style={{ height: '190px', width: '286px' }} />
          <Card.Body>
            <Card.Title>{props.card.Recipe_name}</Card.Title>
            <Card.Text>
              {props.card.CookingMethod}
              {props.card.Time}
            </Card.Text>
            <Button variant="info" value={props.card.Recipe_id} key={props.card.Recipe_id} onClick={ShowCard}>Show Ingredients</Button>
          </Card.Body>
        </Card>
      </Col>
      {value ? <GetIngredientsInRecipes id={props.card.Recipe_id} dis={true}></GetIngredientsInRecipes> : null}

    </div>);
}
export default AddRecipeCard;