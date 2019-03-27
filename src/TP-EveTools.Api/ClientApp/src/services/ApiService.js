class ApiService {
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
        window.location.href = `LocalScan/${data.id}`;
      })
      .catch(function(err) {
        console.info(err);
      });
  }

  addDScan(post) {
    return fetch("api/DScan", {
      method: "POST",
      headers: {
        "Content-type": "application/json"
      },
      body: JSON.stringify(post)
    })
      .then(resp => resp.json())
      .then(data => {
        window.location.href = `DScan/${data.id}`;
      })
      .catch(function(err) {
        console.info(err);
      });
  }
}

export default ApiService;
