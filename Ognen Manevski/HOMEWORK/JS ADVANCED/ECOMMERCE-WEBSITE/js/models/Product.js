// {
//   "id": 1,
//   "sku": "NW-AU-HP-001",
//   "name": "Premium Headphones",
//   "shortDescription": "Noise-cancelling wireless headphones with deep bass and 40h battery.",
//   "categoryIds": [
//     "audio",
//     "accessories"
//   ],
//   "brand": "NovaWare",
//   "price": 249.99,
//   "compareAtPrice": 312.49,
//   "discountPercent": 20,
//   "isNew": false,
//   "stock": 18,
//   "rating": {
//     "rate": 4.6,
//     "count": 89
//   },
//   "images": {
//     "thumbnail": "techware-api/imgs/p001/thumb.jpg"
//   }
// },
export class Product {
  constructor(data) {
    this.id = Number(data.id) || 0;
    this.sku = data.sku ?? '';
    this.name = data.name ?? data.title ?? '';
    this.shortDescription = data.shortDescription ?? data.description ?? '';
    this.categoryIds = Array.isArray(data.categoryIds) ? data.categoryIds : [];
    this.brand = data.brand ?? '';

    this.price = Number.isFinite(Number(data.price)) ? Number(data.price) : 0;
    this.compareAtPrice = Number.isFinite(Number(data.compareAtPrice))
      ? Number(data.compareAtPrice)
      : null;
    this.discountPercent = Number.isFinite(Number(data.discountPercent))
      ? Number(data.discountPercent)
      : 0;
    this.isNew = Boolean(data.isNew);
    this.stock = Number.isFinite(Number(data.stock)) ? Math.max(0, Number(data.stock)) : 0;

    const ratingRate = Number(data.rating?.rate ?? 0) || 0;
    const ratingCount = Number(data.rating?.count ?? 0) || 0;
    this.rating = { rate: ratingRate, count: ratingCount };
    this.ratingCount = ratingCount;

    // Keep both shapes available for compatibility in render/detail code.
    this.images = data.images ?? {};
    this.thumbnail = data.images?.thumbnail ?? data.thumbnail ?? '';
    this.image = this.thumbnail;
  }

  get formattedPrice() {
    return `$${this.price.toFixed(2)}`;
  }

  get isInStock() {
    return this.stock > 0;
  }
}

// {
//   "id": 1,
//   "sku": "NW-AU-HP-001",
//   "name": "Premium Headphones",
//   "shortDescription": "Noise-cancelling wireless headphones with deep bass and 40h battery.",
//   "description": "Premium over-ear wireless headphones featuring active noise cancellation, gaming low-latency mode and comfortable memory foam earcups.",
//   "categoryIds": [
//     "audio",
//     "accessories"
//   ],
//   "brand": "NovaWare",
//   "price": 249.99,
//   "compareAtPrice": 312.49,
//   "discountPercent": 20,
//   "isNew": false,
//   "stock": 18,
//   "weightKg": 0.235,
//   "warrantyMonths": 24,
//   "rating": {
//     "rate": 4.6,
//     "count": 89
//   },
//   "comments": [
//     {
//       "name": "Mila",
//       "rating": 5,
//       "text": "Amazing sound quality and battery life.",
//       "date": "2026-02-10"
//     },
//     {
//       "name": "Stefan",
//       "rating": 4,
//       "text": "ANC works really well for travel.",
//       "date": "2026-01-18"
//     }
//   ],
//   "images": {
//     "thumbnail": "techware-api/imgs/p001/thumb.jpg",
//     "main": "techware-api/imgs/p001/main.jpg",
//     "gallery": [
//       "techware-api/imgs/p001/g1.jpg",
//       "techware-api/imgs/p001/g2.jpg"
//     ]
//   },
//   "specs": {
//     "Connectivity": "Bluetooth 5.3",
//     "Battery": "Up to 40 hours",
//     "Charging": "USB-C fast charge",
//     "Noise Cancellation": "Active ANC",
//     "Microphone": "Dual noise-reduction mic"
//   }
// }
export class ProductDetails extends Product {
  constructor(data) {
    super(data);
    // Present only in product detail payload.
    this.description = data.description ?? this.shortDescription;
    this.weightKg = Number.isFinite(Number(data.weightKg)) ? Number(data.weightKg) : null;
    this.warrantyMonths = Number.isFinite(Number(data.warrantyMonths))
      ? Number(data.warrantyMonths)
      : null;
    this.comments = Array.isArray(data.comments) ? data.comments : [];
    this.mainImage = data.images?.main ?? '';
    this.gallery = Array.isArray(data.images?.gallery) ? data.images.gallery : [];
    this.specs = data.specs && typeof data.specs === 'object' ? data.specs : {};
  }
}