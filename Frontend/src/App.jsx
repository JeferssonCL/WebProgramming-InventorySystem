import './App.css'
import { Header } from './components/Header'
import { Home } from './pages/Home'
import { Login } from './pages/Login'
import { Signup } from './pages/Signup'
import { Route, Routes, BrowserRouter, Navigate } from 'react-router-dom'
import { ProductDetail } from './pages/ProductDetail'
import CompleteOrder from './pages/CompleteOrder'
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { ProductsProvider } from './context/ProductsContext'

import { useState, useEffect } from 'react'
import PaymentStatusSuccess from './pages/PaymentStatusSuccess'
import PaymentStatusFailed from './pages/PaymentStatusSuccess'
import { AuthProvider } from './Context/AuthContext'
import { PrivateRoute } from './Context/PrivateRoute'

function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <ProductsProvider>
        <BrowserRouter>
          <AuthProvider>
            <Header
              cartList={shoppingCartList}
              removeToList={handleRemoveFromCart}
              increaseQuantity={handleIncreaseQuantity}
              decreaseQuantity={handleDecreaseQuantity}
            />
            <Routes>
              <Route path='/' element={<Home addToCart={handleAddToCart} />} />
              <Route path="/product/:id" element={<ProductDetail />} />
              <Route path="/login" element={<Login />} />
              <Route path="/signup" element={<Signup />} />
              <Route
                path="/payment_transaction/success"
                element={
                  <PrivateRoute>
                    <PaymentStatusSuccess />
                  </PrivateRoute>
                }
              />
              <Route
                path="/payment_transaction/failed"
                element={
                  <PrivateRoute>
                    <PaymentStatusFailed />
                  </PrivateRoute>
                }
              />
              <Route
                path="*"
                element={<Navigate to="/" replace />}
              />
            </Routes>
          </AuthProvider>
        </BrowserRouter>
      </ProductsProvider>
    </LocalizationProvider>
  )
}

export default App;
