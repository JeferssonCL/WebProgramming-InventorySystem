import { useState } from "react";
import { Image } from "./Image";
import '../../styles/components/product-details/images.css'

export function Images({ images }) {
  const [currentImage, setCurrentImage] = useState(images[0]);

  const handleChangeImage = (image) => {
    setCurrentImage(image);
    console.log(image);
  };

  return (
    <div className="images-section">
      {images.length > 1 && (
        <div className="images-list-section">
          {images.map((image, index) => (
            <Image key={index} image={image} changeImage={handleChangeImage} />
          ))}
        </div>
      )}
      <div className="image-section">
        <img
          src={currentImage.url}
          alt={currentImage.altText}
          className="current-image"
        />
      </div>
    </div>
  );
}
