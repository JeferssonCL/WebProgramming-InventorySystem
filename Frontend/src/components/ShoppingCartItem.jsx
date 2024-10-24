import PropTypes from "prop-types";
import '../styles/components/shoppingCartItem.css';
import { FaRegTrashAlt } from "react-icons/fa";
import { StockQuantityInput } from "./StockQuantityInput";

export function ShoppingCartItem({ id, name, image, price, removeToList, quantity, increseQuantity, decreseQuantity }) {
  return (
    <div className="shopping-cart-item">
      <img src={image} alt={`Product item ${name}`} className="shopping-cart-item-image" />
      <div className="shopping-cart-item-information">
        <p className="shopping-cart-item-name">{name}</p>
        <p className="shopping-cart-item-price">${price.toFixed(2)}</p>
      </div>
      <StockQuantityInput id={id} quantity={quantity} increse={increseQuantity} decrese={decreseQuantity} />
      <button className="shopping-cart-item-delete-to-cart" onClick={() => removeToList(id)}>
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
  removeToList: PropTypes.func.isRequired,
  quantity: PropTypes.number.isRequired,
  increseQuantity: PropTypes.func.isRequired,
  decreseQuantity: PropTypes.func.isRequired
};
