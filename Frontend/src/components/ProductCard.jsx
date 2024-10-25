import PropTypes from 'prop-types';
import '../styles/components/productCard.css'
import { FaMoneyBill, FaCartPlus, FaTag } from "react-icons/fa";

export function ProductCard({ id, name, price, brand, image, onAddToCart , isAvailableStock}) {
  return (
    <div className="product-card">
      <img className='product-card-image' src={image} alt={`Product image: ${name}`} />
      <a href={`http://localhost:5173/product/${id}`} className='product-card-name'>{name}</a>
      <p className='product-card-price'><FaMoneyBill /> {price} $</p>
      <p className='product-card-brand'>
        <FaTag /> {brand}
      </p>
      <button className={`product-card-add-shop-cart ${isAvailableStock ? "" : "disabled"}`} onClick={onAddToCart}>
      {isAvailableStock ? (
          <>
            <FaCartPlus /> Add to cart
          </>
        ) : (
          "Out of stock"
        )}
      </button>
    </div>
  );
}

ProductCard.propTypes = {
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  price: PropTypes.number.isRequired,
  brand: PropTypes.string.isRequired,
  image: PropTypes.string.isRequired,
  onAddToCart: PropTypes.func.isRequired
};
