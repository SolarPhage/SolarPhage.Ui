// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

var path = require("path");

module.exports = {
    mode: "production",
    entry: "./src/App.fs.js",
    watch: "false",
    output: {
        path: path.join(__dirname, "./public"),
        filename: "bundle.js",
    },
    devServer: {
        devMiddleware: {
            publicPath: "/",
        },
        static: "./public",
        port: 8080,
    },
    module: {
    }
}
