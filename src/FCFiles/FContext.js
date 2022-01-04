import {React,  useState, createContext } from 'react';

export const IngredientINRecipesContext = createContext();

export default function FContext(props) {
    const [arrs, setArrs] = useState([]);
    const AddItem=(num)=>{
        setArrs([...arrs, num]);
    }

    const MakeArrNull=()=>{
       setArrs([])
    }
    return (
        <IngredientINRecipesContext.Provider value={{AddItem,arrs,MakeArrNull}}>
            {props.children}
        </IngredientINRecipesContext.Provider>
    )
}
