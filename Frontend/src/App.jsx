import './App.css'
import { Header } from './components/Header'
import { Home } from './pages/Home'
import { Route, Routes, BrowserRouter } from 'react-router-dom'
import { ProductDetail } from './pages/ProductDetail'
import CompleteOrder from './pages/CompleteOrder'
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { ProductsProvider } from './context/ProductsContext'


function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <ProductsProvider>
        <BrowserRouter>
          <Header />  
          <Routes>
            <Route path='/' element={<Home />} />
            <Route path="/product/:id" element={<ProductDetail />} />
            <Route path="/complete-order" element={<CompleteOrder />} />
          </Routes>
        </BrowserRouter>
      </ProductsProvider>
    </LocalizationProvider>
  )
}

export default App;
