import React, { useEffect, useState } from "react";
import { AiFillEye, AiFillEyeInvisible } from "react-icons/ai";
import { GoogleLoginButton, FacebookLoginButton } from "../components/SocialButtons";
import "../styles/components/auth.css";

export function AuthForm({
  isLogin,
  onSubmit,
  onSwitchAuth,
  errorMessage = "",
  resetErrorMessage = () => {},
  fieldErrors = {},
  statusMessage = {},
  onSocialLoginSuccess,
  onSocialLoginError,
}) {
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);

  const title = isLogin ? "LOGIN" : "SIGN UP";
  const buttonText = isLogin ? "LOGIN" : "SIGN UP";
  const socialText = isLogin ? "Or Login with" : "Or Sign up with";
  const switchText = isLogin ? "Don't have an account?" : "Already have an account?";
  const switchButtonText = isLogin ? "SIGN UP" : "LOGIN";


  useEffect(() => {
    if (errorMessage !== "") {
      alert(errorMessage);
      resetErrorMessage();
    }
  }, [errorMessage]);

  return (
    <div className={`${isLogin ? "login" : "signup"}-container`}>
      <div className={`${isLogin ? "login" : "signup"}-sidebar`}>
        <div>
          <img
            src="public/logo/m.png"
            alt="Merchant logo"
            className={`${isLogin ? "login" : "signup"}-logo`}
          />
          <p className={`${isLogin ? "login" : "signup"}-welcome`}>
            {isLogin ? "WELCOME BACK!" : "WELCOME!"}
          </p>
          <p className={`${isLogin ? "login" : "signup"}-info`}>
            {isLogin
              ? "To keep connected with us please login with your personal info"
              : "Join us to find everything you need"}
          </p>
        </div>
        <div className={`${isLogin ? "signup" : "login"}-section`}>
          <p>{switchText}</p>
          <button onClick={onSwitchAuth} className={`${isLogin ? "signup" : "login"}-button`}>
            {switchButtonText}
          </button>
        </div>
      </div>

      <div className={`${isLogin ? "login" : "signup"}-form-container`}>
        <div className={`${isLogin ? "login" : "signup"}-form`}>
          <h2 className="form-title">{title}</h2>

          <form onSubmit={onSubmit} noValidate>
            {!isLogin && (
              <div className="form-field">
                <input
                  type="text"
                  name="name"
                  placeholder="Name"
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
                    placeholder="Confirm Password"
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

            {statusMessage.message && (
              <p className={`status-message ${statusMessage.type}`}>{statusMessage.message}</p>
            )}

            <button type="submit" className="signup-button">
              {buttonText}
            </button>
          </form>

          <p className="social-text">{socialText}</p>

          <div className="social-icons">
            <GoogleLoginButton onSuccess={onSocialLoginSuccess} onError={onSocialLoginError} />
            <FacebookLoginButton onSuccess={onSocialLoginSuccess} onError={onSocialLoginError} />
          </div>
        </div>
      </div>
    </div>
  );
}
