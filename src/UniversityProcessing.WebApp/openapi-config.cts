import { ConfigFile } from '@rtk-query/codegen-openapi'

const feature: string = "backendApi"

const config: ConfigFile = {
  schemaFile: 'http://localhost:5158/swagger/v1/swagger.json',
  apiFile: './src/core/emptyApi.ts',
  apiImport: 'emptySplitApi',
  outputFile: `./src/apis/${feature}.ts`,
  exportName: feature,
  hooks: true,
}

export default config