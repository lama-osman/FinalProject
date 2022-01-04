import {React,useContext} from 'react';
import { Card, Col, Button } from 'react-bootstrap';
import { IngredientINRecipesContext } from './FContext';

function AddIngredientCard(props) {
  const {AddItem} = useContext(IngredientINRecipesContext);
  console.log("ADDCard ", props.card)
 
  return (
    <div>
      <Col key={props.card.Ingredient_id} style={{ padding: 5 }}>
        <Card style={{ width: '18rem', fontSize: 14, color: 'black' }} key={props.card.Ingredient_id}>
          <Card.Img variant="top" src={props.card.Image_url} style={{ height: '190px', width: '286px' }} />
          <Card.Body>
            <Card.Title>{props.card.Ingredient_name}</Card.Title>
            <Card.Text>
              {props.card.Calories}
            </Card.Text>
            {props.dis ? null : <Button variant="info" value={props.card.Ingredient_id} key={props.card.Ingredient_id} onClick={()=>{AddItem(props.card.Ingredient_id)}}>add to recipe</Button>}
          </Card.Body>
        </Card>
      </Col>
    </div>);
}
export default AddIngredientCard;