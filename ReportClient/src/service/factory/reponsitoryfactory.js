import userReponsitory from "../impl/userReponsitory";
import authReponsitory from "../impl/authReponsitory";
import reportResponsitory from "../impl/reportResponsitory";

const responsitories = {
  user: userReponsitory,
  auth: authReponsitory,
  report: reportResponsitory
};
export default {
  get: name => responsitories[name]
};
