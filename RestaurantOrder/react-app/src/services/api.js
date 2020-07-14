
import axios from 'axios';

const api = axios.create({
    baseURL:'http://localhost:51822/api'
});

export default api;
