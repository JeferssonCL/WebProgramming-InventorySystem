import PropTypes from "prop-types"
import '../styles/components/shoppingCartItem.css'

export function ShoppingCartItem(id, name, image, price) {
    return (
        <div className="shopping-cart-item">
            <img src={image} alt={`Product item ${name}`} />
            <h4>{name}</h4>
            <p>{price}</p>
        </div>
    )
}

ShoppingCartItem.PropType = {
    id: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    image: PropTypes.string.isRequired,
    price: PropTypes.number.isRequired
}