import { Card, Typography, CardMedia, CircularProgress } from '@mui/material';
import LocalOfferIcon from '@mui/icons-material/LocalOffer';
import PropTypes from 'prop-types';
import {useNavigate} from "react-router-dom";

const ProductOffersCard = ({ product }) => {
    const navigate = useNavigate();

    return(
        <Card
            variant="outlined"
            className="p-5 w-full flex flex-row space-x-3 justify-start cursor-pointer"
            onClick={() => {
                navigate("/product/" + product.id);
            }}
        >
            {product.images.lenght > 0
                ? <CardMedia
                    component="img"
                    alt="Combo of products image"
                    src={product.image?.[0]?.url || "default-image-url.jpg"}
                    sx={{width: { xs: '100%', sm: 120 },
                    }}
                /> : <CircularProgress/>
            }
            <div className="w-full">
                <div className="flex flex-row justify-between">
                    <label className="font-bold text-lg">{product.name}</label>
                    <div className="flex flex-row items-center align-top font-light bg-red-600 text-white pr-3 pl-3 pt-0.5 pb-0.5">
                        <LocalOfferIcon fontSize="small"/>
                        <label className="ml-1">{product.discountPercentage} %</label>
                    </div>
                </div>
                <div className="flex flex-col justify-between h-full pb-7">
                    <label className="font-light pt-5">{product.description}</label>
                    <label className="text-sm text-end line-through">Price: {product.price} $</label>
                    <label className="text-end ">Price: <b>{product.priceWithDiscount} $</b></label>
                </div>
            </div>
        </Card>
    )
}

ProductOffersCard.propTypes = {
    product: PropTypes.shape({
        id: PropTypes.string.isRequired,
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        alcoholPercentage: PropTypes.number,
        volume: PropTypes.string,
        stock: PropTypes.number,
        price: PropTypes.number.isRequired,
        brand: PropTypes.string,
        discountPercentage: PropTypes.number.isRequired,
        priceWithDiscount: PropTypes.number.isRequired,
        images: PropTypes.arrayOf(
            PropTypes.shape({
                url: PropTypes.string.isRequired,
                altText: PropTypes.string.isRequired
            })
        ),
    }),
}

export default ProductOffersCard;
