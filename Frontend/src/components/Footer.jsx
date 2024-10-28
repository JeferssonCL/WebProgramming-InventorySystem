
const Footer = () => {
    return (
        <div className="flex flex-row justify-between items-center bg-[#7790ED] w-full p-20">
            <div className="flex flex-col w-96">
                <label className="self-start text-black font-semibold text-3xl w-80">Enjoy your products, enjoy...</label>
                <img
                    className="self-end"
                    src="https://firebasestorage.googleapis.com/v0/b/merchant-auth-9c7f2.appspot.com/o/Imagotipo%20(1).png?alt=media&token=6f09f0d6-aefe-4e34-9395-3d6cf80631d2"
                    alt="Merchant logo"
                />
            </div>
            <div className="flex flex-col justify-center align-middle text-center text-lg">
                <a href="/">Home</a>
                <a href="">Product</a>
                <a href="">Contact Us</a>
            </div>
            <img src="https://firebasestorage.googleapis.com/v0/b/merchant-auth-9c7f2.appspot.com/o/online%20shopping.png?alt=media&token=b0900400-c468-4ddf-bf15-ae1b401a42db" alt="Store bags"/>
        </div>
    );
}

export default Footer;
