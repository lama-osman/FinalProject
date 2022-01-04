import { React } from 'react';
const apiUrl = 'http://localhost:64311/api/IngredientsInRecipes';
export default function PostIngredientsInRecipes(props) {

        console.clear();
        console.log(props);
        const funcPost=()=>{
            const s = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
                IngredientId: props.ingredientId,
                RecipeId: props.recipeId
               
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
       

    return (
        <div>
            {funcPost()}         
        </div>
    )
}
