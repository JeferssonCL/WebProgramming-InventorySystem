import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { AuthForm } from "../components/AuthForm.jsx";
import "../styles/components/auth.css";

export function Login({ onLogin }) {
  const navigate = useNavigate();
  const [errorMessage, setErrorMessage] = useState("");
  const [fieldErrors, setFieldErrors] = useState({});

  const validateForm = (email, password) => {
    const errors = {};
    
    if (!email.trim()) {
      errors.email = "Username or Email is required";
    }

    if (!password.trim()) {
      errors.password = "Password is required";
    } else if (password.trim().length < 6) {
      errors.password = "Password must be at least 6 characters";
    }

    return errors;
  };

  const handleLogin = async (event) => {
    event.preventDefault();
    const email = event.target.email.value;
    const password = event.target.password.value;

    const errors = validateForm(email, password);
    if (Object.keys(errors).length > 0) {
      setFieldErrors(errors);
      setErrorMessage("");
      return;
    }

    try {
      /**
       * The request to the backend should be implemented, this is provitional 
       */
      const response = await axios.post("http://localhost:5163/api/login", {
        email,
        password
      });
      
      if (response.status === 200) {
        onLogin();
      }
    } catch (error) {
      console.error("Login failed:", error);
      setErrorMessage("Email or password invalid");
      setFieldErrors({
        email: "",
        password: ""
      });
    }
  };

  const handleSwitchToSignup = () => {
    navigate("/signup");
  };

  return (
    <AuthForm 
      isLogin={true} 
      onSubmit={handleLogin} 
      onSwitchAuth={handleSwitchToSignup}
      errorMessage={errorMessage}
      fieldErrors={fieldErrors}
    />
  );
}
