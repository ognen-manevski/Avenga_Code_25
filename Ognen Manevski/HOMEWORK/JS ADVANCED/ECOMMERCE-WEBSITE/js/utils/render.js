// import { formatPrice,} from './formatters.js';

// Render product card 
export function renderProductCard(product) {
  return `
      <div class="col-md-6 col-lg-3">
  <div class="card card-sale product-card h-100" data-product-id="${product.id}" data-sku="${product.sku}">
              <div class="card-bg"></div>
              <div class="position-relative overflow-hidden">
          <img src="${product.images.thumbnail}" class="card-img-top" alt="${product.name}">
                  <div class="sale-badge ${product.compareAtPrice ? '' : 'd-none'}">
                      ${product.discountPercent ? `${product.discountPercent}%` : ''}<span>OFF</span>
                  </div>
                  <div class="new-badge ${product.isNew ? '' : 'd-none'}">
                      <span>NEW ★</span>
                  </div>
              </div>
              <div class="card-body d-flex flex-column">
          <h5 class="card-title">${product.name}</h5>
          <p class="card-text text-muted small">${product.shortDescription}</p>
                  <div class="mb-3">
                  ${renderChips(product)}
                  </div>
                  <div class="mb-3 d-flex justify-content-between align-items-end gap-2">
                  ${renderStars(product)}
                      <!-- prices  -->
                      <div class="text-end">
                          <small class="text-muted ${product.compareAtPrice ? '' : 'd-none'}">
                            <s>${product.compareAtPrice ? `$${product.compareAtPrice.toFixed(2)}` : ''}</s>
                          </small>
                          <h6 class="text-primary mb-0">${product.formattedPrice}</h6>
                      </div>
                  </div>
                  <div class="d-flex gap-2 mt-auto">
                      <button class="btn btn-primary btn-add-to-cart flex-grow-1" data-product-id="${product.id}" ${!product.isInStock ? 'disabled' : ''}>
                        ${product.isInStock ? 'Add to Cart' : 'Out of Stock'}
                      </button>
                      <button class="btn btn-outline-primary d-flex gap-1 align-items-center
                      justify-content-center view-more-btn" data-product-id="${product.id}">
                          <div class="view-more-txt">
                              View
                          </div>
                          <div class="material-symbols-outlined">arrow_outward</div>
                      </button>
                  </div>
              </div>
          </div>
      </div>
  `;
}

//Render chips if any
// <div class="badge bg-secondary text-dark">${product.category}</div>
// "categoryIds": [
//   "audio",
//   "accessories"
// ]
function renderChips(product) {
  if (!Array.isArray(product.categoryIds) || product.categoryIds.length === 0) {
    return '';
  }
  return product.categoryIds
    .map(category => `<span class="badge bg-primary">${category}</span>`)
    .join(' ');
}


// Render star rating
//  <div class="stars text-dark">
//   <span class="">★★★★★</span>
//   <span class="text-muted small">(89 reviews)</span>
// </div>
// }
// "rating": {
//   "rate": 4.6,
//     "count": 89
// },
function renderStars(product) {
  const fullStars = Math.floor(product.rating.rate);
  const halfStar = product.rating.rate - fullStars >= 0.5;
  const emptyStars = 5 - fullStars - (halfStar ? 1 : 0);
  return `
    <div class="stars text-dark">
      <span class="">
        ${'★'.repeat(fullStars)}${halfStar ? '½' : ''}${'☆'.repeat(emptyStars)}
      </span>
      <span class="text-muted small">(${product.rating.count} reviews)</span>
    </div>
  `;
}



// Render product grid
// export function renderProductGrid(products, container) {
//   if (!container) return;
//   if (products.length === 0) {
//     container.innerHTML = '<div class="empty-state"><p>No products found</p></div>';
//     return;
//   }
//   container.innerHTML = products.map(product => renderProductCard(product)).join('');
// }


// Render a loading skeleton (multiple placeholder cards)
// export function renderLoadingState(container, count = 12) {
//   if (!container) return;

//   const skeletons = Array(count).fill(null).map(() => `
//     <div class="product-card skeleton">
//       <div class="skeleton-image"></div>
//       <div class="skeleton-title"></div>
//       <div class="skeleton-description"></div>
//       <div class="skeleton-footer"></div>
//     </div>
//   `).join('');
//   container.innerHTML = skeletons;
// }

