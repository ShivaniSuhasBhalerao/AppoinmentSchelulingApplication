import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44348',
  redirectUri: baseUrl,
  clientId: 'AppoinmentSchelulingProject_App',
  responseType: 'code',
  scope: 'offline_access AppoinmentSchelulingProject',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'AppoinmentSchelulingProject',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44348',
      rootNamespace: 'AppoinmentSchelulingProject',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
