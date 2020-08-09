
import responsitory from '../responsitory/responsitory'
//import axios from 'axios';
const resource = '/auth'
export default {
  login (auth){
    return responsitory.post(`${resource}/login`, auth)
  }
}
