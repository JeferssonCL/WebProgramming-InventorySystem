import React, { useState } from "react";
import { FaFacebook } from "react-icons/fa";
import { FcGoogle } from "react-icons/fc";
import { AiFillEye, AiFillEyeInvisible } from "react-icons/ai";

export function AuthForm({ isLogin, onSubmit, onSwitchAuth, errorMessage, fieldErrors = {} }) {
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);

  const title = isLogin ? "LOGIN" : "SIGN UP";
  const buttonText = isLogin ? "LOGIN" : "SIGN UP";
  const socialText = isLogin ? "Or Login with" : "Or Sign up with";
  const switchText = isLogin ? "Don't have an account?" : "Already have an account?";
  const switchButtonText = isLogin ? "SIGN UP" : "LOGIN";

  return (
    <div className={`${isLogin ? 'login' : 'signup'}-container`}>
      <div className={`${isLogin ? 'login' : 'signup'}-sidebar`}>
        <div>
          <img 
            src="public/logo/m.png" 
            alt="Merchant logo" 
            className={`${isLogin ? 'login' : 'signup'}-logo`} 
          />
          <p className={`${isLogin ? 'login' : 'signup'}-welcome`}>
            {isLogin ? "WELCOME BACK!" : "WELCOME!"}
          </p>
          <p className={`${isLogin ? 'login' : 'signup'}-info`}>
            {isLogin
              ? "To keep connected with us please login with your personal info"
              : "Join us to find everything you need"}
          </p>
        </div>
        <div className={`${isLogin ? 'signup' : 'login'}-section`}>
          <p>{switchText}</p>
          <button onClick={onSwitchAuth} className={`${isLogin ? 'signup' : 'login'}-button`}>
            {switchButtonText}
          </button>
        </div>
      </div>
      <div className={`${isLogin ? 'login' : 'signup'}-form-container`}>
        <div className={`${isLogin ? 'login' : 'signup'}-form`}>
          <h2 className="form-title">{title}</h2>
          {errorMessage && <p className="form-error-message">{errorMessage}</p>}
          <form onSubmit={onSubmit} noValidate>
            {!isLogin && (
              <div className="form-field">
                <input 
                  type="text" 
                  name="username" 
                  placeholder="Username"
                  className={fieldErrors.username ? "input-error" : ""}
                />
                {fieldErrors.username && (
                  <span className="field-error-message">{fieldErrors.username}</span>
                )}
              </div>
            )}
            <div className="form-field">
              <input
                type="text"
                name="email"
                placeholder={isLogin ? "Username or Email" : "Email"}
                className={fieldErrors.email ? "input-error" : ""}
              />
              {fieldErrors.email && (
                <span className="field-error-message">{fieldErrors.email}</span>
              )}
            </div>
            <div className="form-field">
              <div className="password-input-wrapper">
                <input 
                  type={showPassword ? "text" : "password"}
                  name="password" 
                  placeholder="Password"
                  className={fieldErrors.password ? "input-error" : ""}
                />
                <button
                  type="button"
                  className="password-toggle"
                  onClick={() => setShowPassword(!showPassword)}
                >
                  {showPassword ? <AiFillEyeInvisible size={20} /> : <AiFillEye size={20} />}
                </button>
              </div>
              {fieldErrors.password && (
                <span className="field-error-message">{fieldErrors.password}</span>
              )}
            </div>
            {!isLogin && (
              <div className="form-field">
                <div className="password-input-wrapper">
                  <input 
                    type={showConfirmPassword ? "text" : "password"}
                    name="confirmPassword" 
                    placeholder="Confirm password"
                    className={fieldErrors.confirmPassword ? "input-error" : ""}
                  />
                  <button
                    type="button"
                    className="password-toggle"
                    onClick={() => setShowConfirmPassword(!showConfirmPassword)}
                  >
                    {showConfirmPassword ? <AiFillEyeInvisible size={20} /> : <AiFillEye size={20} />}
                  </button>
                </div>
                {fieldErrors.confirmPassword && (
                  <span className="field-error-message">{fieldErrors.confirmPassword}</span>
                )}
              </div>
            )}
            {isLogin && (
              <div className="login-options">
                <label className="remember-me">
                  <input type="checkbox" />
                  Remember me
                </label>
                <a href="#" className="forgot-password">Forgot Password</a>
              </div>
            )}
            <button type="submit" className={`${isLogin ? 'login' : 'signup'}-button`}>
              {buttonText}
            </button>
          </form>
          <div className={`social-${isLogin ? 'login' : 'signup'}`}>
            <p>{socialText}</p>
            <div className="social-icons">
              <button><FcGoogle  size={40} /></button>
              <button><FaFacebook size={40}/></button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
