import { React, useState, useEffect } from 'react'
import AddRecipeCard from './AddRecipeCard';
const apiUrl = 'http://localhost:64311/api/Recipes';

export default function Home() {
    const [value, setValue] = useState(null);
    useEffect(() => {
        fetch(apiUrl, {
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
                    console.log("fetch btnFetchGetStudents= ", result);
                    result.map(st => console.log(st.Name));
                    console.log('result[0].Name=', result[0].Name);
                    setValue(result.map(st => <AddRecipeCard card={st}></AddRecipeCard>));
                },
                (error) => {
                    console.log("err post=", error);
                });

    }, []);

    return (
        <div>
            <h1><b>Dishs</b></h1>
            {value}
        </div>
    )
}
