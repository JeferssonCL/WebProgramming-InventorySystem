import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { AuthForm } from "../components/AuthForm.jsx";
import "../styles/components/auth.css";

export function Login({ onLogin }) {
  const navigate = useNavigate();
  const [errorMessage, setErrorMessage] = useState("");
  const [invalidFields, setInvalidFields] = useState([]);

  const handleLogin = async (event) => {
    event.preventDefault();
    const formData = {
      email: event.target.email.value,
      password: event.target.password.value,
    };

    try {
      const response = await axios.post("http://localhost:5163/api/login", formData);
      if (response.status === 200) {
        onLogin();
      }
    } catch (error) {
      console.error("Login failed:", error);
      setErrorMessage("Email or password invalid");
      setInvalidFields(["email", "password"]);
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
      invalidFields={invalidFields}
    />
  );
}
