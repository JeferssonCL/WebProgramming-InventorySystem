import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { AuthForm } from "../components/AuthForm.jsx";
import "../styles/components/auth.css";

export function Signup() {
  const navigate = useNavigate();
  const [errorMessage, setErrorMessage] = useState("");
  const [fieldErrors, setFieldErrors] = useState({});

  const validateForm = (formData) => {
    const errors = {};

    if (!formData.username.trim()) {
      errors.username = "Username is required";
    } else if (!/^[a-zA-Z0-9_-]+$/.test(formData.username)) {
      errors.username = "Username can only contain letters, numbers, underscore and dash";
    }

    if (!formData.email.trim()) {
      errors.email = "Email is required";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      errors.email = "Please enter a valid email address";
    }

    if (!formData.password.trim()) {
      errors.password = "Password is required";
    } else {
      if (formData.password.length < 6) {
        errors.password = "Password must be at least 6 characters long";
      } else if (!/(?=.*[A-Z])/.test(formData.password)) {
        errors.password = "Password must contain at least one uppercase letter";
      } else if (!/(?=.*[0-9])/.test(formData.password)) {
        errors.password = "Password must contain at least one number";
      } else if (!/(?=.*[!@#$%^&*])/.test(formData.password)) {
        errors.password = "Password must contain at least one special character";
      }
    }

    if (!formData.confirmPassword.trim()) {
      errors.confirmPassword = "Please confirm your password";
    } else if (formData.password !== formData.confirmPassword) {
      errors.confirmPassword = "Passwords don't match";
    }

    return errors;
  };

  const handleSignup = async (event) => {
    event.preventDefault();
    const formData = {
      username: event.target.username.value,
      email: event.target.email.value,
      password: event.target.password.value,
      confirmPassword: event.target.confirmPassword.value,
    };

    const errors = validateForm(formData);
    if (Object.keys(errors).length > 0) {
      setFieldErrors(errors);
      setErrorMessage("");
      return;
    }

    try {
      /**
       * The request to the backend should be implemented, this is provitional 
       */
      const response = await axios.post("http://localhost:5163/api/signup", {
        username: formData.username,
        email: formData.email,
        password: formData.password
      });
      
      if (response.status === 201) {
        alert("Signup successful! Please login.");
        navigate("/login");
      }
    } catch (error) {
      console.error("Signup failed:", error);
      if (error.response?.data?.message) {
        setErrorMessage(error.response.data.message);
      } else {
        setErrorMessage("Signup failed. Please try again.");
      }
      setFieldErrors({});
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
      fieldErrors={fieldErrors}
    />
  );
}
