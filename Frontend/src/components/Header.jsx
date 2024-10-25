import { useContext } from "react"
import "../styles/components/header.css"
import { Link, useNavigate } from "react-router-dom";
import { ShoppingCart } from "./ShoppingCart";
import { useAuth } from "../Context/AuthContext";
import { auth } from "../config/firebase";
import { signOut } from "firebase/auth";

export function Header() {
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
            <ShoppingCart/>
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
