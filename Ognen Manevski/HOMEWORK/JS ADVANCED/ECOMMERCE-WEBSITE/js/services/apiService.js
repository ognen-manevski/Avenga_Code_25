import { CONFIG } from '../config.js';
import { Product, ProductDetails } from '../models/Product.js';

// Fetch categories from API
export async function fetchCategories() {
    const url = `${CONFIG.API_BASE_URL}/categories.json`;
    const res = await fetch(url);
    if (!res.ok) {
        throw new Error(`Failed to fetch categories: ${res.status}`);
    }
    const categories = await res.json();
    //   { "id": "computers", "name": "Computers" },
    return categories.map(cat => cat.name); // return array of category names
}

// Fetch products from API with optional category filter
export async function fetchProducts() {
    const url = `${CONFIG.API_BASE_URL}/products.json`;
    const res = await fetch(url);
    if (!res.ok) {
        throw new Error(`Failed to fetch products: ${res.status}`);
    }
    const rawProducts = await res.json();
    return rawProducts.map(product => new Product(product));
}

export async function fetchProductById(id) {
    const res = await fetch(`${CONFIG.API_BASE_URL}/products/${id}.json`);

    if (!res.ok) {
        throw new Error(`Product not found: ${id}`);
    }

    const rawProduct = await res.json();
    return new ProductDetails(rawProduct);
}

// async function fetchProducts({ limit = 20, skip = 0, category = '' } = {}) {
//   const url = category
//     ? `https://dummyjson.com/products/category/${category}?limit=${limit}&skip=${skip}`
//     : `https://dummyjson.com/products?limit=${limit}&skip=${skip}`;

//   const response = await fetch(url);
//   if (!response.ok) throw new Error(`Failed to fetch products: ${response.status}`);

//   const data = await response.json();
//   return data.products.map(raw => new Product(raw)); // always map to your model
// }

// /**
//  * Fetch all products with optional filtering
//  * @param {Object} options - { category, limit, skip }
//  * @returns {Promise<Product[]>}
//  */
// export async function fetchProducts(options = {}) {
//   const { category, limit = CONFIG.PRODUCTS_PER_PAGE, skip = 0 } = options;

//   try {
//     let url = `${CONFIG.API_BASE_URL}/products`;

//     // If filtering by category, append to URL
//     if (category && category !== 'all') {
//       url += `/category/${category}`;
//     }

//     const response = await fetch(url);

//     if (!response.ok) {
//       throw new Error(`Failed to fetch products: ${response.status}`);
//     }

//     const rawProducts = await response.json();

//     // Map raw API responses to Product model instances
//     const products = rawProducts.map(raw => new Product(raw));

//     // Apply client-side limit and skip for pagination
//     return products.slice(skip, skip + limit);
//   } catch (error) {
//     console.error('Error fetching products:', error);
//     throw error;
//   }
// }

// /**
//  * Fetch a single product by ID
//  * @param {number} id
//  * @returns {Promise<Product>}
//  */
// export async function fetchProductById(id) {
//   try {
//     const response = await fetch(`${CONFIG.API_BASE_URL}/products/${id}`);

//     if (!response.ok) {
//       throw new Error(`Product not found: ${id}`);
//     }

//     const rawProduct = await response.json();
//     return new Product(rawProduct);
//   } catch (error) {
//     console.error('Error fetching product:', error);
//     throw error;
//   }
// }

// /**
//  * Fetch all available categories
//  * @returns {Promise<string[]>}
//  */
// export async function fetchCategories() {
//   try {
//     const response = await fetch(`${CONFIG.API_BASE_URL}/products/categories`);

//     if (!response.ok) {
//       throw new Error(`Failed to fetch categories: ${response.status}`);
//     }

//     const categories = await response.json();
//     return ['all', ...categories]; // Prepend 'all' for "Show all products"
//   } catch (error) {
//     console.error('Error fetching categories:', error);
//     throw error;
//   }
// }

// /**
//  * Fetch products by category with pagination support
//  * @param {string} category
//  * @param {number} limit
//  * @param {number} skip
//  * @returns {Promise<Product[]>}
//  */
// export async function fetchProductsByCategory(category, limit = CONFIG.PRODUCTS_PER_PAGE, skip = 0) {
//   return fetchProducts({ category, limit, skip });
// }
