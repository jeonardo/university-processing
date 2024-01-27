/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_APP_TITLE: string
    readonly VITE_IS_DEVELOPMENT: string
    readonly VITE_BACKEND_BASEURL: string
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}