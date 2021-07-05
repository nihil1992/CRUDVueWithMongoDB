import UserService './user.service'

export async function getAllUsers() {

  //const response = await fetch('/api/users');
  //return await response.json();

    UserService.getAll().then((response) => {
        console.log(response.data);
        return await response.data.json();
    }).catch((error) => {
        console.log(error.response.data);
    });
        
}

export async function createUser(data) {
  //const response = await fetch(`/api/user`, {
  //    method: 'POST',
  //    headers: {'Content-Type': 'application/json'},
  //    body: JSON.stringify(data)
  //})
    UserService.createUser(data).then((response) => {
        console.log(response.data);
        return await response.data.json();
    }).catch((error) => {
        console.log(error.response.data);
    });
}