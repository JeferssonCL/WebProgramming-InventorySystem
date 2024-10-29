import PropTypes from "prop-types";
import '../styles/components/shoppingCartItem.css';
import { FaRegTrashAlt, FaTag } from "react-icons/fa";
import { StockQuantityInput } from "./StockQuantityInput";
import { useContext } from "react";
import { ProductsContext } from "../context/ProductsContext";

export function ShoppingCartItem({ 
    id, 
    name, 
    image, 
    price, 
    quantity, 
    isAvailableStock, 
    discountPercentage, 
    priceWithDiscount 
}) {
    const { removeProductById, handleDecreaseQuantity, handleIncreaseQuantity } = useContext(ProductsContext);

    return (
        <div className="shopping-cart-item">
            <img src={image} alt={`Product item ${name}`} className="shopping-cart-item-image" />
            <div className="shopping-cart-item-information">
                <p className="shopping-cart-item-name">{name}</p>
                {discountPercentage > 0 ? (
                    <div className="shopping-cart-item-price-container">
                        <p className="shopping-cart-item-original-price">${price.toFixed(2)}</p>
                        <p className="shopping-cart-item-discount">
                            <FaTag className="discount-icon" /> {discountPercentage}% OFF
                        </p>
                        <p className="shopping-cart-item-final-price">${priceWithDiscount.toFixed(2)}</p>
                    </div>
                ) : (
                    <p className="shopping-cart-item-price">${price.toFixed(2)}</p>
                )}
            </div>

            <StockQuantityInput 
                id={id} 
                quantity={quantity} 
                increse={handleIncreaseQuantity} 
                decrese={handleDecreaseQuantity} 
                isAvailableStock={isAvailableStock} 
            />
            <button 
                className="shopping-cart-item-delete-to-cart" 
                onClick={() => removeProductById(id)}
            >
                <FaRegTrashAlt />
            </button>
        </div>
    );
}

ShoppingCartItem.propTypes = {
    id: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    image: PropTypes.string.isRequired,
    price: PropTypes.number.isRequired,
    quantity: PropTypes.number.isRequired,
    isAvailableStock: PropTypes.bool.isRequired,
    discountPercentage: PropTypes.number,
    priceWithDiscount: PropTypes.number
};
