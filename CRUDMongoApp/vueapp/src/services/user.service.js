import Axios from 'axios';


Axios.defaults.baseURL = "https://localhost:44328/api";
const RESOURCE_NAME = '/users';
const USER_API = '/user';
export default {
    getAll() {

        return Axios.get(RESOURCE_NAME).catch((error) => {
            console.log(error);
        });
    },
    get(id) {
        return Axios.get(`${RESOURCE_NAME}/${id}`);
    },
    create(data) {
        return Axios.post(RESOURCE_NAME, data);
    },
    update(id, data) {
        return Axios.put(`${RESOURCE_NAME}/${id}`, data);
    },
    delete(id) {
        return Axios.delete(`${RESOURCE_NAME}?id=${id}`);
    }
};