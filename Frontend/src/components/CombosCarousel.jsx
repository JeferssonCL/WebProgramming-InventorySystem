import React, {useContext, useEffect, useState} from "react";
import SwipeableViews from "react-swipeable-views";
import { IconButton, MobileStepper, Box } from "@mui/material";
import { KeyboardArrowLeft, KeyboardArrowRight } from "@mui/icons-material";
import ComboCard from "./ComboCard.jsx";
import {ProductsContext} from "../Context/ProductsContext.jsx";
import axios from "axios";

const combosList = [
    {
        name: "Some Name",
        description: "Description",
        price: 120,
        discount: 10,
        image: "https://i.pinimg.com/564x/67/a0/97/67a097cce9ec691f8d1a5f70195829fe.jpg",
        products: [
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 10,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.pE1KhwDjaodESPi0IOhyFQHaLI?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            },
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 20,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.PSfwU3FqofTLFsdwAomZaQHaSE?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            }
        ]
    },
    {
        name: "Some Name",
        description: "Description",
        price: 120,
        discount: 10,
        image: "https://i.pinimg.com/564x/67/a0/97/67a097cce9ec691f8d1a5f70195829fe.jpg",
        products: [
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 10,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.pE1KhwDjaodESPi0IOhyFQHaLI?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            },
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 20,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.PSfwU3FqofTLFsdwAomZaQHaSE?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            }
        ]
    },
    {
        name: "Some Name",
        description: "Description",
        price: 120,
        discount: 10,
        image: "https://i.pinimg.com/564x/67/a0/97/67a097cce9ec691f8d1a5f70195829fe.jpg",
        products: [
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 10,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.pE1KhwDjaodESPi0IOhyFQHaLI?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            },
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 20,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.PSfwU3FqofTLFsdwAomZaQHaSE?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            }
        ]
    },
    {
        name: "Some Name",
        description: "Description",
        price: 120,
        discount: 10,
        image: "https://i.pinimg.com/564x/67/a0/97/67a097cce9ec691f8d1a5f70195829fe.jpg",
        products: [
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 10,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.pE1KhwDjaodESPi0IOhyFQHaLI?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            },
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 20,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.PSfwU3FqofTLFsdwAomZaQHaSE?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            }
        ]
    },
    {
        name: "Some Name",
        description: "Description",
        price: 120,
        discount: 10,
        image: "https://i.pinimg.com/564x/67/a0/97/67a097cce9ec691f8d1a5f70195829fe.jpg",
        products: [
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 10,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.pE1KhwDjaodESPi0IOhyFQHaLI?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            },
            {
                id: "AAAAA",
                name: "Some Product",
                description: "Lorem ipsum dolor bae",
                price: 20,
                brand: "Some brand",
                images: [
                    {
                        url: "https://th.bing.com/th/id/OIP.PSfwU3FqofTLFsdwAomZaQHaSE?rs=1&pid=ImgDetMain",
                        altText: "Alt text"
                    }
                ]
            }
        ]
    }
];

const CombosCarousel = () => {
    const [activeStep, setActiveStep] = useState(0);
    const [combosListToReceive, setCombosListToReceive] = useState([]);

    useEffect(() => {
        const apiUrl = "http://localhost:5163/api/Combo?page=1&pageSize=10";

        const fetchProducts = async () => {
            const response = await axios.get(apiUrl);
            setCombosListToReceive(response.data.items);
        };

        fetchProducts();
    }, []);

    const maxSteps = Math.ceil(combosListToReceive.length / 3);

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
        <Box sx={{position: "relative", width: "100%", overflow: "hidden", bgcolor: "white", padding: "20px"}}>
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
                        {combosListToReceive
                            .slice(groupIndex * 3, groupIndex * 3 + 3)
                            .map((combo, index) => (
                                <ComboCard combo={combo}>
                                </ComboCard>
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

export default CombosCarousel;
