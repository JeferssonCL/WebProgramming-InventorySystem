import { FaMinus, FaPlus } from "react-icons/fa";
import PropTypes from "prop-types";
import '../styles/components/stockQuantityInput.css'

export function StockQuantityInput({ id, quantity, increse, decrese  , isAvailableStock}) {
  return (
    <div className="stock-quantity-input">
      <button className="quantity-input-decrese-button" onClick={() => decrese(id)}>
        <FaMinus />
      </button>
      <input type="number" name="quantity-input" id="quantity-input" className="quantity-input" value={quantity} readOnly />
      <button className={`quantity-input-increse-button ${isAvailableStock ? "" : "disabled"}`}  onClick={() => increse(id)}>
        <FaPlus />
      </button>
    </div>
  )
}
