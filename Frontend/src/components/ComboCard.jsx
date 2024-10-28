import { Card, Typography, CardMedia } from '@mui/material';
import LocalOfferIcon from '@mui/icons-material/LocalOffer';
import PropTypes from 'prop-types';

const ComboCard = ({ combo }) => {

    return(
        <Card
            variant="outlined"
            className="p-5 w-full flex flex-row space-x-3 justify-start cursor-pointer"
            onClick={() => {
                console.log("CLICK")
                // TODO: Implement redirection to product details
            }}
        >
            <CardMedia
                component="img"
                alt="Combo of products image"
                src={combo.image}
                sx={{width: { xs: '100%', sm: 120 },
                }}
            />
            <div className="w-full">
                <div className="flex flex-row justify-between">
                    <label className="font-bold text-lg">{combo.name}</label>
                    <div className="flex flex-row items-center align-top font-light bg-red-600 text-white pr-3 pl-3 pt-0.5 pb-0.5">
                        <LocalOfferIcon fontSize="small"/>
                        <label className="ml-1">{combo.discount} %</label>
                    </div>
                </div>
                <div className="flex flex-col justify-between h-full pb-7">
                    <label className="font-light">Products:</label>
                    <ul className="list-disc ml-4 font-light">
                        {combo.products && combo.products.map((product) => (
                            <li>{product.name}</li>
                        ))}
                    </ul>
                    <label className="text-sm text-end line-through">Price: {combo.price} $</label>
                    <label className="text-end ">Price: <b>{combo.price - (combo.price * combo.discount / 100)} $</b></label>
                </div>
            </div>
        </Card>
    )
}

ComboCard.propTypes = {
    combo: PropTypes.shape({
        name: PropTypes.string.isRequired,
        discount: PropTypes.number.isRequired,
        price: PropTypes.number.isRequired,
        image: PropTypes.string.isRequired,
        products: PropTypes.arrayOf(
            PropTypes.shape({
                id: PropTypes.number.isRequired,
                name: PropTypes.string.isRequired,
                image: PropTypes.arrayOf(
                    PropTypes.shape({
                        url: PropTypes.string,
                        altText: PropTypes.string
                    })
                ),
                price: PropTypes.number.isRequired,
                discount: PropTypes.number.isRequired,
            })
        ).isRequired,
    }),
}

export default ComboCard;
