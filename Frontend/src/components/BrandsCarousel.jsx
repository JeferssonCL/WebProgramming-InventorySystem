import React, { useState } from "react";
import SwipeableViews from "react-swipeable-views";
import { IconButton, MobileStepper, Box } from "@mui/material";
import { KeyboardArrowLeft, KeyboardArrowRight } from "@mui/icons-material";

const alcoholBrands = [
  {
    name: "Casa Real",
    logo_url: "https://th.bing.com/th/id/OIP.wKq8vDO8Mi-IJo-kQOGVkQHaHa?rs=1&pid=ImgDetMain"
  },
  {
    name: "Absolut",
    logo_url: "https://th.bing.com/th/id/R.050aa385a78c274fa3d5c4232a341ee5?rik=eP1NJqQ5zrIgAw&riu=http%3a%2f%2fpluspng.com%2fimg-png%2fabsolut-logo-png-the-absolut-logo-comes-of-age-872.jpg&ehk=%2fTGCPrEAfYsgRhEvysiG37gwFRrlsJcNnYToLPGn%2bSA%3d&risl=&pid=ImgRaw&r=0"
  },
  {
    name: "Johnnie Walker",
    logo_url: "https://brandlogos.net/wp-content/uploads/2021/12/johnnie_walker-brandlogo.net_.png"
  },
  {
    name: "Jack Daniel's",
    logo_url: "https://1000logos.net/wp-content/uploads/2017/02/Jack-Daniels-Symbol.jpg"
  },
  {
    name: "Jameson",
    logo_url: "https://th.bing.com/th/id/R.b7dd22faecddc1b7b0f2433caba00111?rik=QMd277aIWs5jZg&pid=ImgRaw&r=0"
  },
  {
    name: "Smirnoff",
    logo_url: "https://1000logos.net/wp-content/uploads/2021/05/Smirnoff-logo.png"
  },
  {
    name: "Grey Goose",
    logo_url: "https://th.bing.com/th/id/OIP.qQGFcwCK1uKCMvbiwBGlowHaEK?rs=1&pid=ImgDetMain"
  },
  {
    name: "José Cuervo",
    logo_url: "https://th.bing.com/th/id/OIP.HWJct4-FQUdV4DH7ahBouwHaEv?rs=1&pid=ImgDetMain"
  },
  {
    name: "Patrón",
    logo_url: "https://mma.prnewswire.com/media/285169/patron_logo_Logo.jpg?p=publish"
  },
  {
    name: "Don Julio",
    logo_url: "https://logos-world.net/wp-content/uploads/2022/11/Don-Julio-Logo.png"
  },
  {
    name: "Bacardí",
    logo_url: "https://logos-world.net/wp-content/uploads/2020/12/Bacardi-Symbol.png"
  },
  {
    name: "Havana Club",
    logo_url: "https://th.bing.com/th/id/OIP.iIpURuQdNtRmnF4Zpo6hVwHaEH?rs=1&pid=ImgDetMain"
  },
  {
    name: "Captain Morgan",
    logo_url: "https://th.bing.com/th/id/R.6791de38b5820a7e1a58266bef833e1c?rik=G8mvnYAQCI6hOQ&pid=ImgRaw&r=0"
  },
  {
    name: "Tanqueray",
    logo_url: "https://th.bing.com/th/id/R.c3ad15d2d9606fc5cb867a870bfa71ff?rik=XEu6WTpwagYxxA&pid=ImgRaw&r=0"
  },
  {
    name: "Bombay Sapphire",
    logo_url: "https://th.bing.com/th/id/R.720069369a62b8e194f3aad791ba1224?rik=nvjDx%2bakdS9Zxw&pid=ImgRaw&r=0"
  },
  {
    name: "Corona",
    logo_url: "https://th.bing.com/th/id/OIP.ToXSRlT2f78glotiQcsisQHaEB?rs=1&pid=ImgDetMain"
  },
  {
    name: "Heineken",
    logo_url: "https://logodownload.org/wp-content/uploads/2014/08/heineken-logo-1.png"
  },
  {
    name: "Moët & Chandon",
    logo_url: "https://1000logos.net/wp-content/uploads/2021/05/Moet-Chandon-logo.png"
  },
  {
    name: "Branca",
    logo_url: "https://th.bing.com/th/id/OIP.RQbq_mU63Z8b5yEgoxesQwHaHa?rs=1&pid=ImgDetMain"
  }
];

const BrandsCarousel = () => {
  const [activeStep, setActiveStep] = useState(0);

  const maxSteps = Math.ceil(alcoholBrands.length / 5);

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
              marginLeft: '50px',
              marginRight: '50px',
              gap: 2,
            }}
          >
            {alcoholBrands
              .slice(groupIndex * 5, groupIndex * 5 + 5)
              .map((image, index) => (
                <Box
                  key={index}
                  component="img"
                  src={image.logo_url}
                  alt={`Brand ${groupIndex * 5 + index + 1} - ${image.name}`}
                  className="cursor-pointer"
                  sx={{marginBottom: "10px", width: "200px", height: "200px", objectFit: "contain", borderRadius: "100%", border: "2px solid #000"}}
                  onClick={() => {
                    // TODO: Implement redirection
                  }}
                />
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

export default BrandsCarousel;
