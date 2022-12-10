// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

const MiniCssExtractPlugin = require("mini-css-extract-plugin");

var path = require("path");

module.exports = {
    mode: "productions",
    entry: "./src/App.fs.js",
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
        rules: [{
          test: /\.scss$/,
          use: [
              MiniCssExtractPlugin.loader,
              {
                loader: 'css-loader'
              },
              {
                loader: 'sass-loader',
                options: {
                  sourceMap: true,
                }
              }
            ]
        }]
      },
      plugins: [
        new MiniCssExtractPlugin({
          filename: 'css/main.css'
        }),
      ]
}
