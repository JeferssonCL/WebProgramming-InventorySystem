import { useState } from "react";
import "../../styles/components/product-details/image.css";

export function Image({ image, changeImage }) {
  const [isCurrent, setIsCurrent] = useState(false);

  return (
    <img
      src={image.url}
      alt={image.altText}
      className="product-image-preview-mini"
      onClick={() => changeImage(image)}
    />
  );
}
