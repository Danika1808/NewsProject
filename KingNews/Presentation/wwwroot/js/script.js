$(document).ready(function () {
    $(".popular-news").on("click", ".nav-item", function() {
        $(".popular-news .nav-item").removeClass("active");
        $(".popular-news .nav-link").removeClass("active");
        $(".popular-news .tab-form").removeClass("active-form");
        
        console.log($(this).index());
        
        $(this).addClass("active");
        $(".popular-news .nav-link").eq($(this).index()).addClass("active");
        $(".popular-news .tab-form").eq($(this).index()).addClass("active-form");
    });
});

const uri = 'api/Posts';

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => DisplayPosts(data))
        .catch(error => console.error('Unable to get items.', error));
}

function getItemsByCategory(category) {
    fetch(`${uri}/${category}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => DisplayPosts(data))
        .catch(error => console.error('Unable to get items.', error));
}

function DisplayPosts(data) {
    const template = document.getElementById('post-template');
    const postTemplate = template.content.querySelector('.post');

    data.forEach(post => {
        const postElem = document.importNode(postTemplate, true);
        for (const key in post) {
            if (key === 'photos') {
                postElem.querySelector('.photos').src = post.photos[0].patch;
            }
            if (key === 'comments') {
                postElem.querySelector('.comments').textContent = post.comments.length;
            }
            if (key === 'categories') {
                postElem.querySelector('.categories').textContent = post.categories[0].name;
            }
            if (key === 'content') {
                postElem.querySelector('.content').textContent = post.content.split('.')[0];
            }
                else {
                postElem.querySelector('.' + key).textContent = post[key]
            }
        }
        document.body.appendChild(postElem)
    });

}




