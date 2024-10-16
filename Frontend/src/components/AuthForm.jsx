import React from "react";
import { FaFacebook, FaEye } from "react-icons/fa";
import { FcGoogle } from "react-icons/fc";

export function AuthForm({ isLogin, onSubmit, onSwitchAuth, errorMessage, invalidFields }) {
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
                src="public/logo/l.png" 
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
          {errorMessage && <p className="error-message">{errorMessage}</p>}
          <form onSubmit={onSubmit}>
            {!isLogin && (
              <div className="input-group">
                <input type="text" name="username" placeholder="Username" required 
                  className={invalidFields.includes("username") ? "invalid-input" : ""}
                />
              </div>
            )}
            <div className="input-group">
              <input
                type="text"
                name="email"
                placeholder={isLogin ? "Username or Email" : "Email"}
                required
                className={invalidFields.includes("email")? "Invalid-input" : ""}
              />
            </div>
            <div className="input-group">
              <input type="password" name="password" placeholder="Password" required 
                    className={invalidFields.includes("email")? "Invalid-input" : ""}
                />
            </div>
            {!isLogin && (
              <div className="input-group">
                <input type="password" name="confirmPassword" placeholder="Confirm password" required 
                    className={invalidFields.includes("email")? "Invalid-input" : ""}
                />
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
              <button><FcGoogle /></button>
              <button><FaFacebook /></button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
