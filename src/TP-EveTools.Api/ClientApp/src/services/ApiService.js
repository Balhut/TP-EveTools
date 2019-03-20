class ApiService {

  getLocalScan(localScanId) {
    return fetch(`http://localhost:5000/api/posts/${localScanId}`).then(resp =>
      resp.json()
    );
  }

  addLocalScan(post) {
    return fetch("api/LocalScan", {
      method: "POST",
      redirect: "follow",
      headers: {
        "Content-type": "application/json"
      },
      body: JSON.stringify(post)
    })
      .then(response => {
        window.location.href = response.url;
      })
      .catch(function(err) {
        console.info(err);
      });
  }
}

export default ApiService;
