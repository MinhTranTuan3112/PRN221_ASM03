
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/postHub")
    .build();

const baseUrl = `${window.location.protocol}//${window.location.host}`;

const createPostCard = (post) => {
    // Create the main card div
    const card = document.createElement('div');
    card.className = 'card';
    card.style = '';

    // Create the card body
    const cardBody = document.createElement('div');
    cardBody.className = 'card-body';

    // Create the title
    const title = document.createElement('h5');
    title.className = 'card-title';
    title.textContent = post.title;

    // Create the subtitle
    const subtitle = document.createElement('h6');
    subtitle.className = 'card-subtitle mb-2';
    subtitle.style.color = 'grey';
    subtitle.textContent = `Created on ${post.createdDate}`;

    // Create the content paragraph
    const content = document.createElement('p');
    content.className = 'card-text post_card_text';
    content.textContent = post.content;

    // Create the view button
    const viewButton = document.createElement('button');
    viewButton.type = 'button';
    viewButton.className = 'btn btn-primary';
    viewButton.textContent = 'View';
    viewButton.onclick = () => location.href = `/posts/${post.postID}`;

    // Create the delete button
    const deleteButton = document.createElement('button');
    deleteButton.type = 'button';
    deleteButton.className = 'btn btn-danger';
    deleteButton.textContent = 'Delete';

    // Append all elements to the card body
    cardBody.appendChild(title);
    cardBody.appendChild(subtitle);
    cardBody.appendChild(content);
    cardBody.appendChild(viewButton);
    cardBody.appendChild(deleteButton);

    // Append the card body to the main card div
    card.appendChild(cardBody);

    return card;
};


const refreshPosts = async (postId, userId) => {

    console.log(`Post ${postId} was updated by userid ${userId}.`);

    const response = await fetch(`${baseUrl}/api/posts/user/${userId}`);

    if (!response.ok) {
        const message = `An error has occured: ${response.status}`;
        throw new Error(message);
    }

    const posts = await response.json();

    console.log({ posts });

    const postContent = document.querySelector('.posts_info_content');

    postContent.innerHTML = '';

    posts.forEach(post => {
        const card = createPostCard(post);
        postContent.appendChild(card);
    });


    //Push notifications

};

connection.on("ReceivePostUpdate", refreshPosts);

connection.start().catch(function (err) {
    return console.error(err.toString());
});
