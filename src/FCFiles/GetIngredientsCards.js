import { React, useState, useEffect } from 'react';
import AddIngredientCard from './AddIngredientCard';
import { Container, Row } from 'react-bootstrap';

const apiUrl = 'http://localhost:64311/api/';

export default function GetIngredientsCards(props) {
    const [value, setValue] = useState(null);
    useEffect(() => {
        fetch(apiUrl+props.api, {
            method: 'GET',
            headers: new Headers({
                'Content-Type': 'application/json; charset=UTF-8',
                'Accept': 'application/json; charset=UTF-8'
            })
        })
            .then(res => {
                console.log('res=', res);
                console.log('res.status', res.status);
                console.log('res.ok', res.ok);
                return res.json()
            })
            .then(
                (result) => {
                    console.log("fetch Get Ingredients= ", result);
                    result.map(st => console.log(st.Ingredient_name));
                    setValue(result.map(st => <AddIngredientCard card={st} dis={props.dis}></AddIngredientCard>));
                },
            )

            
    },[]);

    

    return (
        <div>
            <Container>
                <Row>
                   {value}
                </Row>
            </Container>
        </div>
    )
}
