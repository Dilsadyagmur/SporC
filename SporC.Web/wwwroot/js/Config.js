// config.js

// Diğer CKEditor yapılandırma ayarları...

// Fotoğraf yükleme özelliğini devre dışı bırakma
CKEDITOR.editorConfig = function (config) {
    // Diğer ayarlar...

    // Eğer bu özelliği devre dışı bırakmak istiyorsanız:
    config.removePlugins = 'image';
    config.removeButtons = 'Image';

    // Diğer ayarlar...
};
