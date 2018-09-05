var path = require('path');
var nodeExternals = require('webpack-node-externals');
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    mode: "production",
    target: "web",
    node: {
        __dirname: true,
        fs: 'empty'
    },
    context: __dirname,
    // Enable sourcemaps for debugging webpack's output.
    devtool: "source-map",
    entry: path.join(__dirname, "src", "index.tsx"),
    module: {
        rules: [{
                test: /\.tsx?$/,
                loader: "awesome-typescript-loader",
                //https://github.com/TypeStrong/ts-loader/issues/40
                //loose used to enable hot-reload
                // loader: 'babel?loose=all!ts-loader',
                exclude: /(node_modules|build)/,
            },
            {
                enforce: "pre",
                test: /\.js$/,
                exclude: /(node_modules|build)/,
                use: [{
                    loader: "source-map-loader"
                }]
            },
            {
                test: /\.scss$/,
                use: [
                    "style-loader", // creates style nodes from JS strings
                    "css-loader", // translates CSS into CommonJS
                    "sass-loader" // compiles Sass to CSS
                ]
            },
            {
                test: /\.css$/,
                use: [
                    "style-loader",
                    "css-loader"
                ]
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js', ".scss"]
    },
    output: {
        filename: 'bundle.js',
        // This is where webpack-dev-server serves your bundle
        // which is created in memory.
        // To use the in-memory bundle,
        // your <script> 'src' should point to the bundle
        // prefixed with the 'publicPath', e.g.:
        //   <script src='http://localhost:9001/assets/bundle.js'>
        //   </script>
        publicPath: "/build",
        path: path.join(__dirname, "/build/")
    },
    devServer: {
        contentBase: path.join(__dirname, "/build"),
        historyApiFallback: true,
        before: function (app) {},
        after: function (app) {

        }
    },
    plugins: [
        new HtmlWebpackPlugin({
                title: "Calories",
                template: path.join(__dirname, "src", "index.html")
            },

        )
    ]

};

//https://github.com/webpack-contrib/mini-css-extract-plugin