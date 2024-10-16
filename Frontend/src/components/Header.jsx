import { useContext } from "react"
import "../styles/components/header.css"
import { ShoppingCart } from "./ShoppingCart"
import { ProductsContext } from "../context/ProductsContext"


export function Header() {
  const { products } = useContext(ProductsContext);

  return (
    <header className="header">
      <img src="public/logo/s.png" alt="Merchant logo" />
      <ShoppingCart shoppingCartList={products}/>
    </header>
  )
}
