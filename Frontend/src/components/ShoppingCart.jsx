import { FaShoppingCart, FaRegSadTear } from "react-icons/fa";
import { useState } from "react";
import '../styles/components/shoppingCart.css';
import { ShoppingCartItem } from "./ShoppingCartItem";

<<<<<<< HEAD
export function ShoppingCart({ shoppingCartList }) {
=======
export function ShoppingCart({ shoppingCartList, removeToList, increse, decrese }) {
>>>>>>> 420ebd4f0cdd684c92a3be1737ac89a3f4155608
  const [isOpen, setIsOpen] = useState(false);

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
            shoppingCartList.length === 0 ? (
              <div className="shopping-cart-list-empty">
                <FaRegSadTear className="shopping-cart-empty-icon" />
                <p className="shopping-cart-list-message-empty">Empty cart</p>
              </div>
            ) : (
              shoppingCartList.map(item => (
                <ShoppingCartItem
                  key={item.id}
                  id={item.id}
                  name={item.name}
                  price={item.price}
                  image={item.image[0].url}
                  quantity={item.quantity}
                  increseQuantity={increse}
                  decreseQuantity={decrese}
                />
              ))
            )
          }
        </div>
        <a href="/complete-order" className={`shopping-cart-go-button ${shoppingCartList.length > 0 ? 'active' : ''}`}><FaShoppingCart /> Go to shopping cart</a>
      </div>
    </>
  );
}
