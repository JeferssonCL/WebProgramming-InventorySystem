import React from 'react';
import { auth } from '../config/firebase';
import { 
  GoogleAuthProvider, 
  FacebookAuthProvider,
  signInWithPopup 
} from 'firebase/auth';
import { FaFacebook } from "react-icons/fa";
import { FcGoogle } from "react-icons/fc";

const handleSocialAuth = async (provider, onSuccess, onError) => {
  try {
    const result = await signInWithPopup(auth, provider);
    onSuccess?.(result.user);
  } catch (error) {
    console.error('Social auth error:', error);
    let errorMsg = "Error authenticating with social network";
    
    switch (error.code) {
      case 'auth/popup-closed-by-user':
        errorMsg = "The process was cancelled";
        break;
      case 'auth/account-exists-with-different-credential':
        errorMsg = "Ya existe una cuenta con este email usando otro método de inicio de sesión";
        break;
      default:
        errorMsg = "Error al autenticar. Por favor, intenta de nuevo";
    }
    
    onError?.(errorMsg);
  }
};

export const GoogleLoginButton = ({ onSuccess, onError }) => {
  const handleGoogleLogin = () => {
    const provider = new GoogleAuthProvider();
    handleSocialAuth(provider, onSuccess, onError);
  };

  return (
    <button
      type="button"
      onClick={handleGoogleLogin}
      className="social-auth-button google"
      aria-label="Iniciar sesión con Google"
    >
      <FcGoogle size={40} />
    </button>
  );
};

export const FacebookLoginButton = ({ onSuccess, onError }) => {
  const handleFacebookLogin = () => {
    const provider = new FacebookAuthProvider();
    handleSocialAuth(provider, onSuccess, onError);
  };

  return (
    <button
      type="button"
      onClick={handleFacebookLogin}
      className="social-auth-button facebook"
      aria-label="Iniciar sesión con Facebook"
    >
      <FaFacebook size={40} />
    </button>
  );
};
