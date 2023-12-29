

//post create js
    ClassicEditor
    .create(document.querySelector('#editorTitle'))
        .then(editor => {
        console.log(editor);
        })
        .catch(error => {
        console.error(error);
        });

    ClassicEditor
    .create(document.querySelector('#editorContent'))
        .then(editor => {
        console.log(editor);
        })
        .catch(error => {
        console.error(error);
        });

}

    function reloadPage() {
        window.location.reload();
    }


    // CKEditor'in yüklenmesini bekleyin
    CKEDITOR.replace('editor', {
        // CKEditor yapılandırma ayarları...
    });

    // Post içeriğini CKEditor'e yükleyin
    CKEDITOR.instances.editor.setData('@Html.Raw(post.Content)');

CKEDITOR.replace('editor', {
    // CKEditor yapılandırma ayarları...
});

// Post içeriğini CKEditor'e yükleyin
CKEDITOR.instances.editor.setData('@Html.Raw(post.Content)');

$(document).ready(function () {
    $("#filterDropdownBtn").click(function () {
        $(".dropdown-menu").toggle(); // Dropdown'ı göster/gizle
    });
});
