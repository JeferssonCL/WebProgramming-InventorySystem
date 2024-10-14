import PropTypes from "prop-types"

export function ShoppingCartItem(id, name, image) {
    return (
        <div className="shopping-cart-item">
            <img src={image} alt={`Product item ${name}`} />
            <h4>{name}</h4>
        </div>
    )
}

ShoppingCartItem.PropType = {
    id: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    image: PropTypes.string.isRequired
}