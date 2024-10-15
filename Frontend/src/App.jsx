import './App.css'
import { Header } from './components/Header'
import { Home } from './pages/Home'
import { Route, Routes, BrowserRouter } from 'react-router-dom'
import { ProductDetail } from './pages/ProductDetail'
import { useState, useEffect } from 'react'

function App() {

  const [shoppingCartList, setShoppingCartList] = useState([]);

  useEffect(() => {
    const storageData = localStorage.getItem('cart');
    setShoppingCartList(storageData ? JSON.parse(storageData) : [])
  }, []);

  const handleAddToCart = (product) => {
    const productToStore = {
      id: product.id,
      name: product.name,
      price: product.price,
      image: product.images,
    };

    const productExists = shoppingCartList.find(item => item.id === productToStore.id);
    if (!productExists) {
      const updatedCart = [...shoppingCartList, productToStore];
      setShoppingCartList(updatedCart);
      localStorage.setItem('cart', JSON.stringify(updatedCart));
    }
  };

  const handleRemoveFromCart = (id) => {
    const updatedCart = shoppingCartList.filter(item => item.id !== id);
    setShoppingCartList(updatedCart);
    localStorage.setItem('cart', JSON.stringify(updatedCart));
  };

  return (
    <BrowserRouter>
      <Header cartList={shoppingCartList} removeToList={handleRemoveFromCart} />
      <Routes>
        <Route path='/' element={<Home addToCart={handleAddToCart} />} />
        <Route path="/product/:id" element={<ProductDetail />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
