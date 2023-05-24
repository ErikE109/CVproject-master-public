const companyDiv = document.getElementById("name-github");

function getData(url, cb) {
    fetch(url)
        .then((response) => response.json())
        .then((result) => cb(result));
}


function getUserInput() {
    var GithubUsername = document.getElementById("inputGithub").value;

    getData(`https://api.github.com/users/${GithubUsername}/repos`, (data) => {
        for (let i = 0; i < data.length; i++) { 

            
            const p = document.createElement("p");

            p.textContent = data[i].name;
            companyDiv.appendChild(p);
        }
    }
    );
}






