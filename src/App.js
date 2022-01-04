import './App.css';
import Home from './FCFiles/Home';
import { Route, Routes } from 'react-router-dom';
import Header from './Header';
import Ingredients from './FCFiles/Ingredients';
import Recipes from './FCFiles/Recipes';
function App() {
  return (
    <div className="App">
       {Header}
      <header className="App-header">     
        <Routes>
           <Route path="/" element={<Home></Home>}></Route>
           <Route path="/ingredients" element={<Ingredients></Ingredients>}></Route>
           <Route path="/recipes" element={<Recipes></Recipes>}></Route>
        </Routes>
      </header>
    </div>
  );
}
export default App;
