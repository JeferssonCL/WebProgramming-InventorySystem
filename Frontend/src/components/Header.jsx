import { useState } from "react"
import "../styles/components/header.css"
import { ShoppingCart } from "./ShoppingCart"

export function Header({ cartList, removeToList, increaseQuantity, decreaseQuantity }) {
  return (
    <header className="header">
      <img src="public/logo/s.png" alt="Merchant logo" />
      <ShoppingCart shoppingCartList={cartList} removeToList={removeToList} increse={increaseQuantity} decrese={decreaseQuantity} />
    </header>
  )
}
