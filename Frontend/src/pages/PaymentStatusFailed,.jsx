import React from 'react';
import '../styles/components/failed.css';
import failedImage from '../assets/failedImage.png';

const PaymentStatusFailed = () => {
    return (
        <div className="failed-container">
            <div className="failed-content">
                <img src={failedImage} alt="Payment Failed" className="failed-image" />
                <h2 className="failed-title">¡Payment Failed!</h2>
                <p className="failed-message">We're sorry, an error occurred while processing your payment. Please try again.</p>

                <div className="failed-actions">
                    <h3 className="action-title">What to do next?</h3>
                    <button className="retry-button">Retry Payment</button>
                    <button className="contact-support-button">Contact Support</button>
                </div>
            </div>
        </div>
    );
};

export default PaymentStatusFailed;
