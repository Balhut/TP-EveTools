class ApiService {
  getPosts() {
    return fetch("http://localhost:5000/api/posts/").then(resp => resp.json());
    //return Promise.resolve([]);
  }

  getMyPosts(authorEmail) {
    return fetch(`http://localhost:5000/api/authors/posts/${authorEmail}`).then(
      resp => resp.json()
    );
  }

  getPost(postId) {
    return fetch(`http://localhost:5000/api/posts/${postId}`).then(resp =>
      resp.json()
    );
  }

  getPostsFromBlog(blogName) {
    return fetch(`http://localhost:5000/api/posts/from/${blogName}`).then(
      resp => resp.json()
    );
  }

  addLocalScan(post) {
    return fetch("http://localhost:5000/api/posts/", {
      method: "POST",
      headers: {
        "Content-type": "application/json"
      },
      body: JSON.stringify(post)
    });
    //.then((resp) => resp.json())
  }
}

export default ApiService;
