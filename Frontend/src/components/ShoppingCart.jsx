import { FaShoppingCart, FaRegSadTear } from "react-icons/fa";
import { useState, useContext } from "react";
import '../styles/components/shoppingCart.css';
import { ShoppingCartItem } from "./ShoppingCartItem";
import { ProductsContext } from "../context/ProductsContext";

export function ShoppingCart() {
  const [isOpen, setIsOpen] = useState(false);

  const { products } = useContext(ProductsContext);

  const openMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <>
      <button className="shopping-cart-button" onClick={openMenu}>
        <FaShoppingCart className="shop-cart-button" />
      </button>
      <div className={`shopping-cart-list-section ${isOpen ? 'open' : ''}`}>
        <div className="shopping-cart-list-products">
          {
            products.length === 0 ? (
              <div className="shopping-cart-list-empty">
                <FaRegSadTear className="shopping-cart-empty-icon" />
                <p className="shopping-cart-list-message-empty">Empty cart</p>
              </div>
            ) : (
              products.map(item => (
                <ShoppingCartItem
                  key={item.id}
                  id={item.id}
                  name={item.name}
                  price={item.price}
                  image={item.image[0].url}
                  quantity={item.quantity}
                />
              ))
            )
          }
        </div>
        <a href="/complete-order" className={`shopping-cart-go-button ${products.length > 0 ? 'active' : ''}`}><FaShoppingCart /> Go to shopping cart</a>
      </div>
    </>
  );
}
