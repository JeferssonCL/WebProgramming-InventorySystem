import React, {useEffect, useState} from 'react';
import { Box, IconButton, useTheme } from '@mui/material';
import { ArrowBackIos, ArrowForwardIos } from '@mui/icons-material';
import BrandsCarousel from "../components/BrandsCarousel.jsx";
import CombosCarousel from "../components/CombosCarousel.jsx";
import OffersCarousel from "../components/OffersCarousel.jsx";

const layers = [
    "https://firebasestorage.googleapis.com/v0/b/merchant-auth-9c7f2.appspot.com/o/Twitter%20header%20-%201.png?alt=media&token=03aaa313-6706-445a-9b05-87542476fb1f",
    "https://firebasestorage.googleapis.com/v0/b/merchant-auth-9c7f2.appspot.com/o/Twitter%20header%20-%202.png?alt=media&token=059d9e49-0c1b-4278-94c1-334f63b4adb5",
    "https://firebasestorage.googleapis.com/v0/b/merchant-auth-9c7f2.appspot.com/o/Twitter%20header%20-%203.png?alt=media&token=a487dbda-838a-4655-aebd-f6c460f8ad45"
];

export function HomePage() {
    const [currentIndex, setCurrentIndex] = useState(0);
    const [isFading, setIsFading] = useState(false);
    const theme = useTheme();

    const handleNext = () => {
        setIsFading(true);
        setTimeout(() => {
            setCurrentIndex((prevIndex) => (prevIndex + 1) % layers.length);
            setIsFading(false);
        }, 500);
    };

    const handlePrev = () => {
        setIsFading(true);
        setTimeout(() => {
            setCurrentIndex((prevIndex) =>
                prevIndex === 0 ? layers.length - 1 : prevIndex - 1
            );
            setIsFading(false);
        }, 500);
    };

    useEffect(() => {
        const interval = setInterval(handleNext, 6000);
        return () => clearInterval(interval);
    }, []);

    return (
        <div>
            <Box
                display="flex"
                alignItems="center"
                justifyContent="center"
                position="relative"
                width="100%"
                height="400px"
                className="mb-10"
                sx={{ overflow: 'hidden', zIndex: '-1' }}
            >
                <IconButton
                    onClick={handlePrev}
                    sx={{
                        position: 'absolute',
                        left: theme.spacing(2),
                        top: '50%',
                        transform: 'translateY(-50%)',
                        color: theme.palette.primary.main,
                        zIndex: 1,
                    }}
                >
                    <ArrowBackIos />
                </IconButton>

                <Box
                    component="img"
                    src={layers[currentIndex]}
                    alt="merchant layer"
                    sx={{
                        width: '100%',
                        height: '100%',
                        objectFit: 'fill',
                        transition: 'opacity 0.5s ease-in-out',
                        opacity: isFading ? 0 : 1,
                    }}
                />

                <IconButton
                    onClick={handleNext}
                    sx={{
                        position: 'absolute',
                        right: theme.spacing(2),
                        top: '50%',
                        transform: 'translateY(-50%)',
                        color: theme.palette.primary.main,
                        zIndex: 1,
                    }}
                >
                    <ArrowForwardIos />
                </IconButton>
            </Box>
            <label className="pl-6 text-2xl font-bold text-black">BRANDS</label>
            <BrandsCarousel></BrandsCarousel>
            <label className="pl-6 text-2xl font-bold text-black">COMBOS</label>
            <CombosCarousel></CombosCarousel>
            <label className="pl-6 text-2xl font-bold text-black">OFFERS</label>
            <OffersCarousel></OffersCarousel>
        </div>
    );
}
