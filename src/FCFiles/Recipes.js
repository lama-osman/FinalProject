import { Button } from 'react-bootstrap';
import { React, useState, useContext } from 'react';
import GetIngredientsCards from './GetIngredientsCards';
import { IngredientINRecipesContext } from './FContext';
import PostIngredientsInRecipes from './PostIngredientsInRecipes';
const apiUrl = 'http://localhost:64311/api/Recipes';


export default function Recipes(props) {
    const { arrs ,MakeArrNull} = useContext(IngredientINRecipesContext);
    console.log(arrs);
    const [values, setValues] = useState({ name: '', image: '', cookingMethod: '', time: 0 });
    const [idArr, setIdArr] = useState({ arr: [] });
    const [addR, setAddR] = useState(false);
    const [newId, setNewId] = useState();
    
    const btnPost = () => {
        setValues({ name: values.name, image: values.image, cookingMethod: values.cookingMethod });
        console.clear();
        const s = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
            Recipe_name: values.name,
            Image_url: values.image,
            CookingMethod: values.cookingMethod,
            Time: values.time
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
                    setNewId(result.Recipe_id);
                    setAddR(true);
                },
                (error) => {
                    console.log("err post=", error);
                });

    }



    const chgName = (nameV) => {
        setValues({ name: nameV, image: values.image, cookingMethod: values.cookingMethod, time: values.time });
    }
    const chgImage = (imageV) => {
        setValues({ name: values.name, image: imageV, cookingMethod: values.cookingMethod, time: values.time });
    }
    const chgCookingMethod = (cookingMethodV) => {
        setValues({ name: values.name, image: values.image, cookingMethod: cookingMethodV, time: values.time });
    }
    const chgTime = (timeV) => {
        setValues({ name: values.name, image: values.image, cookingMethod: values.cookingMethod, time: timeV });
    }

    const ingredientsId = (num) => {
        setIdArr({ arr: [...idArr.arr, num] });
    }

    return (
        
        <div>
            <h1><b>Recipes</b></h1>
            <form>
                <label>Name : </label>
                <input type="text" onChange={(e) => chgName(e.target.value)}></input><br />
                <label>Image url : </label>
                <input type="text" onChange={(e) => chgImage(e.target.value)}></input><br />
                <label>Cooking Method : </label>
                <input type="text" onChange={(e) => chgCookingMethod(e.target.value)}></input><br />
                <label>Time : </label>
                <input type="number" onChange={(e) => chgTime(e.target.value)}></input><br />
                <GetIngredientsCards sendData={ingredientsId} api={'Ingredients'} dis={false}></GetIngredientsCards>
                <Button variant="info" onClick={btnPost}>Add</Button>
                {addR ? arrs.map((per)=><PostIngredientsInRecipes ingredientId={per} recipeId={newId} ></PostIngredientsInRecipes>)  : null}
            </form>
        </div>
    )
}
