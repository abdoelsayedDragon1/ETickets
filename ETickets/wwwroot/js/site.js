// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const pages = document.querySelectorAll('.page-item');
const prevButton = document.getElementById('prev');
const nextButton = document.getElementById('next');
let currentPage = 1;
const totalPages = pages.length - 2; // Exclude Previous and Next buttons

function updatePagination() {
    // Update the active state and href for each page link
    pages.forEach((page, index) => {
        if (index === 0 || index === pages.length - 1) return; // Skip Previous and Next
        const pageNumber = parseInt(page.querySelector('a').getAttribute('data-page'), 10);
        page.classList.remove('active');
        if (pageNumber === currentPage) {
            page.classList.add('active');
        }
    });

    // Disable Previous button if on the first page
    prevButton.classList.toggle('disabled', currentPage === 1);
    // Disable Next button if on the last page
    nextButton.classList.toggle('disabled', currentPage === totalPages);

    // Update href for Previous and Next buttons
    const prevPageNum = currentPage > 1 ? currentPage - 1 : 1;
    const nextPageNum = currentPage < totalPages ? currentPage + 1 : totalPages;
    prevButton.querySelector('a').setAttribute('href', `/Movie/Index?pageNum=${prevPageNum}`);
    nextButton.querySelector('a').setAttribute('href', `/Movie/Index?pageNum=${nextPageNum}`);
}

// Click event for page numbers
pages.forEach((page) => {
    page.addEventListener('click', (e) => {
        e.preventDefault();
        const targetPage = parseInt(page.querySelector('a').getAttribute('data-page'), 10);
        if (targetPage) {
            currentPage = targetPage;
            updatePagination();
        }
    });
});

// Click event for Previous button
prevButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (currentPage > 1) {
        currentPage--;
        updatePagination();
    }
});

// Click event for Next button
nextButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (currentPage < totalPages) {
        currentPage++;
        updatePagination();
    }
});

// Initialize the pagination display
updatePagination();




// script.js

// إضافة حدث عند الضغط على الصورة
document.querySelectorAll('.card img').forEach(img => {
    img.addEventListener('click', function () {
        this.classList.toggle('active');
        // يمكنك إضافة منطق لتغيير الصفحة أو عرض تفاصيل الفيلم هنا
        alert(`تم الضغط على الفيلم: ${this.alt}`);
    });
});

// يمكنك إضافة الدوال الأخرى كما في الأمثلة السابقة
let currentPage = 1;
const totalPages = 3;

function updatePagination() {
    document.getElementById("content").innerText = `Page ${currentPage} Content`;

    document.querySelectorAll(".page-item").forEach((item) => {
        item.classList.remove("active");
    });
    document.querySelector(`.page-item:nth-child(${currentPage + 1})`).classList.add("active");

    document.getElementById("prev").classList.toggle("disabled", currentPage === 1);
    document.getElementById("next").classList.toggle("disabled", currentPage === totalPages);
}

function loadPage(page) {
    if (page < 1 || page > totalPages) return;

    currentPage = page;
    updatePagination();
}

document.getElementById("prev").onclick = () => loadPage(currentPage - 1);
document.getElementById("next").onclick = () => loadPage(currentPage + 1);

updatePagination();


//dashbord
function updateCartCount() {
    fetch('/ControllerName/CartCount')
        .then(response => response.text())
        .then(count => {
            document.getElementById('cartItemCount').innerText = count;
        });
}

// استدعاء الدالة عند تحميل الصفحة
updateCartCount();

// تحديث العدد كل 30 ثانية كمثال
setInterval(updateCartCount, 30000);



/*البحث*/
<script>
    document.getElementById("searchTerm").addEventListener("input", function () {
        const searchTerm = this.value;

        // إرسال طلب إلى السيرفر في حالة وجود نص للبحث
        if (searchTerm.length > 0) {
        fetch(`/ControllerName/LiveSearch?searchTerm=${searchTerm}`)
            .then(response => response.json())
            .then(data => {
                // عرض النتائج في العنصر المحدد
                let results = document.getElementById("searchResults");
                results.innerHTML = ""; // مسح النتائج السابقة

                // تحقق من وجود نتائج
                if (data.length > 0) {
                    data.forEach(movie => {
                        results.innerHTML += `<div class="col-12 mb-2">
                                <div class="card p-3">
                                    <h5>${movie.Name}</h5>
                                    <p>Category: ${movie.Category.Name}</p>
                                    <p>Cinema: ${movie.Cinema.Name}</p>
                                </div>
                            </div>`;
                    });
                } else {
                    results.innerHTML = "<p>No results found.</p>";
                }
            });
        } else {
        document.getElementById("searchResults").innerHTML = ""; // مسح النتائج إذا كانت الخانة فارغة
        }
    });
</script>
