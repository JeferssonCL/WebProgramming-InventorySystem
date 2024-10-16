import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { AuthForm } from "../components/AuthForm.jsx";
import "../styles/components/auth.css";

export function Signup() {
  const navigate = useNavigate();
  const [errorMessage, setErrorMessage] = useState("");
  const [invalidFields, setInvalidFields] = useState([]);

  const isValidEmail = (email) => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  };

  const handleSignup = async (event) => {
    event.preventDefault();
    const formData = {
      username: event.target.username.value,
      email: event.target.email.value,
      password: event.target.password.value,
      confirmPassword: event.target.confirmPassword.value,
    };

    if (formData.password !== formData.confirmPassword) {
      setErrorMessage("The passwords don't match");
      setInvalidFields(["confirmPassword"]);
      return;
    }

    if (!isValidEmail(formData.email)) {
      setErrorMessage("The email is invalid");
      setInvalidFields(["email"]);
      return;
    }

    try {
      const response = await axios.post("http://localhost:5163/api/signup", formData);
      if (response.status === 201) {
        alert("Signup successful! Please login.");
        navigate("/login");
      }
    } catch (error) {
      console.error("Signup failed:", error);
      setErrorMessage("Signup error. Try again.");
      setInvalidFields(["email"]);
    }
  };

  const handleSwitchToLogin = () => {
    navigate("/login");
  };

  return (
    <AuthForm
      isLogin={false}
      onSubmit={handleSignup}
      onSwitchAuth={handleSwitchToLogin}
      errorMessage={errorMessage}
      invalidFields={invalidFields}
    />
  );
}
