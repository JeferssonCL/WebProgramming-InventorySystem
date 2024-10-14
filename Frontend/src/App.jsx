import './App.css'
import { Header } from './components/Header'
import { Home } from './pages/Home'
import { Route, Routes, BrowserRouter } from 'react-router-dom'
import { ProductDetail } from './pages/ProductDetail'

function App() {

  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path="/product/:id" element={<ProductDetail />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App