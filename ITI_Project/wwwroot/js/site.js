function showPage(id) {
    document.querySelectorAll('.page').forEach(p => p.classList.remove('active'));
    document.getElementById('page-' + id).classList.add('active');
    document.querySelectorAll('.nav-item').forEach(b => b.classList.remove('active'));
    const btn = document.querySelector('.nav-item[data-page="' + id + '"]');
    if (btn) btn.classList.add('active');
}
document.querySelectorAll('.nav-item[data-page]').forEach(btn => {
    btn.addEventListener('click', () => showPage(btn.dataset.page));
});

function showAuthForm(which) {
    document.querySelectorAll('.auth-form').forEach(f => f.classList.remove('active'));
    document.getElementById('form-' + which).classList.add('active');
    document.querySelectorAll('.auth-tab').forEach(t => t.classList.remove('active'));
    document.querySelectorAll('.auth-tab')[which === 'login' ? 0 : 1].classList.add('active');
}

document.getElementById('generateSummaryBtn').addEventListener('click', async function () {
    const backCoverText = document.getElementById('backCoverText').value.trim();
    const errorBox = document.getElementById('aiErrorMsg');
    const btn = document.getElementById('generateSummaryBtn');
    const btnText = document.getElementById('btnText');
    const spinner = document.getElementById('btnSpinner');
    const suggestionBox = document.getElementById('aiSuggestionBox');

    errorBox.classList.add('d-none');
    errorBox.textContent = '';
    if (suggestionBox) suggestionBox.classList.add('d-none');

    if (!backCoverText) {
        errorBox.textContent = 'Please enter the back cover text first.';
        errorBox.classList.remove('d-none');
        return;
    }

    btn.disabled = true;
    btnText.textContent = 'Generating...';
    spinner.classList.remove('d-none');

    try {
        const response = await fetch('/Book/AutoSummary', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ BackCoverText: backCoverText })
        });

        const result = await response.json();

        // 👇 الجزء ده هو اللي بيحل محل اللي كان موجود قبل كده
        if (result.success) {
            document.getElementById('Create_Summary').value = result.data.summary || '';

            if (suggestionBox) {
                document.getElementById('aiSuggestedCategory').textContent = result.data.category || '—';
                document.getElementById('aiSuggestedTags').textContent = (result.data.tags || []).join(', ');
                suggestionBox.classList.remove('d-none');
            }

            // Auto-select الـ dropdown بناءً على الاسم
            const categorySelect = document.getElementById('Create_CategoryId');
            if (categorySelect && result.data.category) {
                const match = Array.from(categorySelect.options)
                    .find(opt => opt.text.trim().toLowerCase() === result.data.category.trim().toLowerCase());
                if (match) categorySelect.value = match.value;
            }
        } else {
            errorBox.textContent = result.message || 'An error occurred while generating the summary.';
            errorBox.classList.remove('d-none');
        }
    } catch (err) {
        errorBox.textContent = 'Could not connect to the server. Please try again.';
        errorBox.classList.remove('d-none');
    } finally {
        btn.disabled = false;
        btnText.textContent = 'Generate Auto Summary';
        spinner.classList.add('d-none');
    }
});