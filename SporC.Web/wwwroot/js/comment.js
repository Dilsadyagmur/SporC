function sendComment() {
    var PostId = $("#comment_PostId").val();
    var Content = $("#comment_Content").val();
    $.post('/post/createcomment/', { PostId, Content }).done(function (response) {
        var data = JSON.parse(response);



        var newPostCardHtml = `<div id="post-container" class="post-container">
							<div class="post-card">
							<p>@${data.username}</p>
                            <p>${data.Content}</p>
                            <p>${data.CreatedDate}</p>
									<div class="comment-buttons" style="display: flex; gap: 10px;">
										<form method="post" onsubmit="return confirm('Bu yorumu silmek istediğinizden emin misiniz?');" action="/Post/DeleteComment/${data.Id}">
											<button type="submit" class="btn btn-primary">Delete</button>
										</form>
										
									</div>
							</div>
							</div>`


        var container = document.getElementById("post-container");
        var newDiv = document.createElement("div");
        newDiv.innerHTML = newPostCardHtml;
        container.insertBefore(newDiv.firstChild, container.firstChild)
        $("#comment_Content").val("");

    });



}