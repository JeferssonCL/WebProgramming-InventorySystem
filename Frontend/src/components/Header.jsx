import { useState } from "react"
import "../styles/components/header.css"
import { Link, useNavigate } from "react-router-dom";
import { ShoppingCart } from "./ShoppingCart";
import { useAuth } from "../Context/AuthContext";
import { auth } from "../config/firebase";
import { signOut } from "firebase/auth";

export function Header({ cartList, removeToList, increaseQuantity, decreaseQuantity }) {
  const { user } = useAuth();
  const navigate = useNavigate();

  const handleLogout = async () => {
    try {
      await signOut(auth);
      navigate('/');
    } catch (error) {
      console.error("Error signing out:", error);
    }
  };

  return (
    <header className="header">
      <img src="public/logo/s.png" alt="Merchant logo" />
      <div className="header-actions">
        {user ? (
          <>
            <ShoppingCart 
              shoppingCartList={cartList} 
              removeToList={removeToList} 
              increse={increaseQuantity} 
              decrese={decreaseQuantity} 
            />
            <button onClick={handleLogout} className="logout-button">
              Sign Out
            </button>
          </>
        ) : (
          <div className="auth-buttons">
            <Link to="/login" className="auth-button">Sign In</Link>
            <Link to="/signup" className="auth-button">Sign Up</Link>
          </div>
        )}
      </div>
    </header>
  );
}
