function sendComment() {
    var PostId = $("#comment_PostId").val();
    var Content = $("#comment_Content").val();
    $.post('/post/createcomment/', { PostId, Content }).done(function (response) {
        var data = JSON.parse(response);

        var newPostCardHtml = `<div class="post-card">
            <p>${data.Content}</p>
            <form action="/Post/DeleteById/${data.Id}" method="post" onsubmit="return confirm('Bu yorumu silmek         istediğinizden emin misiniz?');">
                <button type="submit" class="btn btn-danger">Sil</button>
            </form>
            <a href="/Post/UpdatePost/${data.Id}" class="btn btn-primary">Güncelle</a>
        </div>`;

        var container = document.getElementById("post-container");
        var newDiv = document.createElement("div");
        newDiv.innerHTML = newPostCardHtml;
        container.insertBefore(newDiv.firstChild, container.firstChild)
        $("#comment_Content").val("");

    });
    


}