import React, { useEffect, useRef } from 'react';
import '../styles/components/success.css';
import { useLocation, useNavigate } from 'react-router-dom';
import successImage from '../assets/succesImage.png';

const PaymentStatusSuccess = () => {
    const location = useLocation();
    const query = new URLSearchParams(location.search);
    const sessionId = query.get('session_id');

    const hasRunRef = useRef(false);
    const navigate = useNavigate();

    const submitOrder = async () => {
      const customer = {
        id: "c4055860-c902-4787-ba54-0b34e18a1040",
        email: "customer@example.com",
        address : "default",
        city: "default",
        country: "default"
      };

      const requestBody = {
        StripeSessionId: sessionId,
        Customer: customer,
      };
      const response = await fetch('http://localhost:5163/api/Order', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(requestBody)
      });

      if (!response.ok) {
          const errorMessage = await response.text();
          console.error("Error from API:", errorMessage);
          return;
      }

      localStorage.setItem('orderSubmitted', 'true');
    };

    useEffect(() => {
      const orderSubmitted = localStorage.getItem('orderSubmitted');
      if (sessionId && !hasRunRef.current && !orderSubmitted) {
        hasRunRef.current = true;
        submitOrder();
      }
    }, [sessionId]);

    const handleContinueShopping = () => {
      localStorage.removeItem('orderSubmitted');
      localStorage.removeItem('products');
      localStorage.removeItem('cart');
      navigate('/');
      window.location.reload();
    };

    return (
        <div className="success-container">
            <div className="success-content">
                <img src={successImage} alt="Payment Successful" className="success-image" />
                <h2 className="success-title">¡Payment Successful!</h2>
                <p className="success-message">Thank you for your purchase. Your order has been processed successfully.</p>

                <div className="success-actions">
                    <h3 className="action-title">What to do next?</h3>
                    <button className="continue-shopping-button" onClick={handleContinueShopping}>Continue shopping</button>
                    <button className="view-order-button">View my order</button>
                </div>
            </div>
        </div>
    );
};

export default PaymentStatusSuccess;
