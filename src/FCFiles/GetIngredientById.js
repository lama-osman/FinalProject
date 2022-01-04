import { React, useState, useEffect } from 'react';
import AddIngredientCard from './AddIngredientCard';
import { Container, Row } from 'react-bootstrap';

const apiUrl = 'http://localhost:64311/api/Ingredients/';

export default function GetIngredientById(props) {
    const [value, setValue] = useState(null);
    useEffect(() => {
        fetch(apiUrl+props.id, {
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
                    setValue(<AddIngredientCard card={result} dis={props.dis}></AddIngredientCard>);
                },
            )

            
    },[]);

    

    return (
        <div>
            <Container>
                <Row>
                    <h1>Ingredients of recipe</h1>
                   {value}
                </Row>
            </Container>
        </div>
    )
}
