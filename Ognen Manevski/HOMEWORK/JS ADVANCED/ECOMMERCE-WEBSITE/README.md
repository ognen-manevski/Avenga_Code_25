# 🛒 ShopHub - E-Commerce Website

A fully functional e-commerce website built with vanilla HTML5, CSS3, and ES6+ JavaScript. All product data is fetched live from the **Fake Store API**.

## 🎯 Features

### Core Features
- ✅ **Live API Integration** — Products fetched from [Fake Store API](https://fakestoreapi.com)
- ✅ **Product Listing** — Grid view with filtering by category, sorting (price/rating), and pagination
- ✅ **Product Details** — Modal view with full product information
- ✅ **Shopping Cart** — Add/remove items, update quantities, persistent storage (localStorage)
- ✅ **Cart Badge** — Real-time item count in navbar
- ✅ **Responsive Design** — Mobile-first approach, works on all devices
- ✅ **Loading States** — Skeleton cards while fetching data
- ✅ **Error Handling** — Graceful error messages and retry options
- ✅ **Toast Notifications** — User feedback for cart actions

### Bonus Features
- ⭐ **Multi-Step Checkout** — Shipping info → Order review → Confirmation with client-side validation
- ⭐ **Order Confirmation Email** — Integration-ready for EmailJS (configure with your API keys)

## 🏗️ Project Structure

```
shophub/
├── index.html                    # Home page with product listing
├── css/
│   └── main.css                 # Complete styling (responsive, animations)
├── js/
│   ├── config.js                # API base URLs and config constants
│   ├── main.js                  # Home page logic (filtering, sorting, cart)
│   ├── models/
│   │   ├── Product.js           # Product data model
│   │   └── CartItem.js          # Cart item data model
│   ├── services/
│   │   ├── apiService.js        # All API calls (fetch products, categories, etc.)
│   │   └── cartService.js       # Cart state management and localStorage
│   ├── utils/
│   │   ├── formatters.js        # Data formatting helpers
│   │   └── render.js            # DOM rendering functions
│   └── pages/
│       ├── cart.js              # Shopping cart page logic
│       └── checkout.js          # Checkout & order confirmation logic
├── pages/
│   ├── cart.html                # Shopping cart page
│   ├── checkout.html            # Multi-step checkout form
│   └── product-details.html     # Product detail page (optional)
├── images/                      # Product images (if needed)
└── README.md                    # This file
```

## 🚀 Getting Started

### Prerequisites
- Modern web browser (Chrome, Firefox, Safari, Edge)
- No backend server required — all data is fetched from public API

### Installation

1. **Clone or download the repository:**
   ```bash
   git clone https://github.com/yourusername/shophub.git
   cd shophub
   ```

2. **Open in VS Code or your preferred editor**

3. **Serve locally** (optional, but recommended for testing):
   ```bash
   # Using Python
   python -m http.server 8000
   
   # Or using Node.js http-server
   npx http-server
   ```

4. Open `http://localhost:8000` in your browser

## 🌐 API Reference

### Fake Store API Endpoints

**Fetch All Products:**
```
GET https://fakestoreapi.com/products
```

**Fetch Products by Category:**
```
GET https://fakestoreapi.com/products/category/{category}
Categories: electronics, jewelery, men's clothing, women's clothing
```

**Fetch Single Product:**
```
GET https://fakestoreapi.com/products/{id}
```

**Fetch All Categories:**
```
GET https://fakestoreapi.com/products/categories
```

All responses are automatically mapped to the `Product` model before rendering.

## 🛒 Usage

### Shopping
1. Browse products on the home page
2. Click on a product card to see full details
3. Use category filter, sort options, and pagination
4. Click "Add to Cart" — a toast notification confirms
5. Cart badge updates in real-time

### Cart Management
1. Go to Cart page via navbar
2. Update quantities with +/− buttons or input field
3. Remove items with the × button
4. Proceed to checkout when ready

### Checkout (Bonus Feature)
1. **Step 1:** Fill in shipping address with client-side validation
2. **Step 2:** Review order summary and items
3. **Step 3:** Confirm order and receive confirmation (email optional)
4. Cart clears automatically after successful order

## 📧 Email Confirmation Setup (Optional)

To enable order confirmation emails via EmailJS:

1. Create a free account at [emailjs.com](https://emailjs.com/)
2. Create an email service (e.g., Gmail)
3. Create an email template for order confirmation
4. Copy your **Service ID**, **Template ID**, and **Public Key**
5. Update `js/config.js`:
   ```javascript
   export const EMAILJS_CONFIG = {
     SERVICE_ID: 'your_service_id',
     TEMPLATE_ID: 'your_template_id',
     PUBLIC_KEY: 'your_public_key'
   };
   ```
6. Add EmailJS library to `index.html` before main.js:
   ```html
   <script src="https://cdn.emailjs.com/sdk/2.6.0/email.min.js"></script>
   <script>
     emailjs.init('your_public_key');
   </script>
   ```

## 💾 Data Persistence

- **Shopping Cart:** Automatically saved to `localStorage` after every change
- **Cart Persistence:** Survives page refreshes and browser restarts
- **Checkout Form:** Auto-saves address information during checkout

## 🎨 Styling & Libraries

- **CSS:** Custom CSS3 with CSS variables, Flexbox, Grid animations
- **Icons:** Font Awesome 6.4.0 CDN
- **Fonts:** Google Fonts (Poppins)
- **No external CSS framework** — pure, custom CSS

## 📱 Responsive Breakpoints

- **Desktop:** 1200px+
- **Tablet:** 768px - 1199px
- **Mobile:** < 768px

## ✨ Features Showcase

### Filtering & Sorting
- Filter by category (all, electronics, jewelery, men's clothing, women's clothing)
- Sort by: Featured, Price (low→high), Price (high→low), Highest Rated
- Configure items per page (6, 12, or 24)

### Product Detail Modal
- Full product image with smooth hover zoom
- Complete description
- Star rating with review count
- Stock status indicator
- Quick add-to-cart button

### Cart Interactions
- Increment/decrement quantities
- Real-time subtotal, tax, shipping calculation
- Free shipping on orders over $100
- 10% tax automatically applied
- Remove items instantly
- Empty cart state with helpful message

### Error Handling
- Graceful API error messages
- Retry buttons on failed loads
- Input validation during checkout
- Field-level error messages

## 🐛 Known Limitations

- Fake Store API has limited product images (some products may not load images properly)
- No actual payment processing (checkout is for demo purposes)
- Email confirmation optional (requires EmailJS configuration)
- Product stock is defaulted to 100 (API doesn't provide stock info)

## 🚀 Deployment to GitHub Pages

1. Create a public GitHub repository named `shophub` (or any name)

2. Push your code:
   ```bash
   git add .
   git commit -m "Initial commit"
   git push origin main
   ```

3. Go to **Repository Settings** → **Pages**

4. Under **Source**, select:
   - Branch: `main`
   - Folder: `/ (root)`

5. Click **Save**

6. Your site will be live at: `https://yourusername.github.io/shophub/`

## 🔒 Code Quality

- ✅ ES6+ syntax throughout (arrow functions, destructuring, async/await)
- ✅ Modular code structure (models, services, utils, pages)
- ✅ Separation of concerns (data logic vs. rendering logic)
- ✅ Error handling with try/catch
- ✅ Higher-order functions (map, filter, reduce, sort)
- ✅ DRY principle (Don't Repeat Yourself)
- ✅ Custom events for component communication (`cartChanged`)

## 📄 License

This project is open source and available for educational purposes.

## 🙏 Credits

- **API:** [Fake Store API](https://fakestoreapi.com)
- **Icons:** [Font Awesome](https://fontawesome.com)
- **Fonts:** [Google Fonts](https://fonts.google.com)

---

**Built with ❤️ using vanilla JavaScript** 🚀

Enjoy your e-commerce shopping experience!
