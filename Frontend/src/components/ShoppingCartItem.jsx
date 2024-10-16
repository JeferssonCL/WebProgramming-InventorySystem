import PropTypes from "prop-types";
import '../styles/components/shoppingCartItem.css';
import { FaRegTrashAlt } from "react-icons/fa";
import { StockQuantityInput } from "./StockQuantityInput";
import { useContext } from "react";
import { ProductsContext } from "../context/ProductsContext";

export function ShoppingCartItem({ id, name, image, price, quantity, increseQuantity, decreseQuantity }) {
  const { removeProductById } = useContext(ProductsContext);

  return (
    <div className="shopping-cart-item">
      <img src={image} alt={`Product item ${name}`} className="shopping-cart-item-image" />
      <p className="shopping-cart-item-name">{name}</p>
      <p className="shopping-cart-item-price">${price.toFixed(2)}</p>
      <StockQuantityInput quantity={quantity} increse={increseQuantity} decrese={decreseQuantity} />
      <button className="shopping-cart-item-delete-to-cart" onClick={() => removeProductById(id)}>
        <FaRegTrashAlt />
      </button>
    </div>
  );
}

ShoppingCartItem.propTypes = {
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  image: PropTypes.string.isRequired,
  price: PropTypes.number.isRequired
};
