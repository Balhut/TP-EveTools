class ApiService {

  getLocalScan(localScanId) {
    return fetch(`https://localhost:5001/api/LocalScan/${localScanId}`).then(resp =>
      resp.json()
    );
  }

  addLocalScan(post) {
    return fetch("https://localhost:5001/api/LocalScan", {
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
