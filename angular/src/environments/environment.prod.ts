import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44303/',
  redirectUri: baseUrl,
  clientId: 'ProductCURD_App',
  responseType: 'code',
  scope: 'offline_access ProductCURD',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ProductCURD',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44303',
      rootNamespace: 'ProductCURD',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
