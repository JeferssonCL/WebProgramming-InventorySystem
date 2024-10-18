import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { auth } from "../config/firebase";
import { signInWithEmailAndPassword } from "firebase/auth";
import { AuthForm } from "../components/AuthForm";
import axios from "axios";
import "../styles/components/auth.css";

export function Login({ onLogin }) {
  const navigate = useNavigate();
  const [statusMessage, setStatusMessage] = useState({ type: '', message: '' });
  const [fieldErrors, setFieldErrors] = useState({});

  const validateForm = (email, password) => {
    const errors = {};

    if (!email.trim()) {
      errors.email = "Email is required";
    }

    if (!password.trim()) {
      errors.password = "Password is required";
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
      setStatusMessage({ type: '', message: '' });
      return;
    }

    try {
      const userCredential = axios.post('http://localhost:5163/api/auth/login', {
        email,
        password
      })
      .then(response => {
        console.log('Respuesta del servidor:', response.data);
      })
      .catch(error => {
        console.error('Error al realizar la solicitud:', error);
      });

      if (onLogin) onLogin(userCredential);
      navigate("/");
    } catch (error) {
      console.error("Login failed:", error);
      setStatusMessage({
        type: 'error',
        message: "Invalid email or password"
      });
      setFieldErrors({});
    }
  };

  const handleSocialLoginSuccess = (user) => {
    if (onLogin) onLogin(user);
    navigate("/");
  };

  const handleSocialLoginError = (error) => {
    console.error("Social login error:", error);
    setStatusMessage({ type: 'error', message: "Failed to log in with social network" });
  };

  const handleSwitchToSignup = () => {
    navigate("/signup");
  };

  return (
    <AuthForm
      isLogin={true}
      onSubmit={handleLogin}
      onSwitchAuth={handleSwitchToSignup}
      statusMessage={statusMessage}
      fieldErrors={fieldErrors}
      onSocialLoginSuccess={handleSocialLoginSuccess}
      onSocialLoginError={handleSocialLoginError}
    />
  );
}
