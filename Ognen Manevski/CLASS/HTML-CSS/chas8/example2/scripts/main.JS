document.addEventListener('DOMContentLoaded', () => {
  const items = document.querySelectorAll('.change-me-1');
  
  items.forEach(item => {
    item.addEventListener('mouseenter', () => {
      items.forEach(el => el.classList.add('hovered'));
    });
    
    item.addEventListener('mouseleave', () => {
      items.forEach(el => el.classList.remove('hovered'));
    });
  });
});