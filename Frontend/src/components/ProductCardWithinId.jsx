import PropTypes from 'prop-types';
import '../styles/components/productCard.css'
import { FaMoneyBill, FaTag } from "react-icons/fa";

export function ProductCardWithinId({ name, price, brand}) {
  return (
    <div className="product-card">
      <p className='product-card-name'>{name}</p>
      <p className='product-card-price'><FaMoneyBill /> {price} $</p>
      <p className='product-card-brand'>
        <FaTag /> {brand}
      </p>
    </div>
  );
}

ProductCardWithinId.propTypes = {
  name: PropTypes.string.isRequired,
  price: PropTypes.number.isRequired,
  brand: PropTypes.string.isRequired
};
