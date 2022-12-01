import { isDevMode } from '@angular/core';

const BaseUrlDev = 'https://localhost:44406';
const BaseUrlProd = '';

const WebApiUrls = {
  UsersUrl: 'users',
};

const DevUrl = {
  UsersUrl: `${BaseUrlDev}/${WebApiUrls.UsersUrl}`,
};

const ProdUrl = {
  UsersUrl: `${BaseUrlProd}/${WebApiUrls.UsersUrl}`,
};

const apiConstant = isDevMode() ? DevUrl : ProdUrl;

export default apiConstant;

