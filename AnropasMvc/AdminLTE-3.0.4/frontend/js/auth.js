// Şifre göster/gizle işlevselliği
document.addEventListener('DOMContentLoaded', function() {
    // Şifre göster/gizle işlevselliği
    const togglePasswordButtons = document.querySelectorAll('.toggle-password');
    
    togglePasswordButtons.forEach(button => {
        button.addEventListener('click', function() {
            const passwordInput = this.previousElementSibling;
            
            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                this.classList.remove('fa-eye-slash');
                this.classList.add('fa-eye');
            } else {
                passwordInput.type = 'password';
                this.classList.remove('fa-eye');
                this.classList.add('fa-eye-slash');
            }
        });
    });
    
    // Şifremi Unuttum Formu
    const forgotPasswordLink = document.getElementById('forgot-password-link');
    const loginForm = document.getElementById('login-form');
    const forgotPasswordForm = document.getElementById('forgot-password-form');
    const backToLoginBtn = document.getElementById('back-to-login');
    
    if (forgotPasswordLink && loginForm && forgotPasswordForm && backToLoginBtn) {
        forgotPasswordLink.addEventListener('click', function(e) {
            e.preventDefault();
            loginForm.style.display = 'none';
            forgotPasswordForm.style.display = 'block';
        });
        
        backToLoginBtn.addEventListener('click', function() {
            forgotPasswordForm.style.display = 'none';
            loginForm.style.display = 'block';
        });
    }
    
    // Şifre Gücü Kontrolü
    const passwordInput = document.getElementById('password');
    const strengthMeter = document.querySelector('.strength-meter-fill');
    const strengthText = document.querySelector('.strength-text span');
    
    if (passwordInput && strengthMeter && strengthText) {
        passwordInput.addEventListener('input', function() {
            const strength = checkPasswordStrength(this.value);
            strengthMeter.setAttribute('data-strength', strength);
            strengthText.textContent = getStrengthText(strength);
        });
    }
});

// Şifre göster/gizle fonksiyonu (inline onclick için)
function togglePasswordVisibility(icon) {
    const passwordInput = icon.previousElementSibling;
    
    if (passwordInput.type === 'password') {
        passwordInput.type = 'text';
        icon.classList.remove('fa-eye-slash');
        icon.classList.add('fa-eye');
    } else {
        passwordInput.type = 'password';
        icon.classList.remove('fa-eye');
        icon.classList.add('fa-eye-slash');
    }
}

// Şifre gücü kontrolü fonksiyonu
function checkPasswordStrength(password) {
    let strength = 0;
    
    if (password.length >= 8) strength++;
    if (password.match(/[a-z]/) && password.match(/[A-Z]/)) strength++;
    if (password.match(/\d/)) strength++;
    if (password.match(/[^a-zA-Z\d]/)) strength++;
    
    return strength;
}

// Şifre gücü metni fonksiyonu
function getStrengthText(strength) {
    switch(strength) {
        case 0:
            return 'Çok Zayıf';
        case 1:
            return 'Zayıf';
        case 2:
            return 'Orta';
        case 3:
            return 'Güçlü';
        case 4:
            return 'Çok Güçlü';
        default:
            return 'Zayıf';
    }
}

// Form doğrulama ve gönderme işlemleri
document.addEventListener('DOMContentLoaded', function() {
    // Login formu
    const loginForm = document.getElementById('loginForm');
    if (loginForm) {
        loginForm.addEventListener('submit', function(e) {
            e.preventDefault();
            validateAndSubmitForm(this);
        });
    }

    // Register formu
    const registerForm = document.getElementById('registerForm');
    if (registerForm) {
        registerForm.addEventListener('submit', function(e) {
            e.preventDefault();
            validateAndSubmitForm(this);
        });
    }

    // Dosya yükleme alanı
    const fileUpload = document.querySelector('.file-upload');
    if (fileUpload) {
        fileUpload.addEventListener('dragover', function(e) {
            e.preventDefault();
            this.classList.add('dragover');
        });

        fileUpload.addEventListener('dragleave', function() {
            this.classList.remove('dragover');
        });

        fileUpload.addEventListener('drop', function(e) {
            e.preventDefault();
            this.classList.remove('dragover');
            const file = e.dataTransfer.files[0];
            if (file) {
                const input = this.querySelector('input[type="file"]');
                input.files = e.dataTransfer.files;
            }
        });
    }
});

// Form doğrulama ve gönderme fonksiyonu
function validateAndSubmitForm(form) {
    // Form alanlarını kontrol et
    const inputs = form.querySelectorAll('input[required], select[required], textarea[required]');
    let isValid = true;

    inputs.forEach(input => {
        if (!input.value.trim()) {
            showError(input, 'Bu alan zorunludur');
            isValid = false;
        } else {
            clearError(input);
        }
    });

    // Özel doğrulamalar
    if (form.id === 'registerForm') {
        const password = form.querySelector('#password');
        const passwordConfirm = form.querySelector('#password_confirm');
        
        if (password && passwordConfirm && password.value !== passwordConfirm.value) {
            showError(passwordConfirm, 'Şifreler eşleşmiyor');
            isValid = false;
        }
    }

    // Form geçerliyse gönder
    if (isValid) {
        submitForm(form);
    }
}

// Form gönderme fonksiyonu
function submitForm(form) {
    const formData = new FormData(form);
    
    fetch(form.action, {
        method: form.method,
        body: formData
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            showSuccess(data.message);
            if (data.redirect) {
                setTimeout(() => {
                    window.location.href = data.redirect;
                }, 1500);
            }
        } else {
            showError(form, data.message);
        }
    })
    .catch(error => {
        showError(form, 'Bir hata oluştu. Lütfen tekrar deneyin.');
        console.error('Error:', error);
    });
}

// Hata mesajı gösterme
function showError(input, message) {
    const formGroup = input.closest('.form-group');
    let errorDiv = formGroup.querySelector('.error-message');
    
    if (!errorDiv) {
        errorDiv = document.createElement('div');
        errorDiv.className = 'error-message';
        formGroup.appendChild(errorDiv);
    }
    
    errorDiv.textContent = message;
    input.classList.add('error');
}

// Hata mesajını temizleme
function clearError(input) {
    const formGroup = input.closest('.form-group');
    const errorDiv = formGroup.querySelector('.error-message');
    
    if (errorDiv) {
        errorDiv.remove();
    }
    
    input.classList.remove('error');
}

// Başarı mesajı gösterme
function showSuccess(message) {
    const successDiv = document.createElement('div');
    successDiv.className = 'success-message';
    successDiv.textContent = message;
    
    document.body.appendChild(successDiv);
    
    setTimeout(() => {
        successDiv.remove();
    }, 3000);
}