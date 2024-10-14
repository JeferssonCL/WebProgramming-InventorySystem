import "../styles/components/header.css"
import { ShopCar } from "./ShopCar"

export function Header() {
    return (
        <header className="header">
            <img src="public/logo/s.png" alt="Merchant logo" />
            <ShopCar />
        </header>
    )    
}