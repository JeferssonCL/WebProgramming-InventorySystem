import "../styles/components/header.css"
import { ShoppingCart } from "./ShoppingCart"

export function Header() {
    return (
        <header className="header">
            <img src="public/logo/s.png" alt="Merchant logo" />
            <ShoppingCart />
        </header>
    )    
}