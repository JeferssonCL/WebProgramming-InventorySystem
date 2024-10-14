import { FaShoppingCart } from "react-icons/fa";
import { useState } from "react";
import '../styles/components/shoppingCart.css';
import { ShoppingCartItem } from "./ShoppingCartItem";

export function ShoppingCart() {
    const [isOpen, setIsOpen] = useState(false);
    const [shoppingCartList, setShoppingCartList] = useState([]);

    const openMenu = () => {
        setIsOpen(!isOpen);
    }

    return (
        <>
            <button className="shopping-cart-button" onClick={openMenu}>
                <FaShoppingCart className="shop-cart-button" />
            </button>
            <div className={`shopping-cart-list-section ${isOpen ? 'open' : ''}`}>
                <div className="shopping-cart-list-products">
                    {
                        shoppingCartList.length === 0 ? (
                            <p className="shopping-cart-list-message-empty">Empty cart</p>
                        ) : (
                            shoppingCartList.map(item => (
                                <ShoppingCartItem
                                    key={item.id}
                                    id={item.id}
                                    name={item.name}
                                    image={item.image}
                                />
                            ))
                        )
                    }
                </div>
            </div>
        </>
    );
}
