import responsitory from '../responsitory/responsitory'
//import axios from 'axios';
const resource = '/user'
export default {
  getAllUser(){
    return responsitory.get(`${resource}/getAllUser`);
  },
  getById (usid) {
    return responsitory.get(`${resource}/getById?usid=${usid}`)
  },
  create (user) {
    return responsitory.post(`${resource}/insert`, user)
  },
  update (user) {
    return responsitory.put(`${resource}/update`, user)
  },
  delete (userid) {
    return responsitory.delete(`${resource}/delete?usid=${userid}`)
  },
  createFisrtUser (){
    return responsitory.get(`${resource}/createFirstUser`)
  },
  search(dataFilter){
    return responsitory.post(`${resource}/search`,dataFilter)
  },
  changePass(data){
    return responsitory.post(`${resource}/changePass`,data)
  },
  deleteListUser(data){
    return responsitory.post(`${resource}/deleteListUser`,data)
  }
}
