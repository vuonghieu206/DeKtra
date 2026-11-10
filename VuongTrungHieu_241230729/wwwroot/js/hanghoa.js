document.addEventListener("DOMContentLoaded", function () {
    const list = document.getElementById("product-list");
    const searchForm = document.getElementById("search-form");
    const searchInput = document.getElementById("search-input");

    async function loadPartial(url) {
        if (!list) return;
        try {
            const response = await fetch(url, {
                headers: { "X-Requested-With": "XMLHttpRequest" }
            });
            if (!response.ok) throw new Error("Không tải được dữ liệu.");
            list.innerHTML = await response.text();
        } catch (error) {
            console.error(error);
            window.location.href = url;
        }
    }

    document.addEventListener("click", function (event) {
        const link = event.target.closest("a.category-link");
        if (!link) return;
        event.preventDefault();
        const id = link.dataset.categoryId;
        const url = id
            ? `/HangHoa/LocTheoLoai?maLoai=${encodeURIComponent(id)}`
            : "/HangHoa/LocTheoLoai";
        document.querySelectorAll(".menu li").forEach(li => li.classList.remove("active"));
        link.closest("li")?.classList.add("active");
        loadPartial(url);
        history.pushState({}, "", link.href);
    });

    if (searchForm) {
        searchForm.addEventListener("submit", function (event) {
            event.preventDefault();
            const keyword = searchInput?.value?.trim() || "";
            loadPartial(`/HangHoa/TimKiem?tuKhoa=${encodeURIComponent(keyword)}`);
        });
    }

    window.addEventListener("popstate", function () {
        loadPartial(window.location.pathname + window.location.search);
    });
});
