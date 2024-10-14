import { FaShoppingCart } from "react-icons/fa";
import { useState, useContext } from "react";

export function ShopCar() {
    return (
        <>
        <button className="shopping-car-button">
            <FaShoppingCart />
        </button>
        </>
    )
}