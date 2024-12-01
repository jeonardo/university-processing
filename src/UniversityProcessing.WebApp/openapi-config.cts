import { ConfigFile } from '@rtk-query/codegen-openapi';

const config: ConfigFile = {
  schemaFile: 'http://localhost:5158/swagger/v1/swagger.json',
  apiFile: './src/api/emptyApi.ts',
  apiImport: 'emptySplitApi',
  outputFile: `./src/api/backendApi.ts`,
  exportName: 'backendApi',
  hooks: { lazyQueries: true, mutations: true, queries: true },
  useEnumType: true

};

export default config;