import React from 'react';
import '../styles/components/success.css';
import successImage from '../assets/succesImage.png';

const PaymentStatusSuccess = () => {

    return (
        <div className="success-container">
            <div className="success-content">
                <img src={successImage} alt="Payment Successful" className="success-image" />
                <h2 className="success-title">¡Payment Successful!</h2>
                <p className="success-message">Thank you for your purchase. Your order has been processed successfully.</p>

                <div className="success-actions">
                    <h3 className="action-title">What to do next?</h3>
                    <button className="continue-shopping-button">Continue shopping</button>
                    <button className="view-order-button">View my order</button>
                </div>
            </div>
        </div>
    );
};

export default PaymentStatusSuccess;
