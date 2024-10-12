import "../styles/components/header.css"

export function Header() {
    return (
        <header className="header">
            <button className="menu-button">
                <span className="lines"></span>
                <span className="lines"></span>
                <span className="lines"></span>
            </button>
            <img src="public/logo/s.png" alt="Merchant logo" />
        </header>
    )    
}