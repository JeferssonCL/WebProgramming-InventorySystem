import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { auth } from "../config/firebase";
import { createUserWithEmailAndPassword, updateProfile } from "firebase/auth";
import { AuthForm } from "../components/AuthForm";
import "../styles/components/auth.css";
import axios from "axios";

export function Signup() {
  const navigate = useNavigate();
  const [errorMessage, setErrorMessage] = useState("");
  const [fieldErrors, setFieldErrors] = useState({});

  const validateForm = (formData) => {
    const errors = {};

    if (!formData.name?.trim()) {
      errors.username = "Name is required";
    }

    if (!formData.email?.trim()) {
      errors.email = "Email is required";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      errors.email = "Please enter a valid email";
    }

    if (!formData.password?.trim()) {
      errors.password = "Password is required";
    } else if (formData.password.length < 6) {
      errors.password = "Password must be at least 6 characters long";
    }

    if (!formData.confirmPassword?.trim()) {
      errors.confirmPassword = "Confirm your password";
    } else if (formData.password !== formData.confirmPassword) {
      errors.confirmPassword = "Passwords do not match";
    }

    return errors;
  };

  const handleSignup = async (event) => {
    event.preventDefault();
    const formData = {
      name: event.target.name.value,
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
      const userCredential = await axios.post('http://localhost:5163/api/auth/signup', {
        name: formData.name,
        email: formData.email,
        password: formData.password
      })


      alert("Account created successfully!");
      navigate("/");
    } catch (error) {
      let errorMsg = "Failed to create account";

      switch (error.code) {
        case "auth/email-already-in-use":
          errorMsg = "An account with this email already exists";
          break;
        case "auth/operation-not-allowed":
          errorMsg = "Email and password registration is not enabled";
          break;
        case "auth/weak-password":
          errorMsg = "The password is too weak";
          break;
        default:
          errorMsg = "An unexpected error occurred. Please try again.";
      }

      setErrorMessage(errorMsg);
      setFieldErrors({});
    }
  };

  const handleSocialLoginSuccess = (user) => {
    navigate("/");
  };

  const handleSocialLoginError = (error) => {
    setErrorMessage("Failed to register with social network");
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
      onSocialLoginSuccess={handleSocialLoginSuccess}
      onSocialLoginError={handleSocialLoginError}
    />
  );
}