// Render error message
// export function renderErrorState(container, message = 'Something went wrong. Please try again.') {
//   if (!container) return;

//   container.innerHTML = `
//     <div class="error-state">
//       <p class="error-icon">⚠️</p>
//       <p class="error-message">${message}</p>
//       <button class="btn-retry">Retry</button>
//     </div>
//   `;
// }


//  Render cart items list
// export function renderCartItems(cartItems, container) {
//   if (!container) return;
//   if (cartItems.length === 0) {
//     container.innerHTML = `
//       <div class="empty-cart">
//         <p class="empty-icon">🛒</p>
//         <p class="empty-text">Your cart is empty</p>
//         <a href="/index.html" class="btn-continue-shopping">Continue Shopping</a>
//       </div>
//     `;
//     return;
//   }
//   container.innerHTML = cartItems.map(item => `
//     <div class="cart-item" data-product-id="${item.product.id}">
//       <img src="${item.product.image}" alt="${item.product.name}" class="cart-item-image" />
//       <div class="cart-item-details">
//         <h4 class="cart-item-name">${item.product.name}</h4>
//         <p class="cart-item-price">${item.product.formattedPrice}</p>
//       </div>
//       <div class="cart-item-quantity">
//         <button class="btn-qty-decrease" data-product-id="${item.product.id}">−</button>
//         <input
//           type="number"
//           class="qty-input"
//           value="${item.quantity}"
//           min="1"
//           max="${item.product.stock}"
//           data-product-id="${item.product.id}"
//         />
//         <button class="btn-qty-increase" data-product-id="${item.product.id}">+</button>
//       </div>
//       <div class="cart-item-total">
//         <p>${item.formattedTotal}</p>
//       </div>
//       <button class="btn-remove" data-product-id="${item.product.id}">✕</button>
//     </div>
//   `).join('');
// }


//  Render cart summary with totals
// export function renderCartSummary(summary, container) {
//   if (!container) return;
//   container.innerHTML = `
//     <div class="order-summary">
//       <div class="summary-row">
//         <span>Subtotal (${summary.itemCount} items):</span>
//         <span>${formatPrice(summary.subtotal)}</span>
//       </div>
//       <div class="summary-row">
//         <span>Shipping:</span>
//         <span>${formatPrice(summary.shipping)}</span>
//       </div>
//       <div class="summary-row">
//         <span>Tax (10%):</span>
//         <span>${formatPrice(summary.tax)}</span>
//       </div>
//       <div class="summary-row summary-total">
//         <span>Total:</span>
//         <span>${formatPrice(summary.total)}</span>
//       </div>
//     </div>
//   `;
// }

// * Render category filter buttons
// export function renderCategoryFilter(categories, container, activeCategory = 'all') {
//   if (!container) return;

//   container.innerHTML = categories.map(category => `
//     <button
//       class="filter-btn ${category === activeCategory ? 'active' : ''}"
//       data-category="${category}"
//     >
//       ${formatCategory(category)}
//     </button>
//   `).join('');
// }


// Update cart badge with item count
// export function updateCartBadge(count) {
//   const badge = document.querySelector('.cart-badge');
//   if (badge) {
//     badge.textContent = count;
//     badge.style.display = count > 0 ? 'flex' : 'none';
//   }
// }

// Show toast notification
// export function showToast(message, type = 'info', duration = 3000) {
//   const toast = document.createElement('div');
//   toast.className = `toast toast-${type}`;
//   toast.textContent = message;
//   document.body.appendChild(toast);
//   // Trigger animation (add class after a frame)
//   setTimeout(() => toast.classList.add('show'), 10);
//   // Remove after duration
//   setTimeout(() => {
//     toast.classList.remove('show');
//     setTimeout(() => toast.remove(), 300);
//   }, duration);
// }

// Show loading spinner overlay
// export function showLoadingOverlay(show = true) {
//   let overlay = document.querySelector('.loading-overlay');

//   if (show) {
//     if (!overlay) {
//       overlay = document.createElement('div');
//       overlay.className = 'loading-overlay';
//       overlay.innerHTML = '<div class="spinner"></div>';
//       document.body.appendChild(overlay);
//     }
//     overlay.style.display = 'flex';
//   } else {
//     if (overlay) {
//       overlay.style.display = 'none';
//     }
//   }
// }
