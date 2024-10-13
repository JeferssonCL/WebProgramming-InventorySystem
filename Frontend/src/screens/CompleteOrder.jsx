import { DatePicker } from "@mui/x-date-pickers";
import ProductCard  from "../components/ProductCard.jsx";
import dayjs from "dayjs";

function CompleteOrder() {
    const productsList = [
        {
            Id: "f2f1a8f5-2813-4187-9f4e-174e8517f492",
            ImageUrl: "https://assets.adidas.com/images/w_600,f_auto,q_auto/4c8dd0fd4d7348ba805dad37abd9c270_9366/Gazelle_Italy_Shoes_Blue_ID3725_01_standard.jpg",
            Name: "Product 1",
            Price: 30,
            Quantity: 2,
            SubTotal: 60,
        },
        {
            Id: "5e1c65aa-0c2a-4a97-9edf-81eb1c3e8d92",
            ImageUrl: "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/8a0d2305b9c14bc49e8338b8e7b42ee4_9366/Leopard_3-Stripes_Tee_Black_IW8478_21_model.jpg",
            Name: "Product 2",
            Price: 40,
            Quantity: 1,
            SubTotal: 80,
        }
    ]
    return (
        <div className="m-6 flex flex-row justify-between space-x-6">
            <div className="w-full">
                <h3 className="font-bold text-2xl">Complete Order</h3>
                <h4 className="font-bold text-lg">Order Details</h4>
                <div>
                    {productsList.map((item, index) => (
                        <ProductCard
                            product={item}
                        />
                    ))}
                </div>
            </div>
            <div className="pt-4 max-w-fit flex-grow min-w-96">
                <form>
                    <h2 className="font-bold text-lg pt-6">User information</h2>
                    <label className="block mb-2 font-medium text-gray-900" for="fname">First name: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fname" placeholder="John" required></input>
                    <label className="block mb-2 font-medium text-gray-900" for="femail">Email: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="femail" placeholder="example@domain.com" required></input>
        
                    <h2 className="font-bold text-lg pt-6">Payment Information</h2>
                    <label className="block mb-2 font-medium text-gray-900" for="fcardNumber">CardNumber: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcardNumber" placeholder="0000-0000-0000-0000" required></input>
                    <label className="block mb-2 font-medium text-gray-900" for="fcardHolderName">CardHolderName: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcardHolderName" placeholder="John Doe" required></input>
                    <div className="flex flex-row justify-between items-end space-x-4">
                        <div className="w-full">
                            <label className="block mb-2 font-medium text-gray-900" for="fcvv">CVV: </label>
                            <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2" id="fcvv" placeholder="123" required></input>        
                        </div>
                        <DatePicker className="w-full"
                                label="Expiration Date" 
                                slotProps={{ field: { size: 'small' } }}
                            />
                    </div>

                    <h2 className="font-bold text-lg pt-6">Address</h2>
                    <label className="block mb-2 font-medium text-gray-900" for="fstreet">Street: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fstreet" placeholder="Av. Chapultepec" required></input>
                    <label className="block mb-2 font-medium text-gray-900" for="fcity">City: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcity" placeholder="CBBA" required></input>
                    <label className="block mb-2 font-medium text-gray-900" for="fcountry">Country: </label>
                    <input className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcountry" placeholder="Bolivia" required></input>        
                </form>
            </div>
        </div>
    );
}

export default CompleteOrder;