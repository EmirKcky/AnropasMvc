# ANROPAS Frontend

Bu klasör, ANROPAS projesinin frontend dosyalarını içerir.

## Klasör Yapısı

```
frontend/
├── css/
│   └── style.css
├── js/
│   └── auth.js
├── img/
├── login.html
├── register.html
├── company-selection.html
├── company-create.html
└── company-join.html
```

## Özellikler

- Modern ve koyu tema tasarımı
- Responsive tasarım
- Form doğrulama
- Dosya yükleme desteği
- Şifre gücü göstergesi
- Animasyonlu geçişler

## Kullanılan Teknolojiler

- HTML5
- CSS3 (CSS Variables, Flexbox, Grid)
- JavaScript (ES6+)
- Font Awesome 6.4.0
- Google Fonts (Poppins)

## Kurulum

1. Dosyaları web sunucunuza yükleyin
2. `backend` klasörünü oluşturun ve PHP dosyalarını ekleyin
3. Gerekli veritabanı bağlantılarını yapılandırın

## Geliştirme

Frontend geliştirmesi için:
1. CSS değişiklikleri için `css/style.css` dosyasını düzenleyin
2. JavaScript fonksiyonları için `js/auth.js` dosyasını düzenleyin
3. Sayfa yapısı için ilgili HTML dosyalarını düzenleyin

## Notlar

- Backend API'leri `backend/` klasöründe bulunmalıdır
- Tüm formlar backend'e POST isteği gönderir
- Dosya yüklemeleri için `enctype="multipart/form-data"` kullanılır 