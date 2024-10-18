import { FaMinus, FaPlus } from "react-icons/fa";
import '../styles/components/stockQuantityInput.css'

export function StockQuantityInput({ id, quantity, increse, decrese }) {
  return (
    <div className="stock-quantity-input">
      <button className="quantity-input-decrese-button" onClick={() => decrese(id)}>
        <FaMinus />
      </button>
      <input type="number" name="quantity-input" id="quantity-input" className="quantity-input" value={quantity} />
      <button className="quantity-input-decrese-button" onClick={() => increse(id)}>
        <FaPlus />
      </button>
    </div>
  )
}
