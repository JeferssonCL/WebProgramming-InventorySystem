import React, {useEffect, useState} from "react";
import SwipeableViews from "react-swipeable-views";
import { IconButton, MobileStepper, Box } from "@mui/material";
import { KeyboardArrowLeft, KeyboardArrowRight } from "@mui/icons-material";
import ProductOffersCard from "./ProductOnOffertCard.jsx";
import axios from "axios";

const productsWithOffers = [
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    },
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    },
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    },
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    },
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    },
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    },
    {
        name: "Some Name",
        description: "Lorem ipuson dolor bae, siet maet dues milis",
        price: 120,
        discount: 10,
        image: [
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            },
            {
                url: "https://images.pexels.com/photos/2286972/pexels-photo-2286972.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                altTexT: "Some alt text"
            }
        ],
    }
];

const OffersCarousel = () => {
    const [activeStep, setActiveStep] = useState(0);
    const [productsWithOffer, setProductsWithOffer] = useState([]);

    useEffect(() => {
        const apiUrl = "http://localhost:5163/api/Combo?page=1&pageSize=10";

        const fetchProducts = async () => {
            const response = await axios.get(apiUrl);
            setProductsWithOffer(response.data.data);
        };

        fetchProducts();
    }, []);


    const maxSteps = Math.ceil(productsWithOffers.length / 3);

    const handleNext = () => {
        setActiveStep((prevStep) => (prevStep + 1) % maxSteps);
    };

    const handleBack = () => {
        setActiveStep((prevStep) => (prevStep - 1 + maxSteps) % maxSteps);
    };

    const handleStepChange = (step) => {
        setActiveStep(step);
    };

    return (
        <Box
            className="flex flex-col justify-between h-full"
            sx={{position: "relative", width: "100%", overflow: "hidden", bgcolor: "white", padding: "20px"}}>
            <SwipeableViews
                index={activeStep}
                onChangeIndex={handleStepChange}
                enableMouseEvents
                resistance
            >
                {Array.from({length: maxSteps}).map((_, groupIndex) => (
                    <Box
                        key={groupIndex}
                        sx={{
                            display: "flex",
                            justifyContent: "space-between",
                            gap: 2,
                        }}
                    >
                        {productsWithOffers
                            .slice(groupIndex * 3, groupIndex * 3 + 3)
                            .map((product, index) => (
                                <ProductOffersCard product={product}>
                                </ProductOffersCard>
                            ))}
                    </Box>
                ))}
            </SwipeableViews>
            <MobileStepper
                steps={maxSteps}
                position="static"
                activeStep={activeStep}
                nextButton={
                    <IconButton size="small" onClick={handleNext} disabled={activeStep === maxSteps - 1}>
                        <KeyboardArrowRight/>
                    </IconButton>
                }
                backButton={
                    <IconButton size="small" onClick={handleBack} disabled={activeStep === 0}>
                        <KeyboardArrowLeft/>
                    </IconButton>
                }
            />
        </Box>
    );
}

export default OffersCarousel;
