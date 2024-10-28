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

import PaymentStatusSuccess from './pages/PaymentStatusSuccess'
import PaymentStatusFailed from './pages/PaymentStatusSuccess'
import { AuthProvider } from './Context/AuthContext'
import { PrivateRoute } from './Context/PrivateRoute'
import{Toaster} from 'sonner'
import {HomePage} from "./pages/HomePage.jsx";

function App() {

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Toaster richColors />
      <ProductsProvider>
        <BrowserRouter>
          <AuthProvider>
            <Header/>
            <Routes>
              <Route path='/' element={<Home/>} />
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
                path="/complete-order"
                element={
                  <PrivateRoute>
                    <CompleteOrder />
                  </PrivateRoute>
                }
              />
              <Route
                path="*"
                element={<Navigate to="/" replace />}
              />
              <Route
                path="/home-page"
                element={
                  <HomePage></HomePage>
                }
              />
            </Routes>
          </AuthProvider>
        </BrowserRouter>
      </ProductsProvider>
    </LocalizationProvider>
  );
}

export default App;
