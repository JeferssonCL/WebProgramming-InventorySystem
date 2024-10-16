import { DatePicker } from "@mui/x-date-pickers";
import ProductCardCompleteInfo  from "../components/ProductCardCompleteInfo";
import { useForm, Controller } from "react-hook-form";
import { useContext } from "react";
import { ProductsContext } from "../context/ProductsContext";
import axios from 'axios';

function CompleteOrder() {
    const {
        register,
        handleSubmit,
        formState: { errors, isSubmitting },
        control
      } = useForm();

    const { products, removeProductById } = useContext(ProductsContext);

    const onSubmit = async (data) => {
        const parsedData = parseOrderData(data);
        await sendOrder(parsedData);
        console.log(data);
    }

    const parseOrderData = (data) => {
        return {
            orderItems: products.map((item) => {
                return {
                    id: item.id,
                    variantId: "00000000-0000-0000-0000-000000000000",
                    name: item.name,
                    price: item.price,
                    image: item.image[0].url,
                    attributes: {},
                    quantity: item.quantity,
                    subtotal: (item.quantity * item.price).toFixed(2)
                }
            }),
            user: {
              id: "c4055860-c902-4787-ba54-0b34e18a1040",
              name: data.firstName,
              email: data.email,
            },
            totalPrice: totalAmount
          };
    }

    const calculateTotalAmount = (products) => {
        if (!Array.isArray(products)) {
          console.error("The products parameter is not an array", products);
          return 0; // O cualquier valor por defecto
        }
      
        return products.reduce((total, product) => {
          return total + (product.price * product.quantity);
        }, 0);
      };

    const totalAmount = calculateTotalAmount(products);

    const sendOrder = async (orderData) => {
        try {
          console.log(JSON.stringify(orderData));
      
          // Realizar la solicitud POST utilizando axios
          const response = await axios.post('https://localhost:5163/api/Order', orderData, {
            headers: {
              'Content-Type': 'application/json',
            }
          });
      
          // Axios automáticamente lanza un error si el status code no está en el rango 2xx
          console.log('Order submitted successfully:', response.data);
          
        } catch (error) {
          // Manejo de errores de Axios
          if (error.response) {
            // El servidor respondió con un código de estado fuera del rango 2xx
            console.error('Error submitting order (response):', error.response.status, error.response.data);
          } else if (error.request) {
            // No se recibió respuesta del servidor
            console.error('Error submitting order (no response):', error.request);
          } else {
            // Otro tipo de error
            console.error('Error submitting order:', error.message);
          }
        }
      };

    return (
        <div className="m-6 flex flex-row justify-between space-x-6 bg-white text-black p-6">
            <div className="w-full">
                <h3 className="font-bold text-2xl">Complete Order</h3>
                <h4 className="font-bold text-lg">Order Details</h4>
                <div>
                    {products.map((item, index) => (
                        <ProductCardCompleteInfo
                            key={item.id}
                            product={item}
                            onDelete={() => removeProductById(item.id)}
                        />
                    ))}
                </div>
                <h3 className="pt-4 font-bold text-lg justify-self-end">Total: {totalAmount.toFixed(2)} $</h3>
            </div>
            <div className="pt-4 max-w-fit flex-grow w-full border rounded-lg p-3">
                <form onSubmit={handleSubmit(onSubmit)}>
                    <h2 className="font-bold text-lg pt-6">User information</h2>
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="fname">First name: </label>
                    <input {...register("firstName", {
                        required: "Firstname required",
                        minLength: {
                            value: 3,
                            message: "Names should contain at least 3 characters"
                        }
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fname" placeholder="John"></input>
                    {errors.firstName && <div className="text-red-500">{errors.firstName.message}</div>}
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="femail">Email: </label>
                    <input {...register("email", {
                        required: "Email required",
                        pattern: {
                            value: /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/,
                            message: "Email should follow the format: something@domain.com"
                        }
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="femail" placeholder="example@domain.com"></input>
                    {errors.email && <div className="text-red-500">{errors.email.message}</div>}
        
                    <h2 className="font-bold text-lg pt-6">Payment Information</h2>
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="fcardNumber">CardNumber: </label>
                    <input  {...register("cardNumber", {
                        required: "Card Number required",
                        pattern: {
                            value: /^[0-9]{15,16}$/,
                            message: "Card Number must be 15 or 16 digits",
                          },
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcardNumber" placeholder="0000-0000-0000-0000"></input>
                    {errors.cardNumber && <div className="text-red-500">{errors.cardNumber.message}</div>}
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="fcardHolderName">CardHolderName: </label>
                    <input {...register("cardHolderName", {
                        required: "Holder required",
                        minLength: {
                            value: 3,
                            message: "Names should contain at least 3 characters"
                        }
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcardHolderName" placeholder="John Doe"></input>
                    {errors.cardHolderName && <div className="text-red-500">{errors.cardHolderName.message}</div>}
                    <div className="flex flex-row justify-between items-end space-x-4">
                        <div className="w-full">
                            <label className="block mb-2 font-medium text-gray-900" htmlFor="fcvv">CVV: </label>
                            <input {...register("cvv", {
                                required: "CVV required",
                                pattern: {
                                    value: /^[0-9]{3}$/,
                                    message: "The cvv code should contain only 3 numbers"
                                }
                            })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2" id="fcvv" placeholder="123"></input>        
                            {errors.cvv && <div className="text-red-500">{errors.cvv.message}</div>}
                        </div>
                        <Controller
                            name="expirationDate"
                            control={control}
                            render={({ field }) => (
                            <DatePicker
                                label="Expiration Date"
                                value={field.value}
                                onChange={field.onChange}
                                renderInput={(params) => (
                                <TextField {...params} fullWidth margin="normal" />
                                )}
                            />
                            )}
                        />
                    </div>

                    <h2 className="font-bold text-lg pt-6">Address</h2>
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="fstreet">Street: </label>
                    <input {...register("street", {
                        required: "Street direction required",
                        minLength: {
                            value: 3,
                            message: "Names should contain at least 3 characters"
                        }
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fstreet" placeholder="Av. Chapultepec"></input>
                    {errors.street && <div className="text-red-500">{errors.street.message}</div>}
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="fcity">City: </label>
                    <input {...register("city", {
                        required: "City required",
                        minLength: {
                            value: 3,
                            message: "Names should contain at least 3 characters"
                        }
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcity" placeholder="CBBA"></input>
                    {errors.city && <div className="text-red-500">{errors.city.message}</div>}
                    <label className="block mb-2 font-medium text-gray-900" htmlFor="fcountry">Country: </label>
                    <input {...register("country", {
                        required: "Country required",
                        minLength: {
                            value: 3,
                            message: "Names should contain at least 3 characters"
                        }
                    })} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5" id="fcountry" placeholder="Bolivia"></input>        
                    {errors.country && <div className="text-red-500">{errors.country.message}</div>}
                    <button 
                        className="pr-3 pl-3 pt-1 pb-1 border rounded-md bg-slate-400 mt-2 text-white"
                        type="submit" 
                        disabled={isSubmitting}
                        >{isSubmitting ? "Loading" : "Accept"}</button>
                </form>
            </div>
        </div>
    );
}

export default CompleteOrder;