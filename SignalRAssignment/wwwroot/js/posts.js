
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/postHub")
    .build();

const baseUrl = `${window.location.protocol}//${window.location.host}`;

const refreshPosts = async (postId, userId) => {
    console.log(`Post ${postId} was updated by userid ${userId}.`);
    let postsTable = document.querySelector(".posts_table_body");
    postsTable.innerHTML = "";


    const response = await fetch(`${baseUrl}/api/posts`);

    if (!response.ok) {
        const message = `An error has occured: ${response.status}`;
        throw new Error(message);
    }

    const data = await response.json();

    const posts = data.items;

    console.log({ posts });

    posts.forEach(post => {
        const row = document.createElement("tr"); // Assuming each post is a row in the table

        const postIdCell = document.createElement("td");
        postIdCell.textContent = post.postID;
        row.appendChild(postIdCell);

        const authorCell = document.createElement("td");
        authorCell.textContent = post.appUser.fullName;
        row.appendChild(authorCell);

        const createdDateCell = document.createElement("td");
        createdDateCell.textContent = post.createdDate.toString();
        row.appendChild(createdDateCell);

        const updatedDateCell = document.createElement("td");
        updatedDateCell.textContent = post.updatedDate.toString();
        row.appendChild(updatedDateCell);

        const titleCell = document.createElement("td");
        titleCell.textContent = post.title;
        row.appendChild(titleCell);

        const contentCell = document.createElement("td");
        contentCell.textContent = post.content;
        row.appendChild(contentCell);

        const publishStatusCell = document.createElement("td");
        publishStatusCell.textContent = post.publishStatus;
        row.appendChild(publishStatusCell);

        const categoryCell = document.createElement("td");
        categoryCell.textContent = post.postCategory.categoryName;
        row.appendChild(categoryCell);

        const detailsCell = document.createElement("td");
        const detailsButton = document.createElement("button");
        detailsButton.textContent = "Details";
        detailsButton.className = 'btn btn-primary';
        detailsButton.onclick = function () {
            location.href = `/Posts/${post.postID}`;
        };

        detailsCell.appendChild(detailsButton);
        row.appendChild(detailsCell);

        const deleteCell = document.createElement("td");
        const deleteButton = document.createElement("button");
        deleteButton.textContent = "Delete";
        deleteButton.className = 'btn btn-danger';
        deleteButton.onclick = function () {
            // Add delete logic here
        };
        deleteCell.appendChild(deleteButton);
        row.appendChild(deleteCell);

        // Add more cells for other post properties here

        postsTable.appendChild(row); // Append the row to the table body
    });


    //Push notifications
    const notification = document.querySelector('.noti');
    console.log({ notification });
    notification.innerHTML = '';
    notification.innerHTML = `<div class="alert alert-primary d-flex align-items-center" role="alert">
            <svg height="20" width="20" class="bi flex-shrink-0 me-2" role="img" aria-label="Info:">
                <use xlink:href="#info-fill" />
            </svg>
            <div>
                New Post!!!!
            </div>
        </div>`;
};

connection.on("ReceivePostUpdate", refreshPosts);

connection.on("ReceivePostDelete", refreshPosts);

connection.start().catch(function (err) {
    return console.error(err.toString());
});
