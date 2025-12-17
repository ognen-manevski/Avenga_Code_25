const categoryFilter = document.getElementById('categoryFilter');
const categoryRadios = categoryFilter.querySelectorAll('input[name="category"]');
const cellElements = document.querySelectorAll('.cell');

categoryRadios.forEach(radio => {
    radio.addEventListener('change', (e) => {
        const selectedCategory = e.target.value;

        cellElements.forEach(cell => {
            if (selectedCategory === 'all') {
                cell.style.opacity = '1';
            } else {
                if (cell.classList.contains(selectedCategory)) {
                    cell.style.opacity = '1';
                } else {
                    cell.style.opacity = '0.5';
                }
            }
        });
    });
});

// Enable deselection by clicking anywhere except radio buttons
document.addEventListener('click', (e) => {
    if (e.target.tagName !== 'INPUT') {
        categoryRadios.forEach(radio => radio.checked = false);
        cellElements.forEach(cell => {
            cell.style.opacity = '1';
        });
    }
});
