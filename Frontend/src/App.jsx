import './App.css'
import { Header } from './components/Header'
import { Home } from './pages/Home'
import { Route, Routes, BrowserRouter } from 'react-router-dom'
import { ProductDetail } from './pages/ProductDetail'
import CompleteOrder from './pages/CompleteOrder'
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { ProductsProvider } from './context/ProductsContext'

import { useState, useEffect } from 'react'
import PaymentStatusSuccess from './pages/PaymentStatusSuccess'
import PaymentStatusFailed from './pages/PaymentStatusSuccess'

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
            <Route path="/payment_transaction/success" element={<PaymentStatusSuccess />} />
            <Route path="/payment_transaction/failed" element={<PaymentStatusFailed />} />
          </Routes>
        </BrowserRouter>
      </ProductsProvider>
    </LocalizationProvider>
  )
}

export default App;
