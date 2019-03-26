class ApiService {
  getLocalScan(localScanId) {
    return fetch(`http://localhost:5000/api/posts/${localScanId}`).then(resp =>
      resp.json()
    );
  }

  addLocalScan(post) {
    return fetch("api/LocalScan", {
      method: "POST",
      headers: {
        "Content-type": "application/json"
      },
      body: JSON.stringify(post)
    })
      .then(resp => resp.json())
      .then(data => {
        window.location.href = `LocalScan/${data.id}`
      })
      .catch(function(err) {
        console.info(err);
      });
  }
}

export default ApiService;
