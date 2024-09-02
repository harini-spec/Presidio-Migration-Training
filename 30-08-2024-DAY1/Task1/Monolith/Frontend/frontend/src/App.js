import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomeComponent from './Components/HomeComponent';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';

function App() {
  return (
    <div className="App">
            <BrowserRouter>
                <Routes>
                  <Route path="/" element={<HomeComponent/>}/>
                </Routes> 
            </BrowserRouter>
    </div>
  );
}

export default App;
