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
