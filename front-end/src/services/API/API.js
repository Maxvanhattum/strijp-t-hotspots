import axios from "axios";

const axiosConfig = {
  baseURL: "https://www.maxvanhattum.me/api/",
  timeout: 30000
};

const axiosInstance = axios.create(axiosConfig);
axiosInstance.defaults.headers.common[""];

export default {
  GetAll() {
    return axiosInstance.get("Hotspot");
  },
  GetById(id) {
    return axiosInstance.get(`Hotspot/${id}`);
  },
  Create(body, token) {
    return axiosInstance.post("Hotspot", body, {
      headers: { Authorization: `Bearer ${token}` }
    });
  },
  Update(id, body, token) {
    return axiosInstance.put(`Hotspot/${id}`, body, {
      headers: { Authorization: `Bearer ${token}` }
    });
  },
  Delete(id) {
    return axiosInstance.delete(`Hotspot/${id}`);
  },
  Authorize(body) {
    return axiosInstance.post("Auth", body);
  }
};
