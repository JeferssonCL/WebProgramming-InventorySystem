import React, {useEffect, useState} from "react";
import SwipeableViews from "react-swipeable-views";
import { IconButton, MobileStepper, Box } from "@mui/material";
import { KeyboardArrowLeft, KeyboardArrowRight } from "@mui/icons-material";
import ComboCard from "./ComboCard.jsx";
import axios from "axios";

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
