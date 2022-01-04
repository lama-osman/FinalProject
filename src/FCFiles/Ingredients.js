import { React, useState } from 'react';
import { Button } from 'react-bootstrap';
const apiUrl = 'http://localhost:64311/api/Ingredients';
export default function Ingredients() {
    const [values, setValues] = useState({ name: '', image: '', calories: 0 });

    const btnPost = () => {
        setValues({ name: values.name, image : values.image, calories : values.calories});

        console.clear();
        const s = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
            Ingredient_name: values.name,
            Image_url: values.image,
            calories: values.calories
        };

        fetch(apiUrl, {
            method: 'POST',
            body: JSON.stringify(s),
            headers: new Headers({
                'Content-type': 'application/json; charset=UTF-8', //very important to add the 'charset=UTF-8'!!!!
                'Accept': 'application/json; charset=UTF-8'
            })
        })
            .then(res => {
                console.log('res=', res);
                return res.json()
            })
            .then(
                (result) => {
                    console.log("fetch POST= ", result);
                },
                (error) => {
                    console.log("err post=", error);
                });

    }


    const chgName = (nameV) => {
        setValues({ name: nameV, image : values.image, calories : values.calories});
    }
    const chgImage = (imageV) => {
        setValues({ name:values.name , image : imageV, calories : values.calories});
    }
    const chgCalories = (caloriesV) => {
        setValues({ name:values.name,  image : values.image, calories : parseInt(caloriesV) });
    }

    return (
        <div>
            <h1><b>Ingredients</b></h1>
            <form>
                <label>Name : </label>
                <input type="text" onChange={(e) => chgName(e.target.value)}></input><br />
                <label>Image url : </label>
                <input type="text" onChange={(e) => chgImage(e.target.value)}></input><br />
                <label>Calories : </label>
                <input type="number" onChange={(e) => chgCalories(e.target.value)}></input><br />
                <Button variant="info" onClick={btnPost}>Add</Button>
            </form>

        </div>
    )
}
