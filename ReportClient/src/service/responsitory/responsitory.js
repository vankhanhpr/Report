import axios from "axios";
const baseDomain = "http://localhost:56424";
//const baseDomain = 'https://10.70.105.15:5005';
const baseUrl = `${baseDomain}/api`;
//const baseUrl =  'https://jsonplaceholder.typicode.com'
var token = getTokenByLocal();
// var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6IjAzNTQ2NzUxLTBmNDgtNDZmZS1hMWNkLWRkYzZmZWU0NmQwOSIsImlhdCI6IjIyLzA3LzIwMjAgMjo0NToxMSBBTSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IjEiLCJuYmYiOjE1OTUzODU5MTEsImV4cCI6MTU5NTQ3MjMxMSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMTEiLCJhdWQiOiJLaGFuaE5ndXllbklUIn0.Gaea0UT1v6YsPhUc82m6sfhpyvdOGvgohHRAMib0CDc";
const instance = axios.create({
  baseURL: baseUrl,
  headers: {
    'authorization': `Bearer ${token}`,
  }
});

function getTokenByLocal() {
  var section_local = getCookie("token_session");

  if (section_local) {
    var tok = strToObj(getCookie("token_session"));
    console.log(tok.token);
    return tok.token;
  }
  return "";
}

function getCookie(cname) {
  //get cookie by local
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(";");
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) === " ") {
      c = c.substring(1);
    }
    if (c.indexOf(name) === 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

function strToObj(str) {
  //convert string to object
  var obj = {};
  if (str && typeof str === "string") {
    var objStr = str.match(/\{(.)+\}/g);
    eval("obj =" + objStr);
  }
  return obj;
}
export default instance;
