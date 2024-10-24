import { FaShoppingCart, FaRegSadTear } from "react-icons/fa";
import { useState } from "react";
import { loadStripe } from "@stripe/stripe-js";
import '../styles/components/shoppingCart.css';
import { ShoppingCartItem } from "./ShoppingCartItem";

export function ShoppingCart({ shoppingCartList, removeToList, increse, decrese }) {
  const [isOpen, setIsOpen] = useState(false);

  const openMenu = () => {
    setIsOpen(!isOpen);
  };

  const shoppingCartDtoList = shoppingCartList.map(item => ({
    id: item.id,
    name: item.name,
    price: item.price,
    imageUrl: item.image.length > 0 ? item.image[0].url : '',
    quantity: item.quantity
  }));

  const submitCart = async () => {
    const stripe = await loadStripe("pk_test_51Q81UpP3WBhplXYwggVU8aKSusfUgfjKqFPz6amcMmjkcnJSJVOL22DHfqQiyou6mtPlbTpOtehXhG0wFRFIo47l00rb1JJ1Qc");
    const response = await fetch('http://localhost:5163/api/Checkout/submit-cart', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(shoppingCartDtoList)
    });

    if (!response.ok) {
        const errorMessage = await response.text();
        console.error("Error from API:", errorMessage);
        return;
    }

    const session = await response.json();
    const result = stripe.redirectToCheckout({
      sessionId: session.id
    });
    if (result.error) {
      console.log(result.error);
    }
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
                  image={item.image.length > 0 ? item.image[0].url : ''}
                  removeToList={removeToList}
                  quantity={item.quantity}
                  increseQuantity={increse}
                  decreseQuantity={decrese}
                />
              ))
            )
          }
        </div>
        <a
          href="/"
          className={`shopping-cart-go-button ${shoppingCartList.length > 0 ? 'active' : ''}`}
          onClick={(e) => {
            e.preventDefault();
            submitCart();
          }}
        >
          <FaShoppingCart /> Go to shopping cart
        </a>
      </div>
    </>
  );
}
