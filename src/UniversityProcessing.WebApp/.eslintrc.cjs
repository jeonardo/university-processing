module.exports = {
    root: true,
    env: {browser: true, es2020: true},
    extends: [
        'plugin:@typescript-eslint/recommended',
        'prettier',
        'plugin:react/jsx-runtime',
        'plugin:jsx-a11y/recommended',
        'plugin:react-hooks/recommended',
        'eslint:recommended',
        'plugin:react/recommended'
    ],
    ignorePatterns: ['dist', '.eslintrc.cjs'],
    parser: '@typescript-eslint/parser',
    plugins: ["prettier", 'react-refresh'],
    rules: {
        'react-refresh/only-export-components': [
            'warn',
            {allowConstantExport: true},
        ],
        "no-restricted-imports": "off",
        "@typescript-eslint/no-restricted-imports": [
            "warn",
            {
                "name": "react-redux",
                "importNames": ["useSelector", "useDispatch"],
                "message": "Use typed hooks `useAppDispatch` and `useAppSelector` instead."
            }
        ],
    },
}
