const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    return [{
        stats: { modules: false },
        entry: { 'main': './ClientApp/boot.jsx' },
        resolve: { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: 'dist/'
        },
        module: {
            rules: [
                {
                    test: /\.(js|jsx)$/i,
                    exclude: /(node_modules)/,
                    use: [
                        // {
                        //     // loader: "inconv-lite?inputEncoding=iso-8859-1",
                        //     loader: "iconv-lite-loader?inputEncoding=iso-8859-1",
                        // },
                        {
                            loader: 'babel-loader',
                            query: {
                                cacheDirectory: true,
                                presets: ['env', 'react'],
                                plugins: [
                                    'transform-class-properties',
                                    'transform-object-rest-spread',
                                    'syntax-trailing-function-commas',
                                    [
                                        'babel-plugin-root-import', {
                                            rootPathPrefix: '/',
                                            rootPathSuffix: 'ClienteApp/',
                                        },
                                    ],
                                ],
                            },
                        },
                    ],
                },
                {
                    test: /\.scss$/,
                    use: [{
                        loader: 'style-loader', // creates style nodes from JS strings
                    }, {
                        loader: 'css-loader', // translates CSS into CommonJS
                    }, {
                        loader: 'sass-loader', // compiles Sass to CSS
                    }],
                },
                { test: /\.tsx?$/, include: /ClientApp/, use: 'awesome-typescript-loader?silent=true' },
                {
                    test: /\.css$/,
                    exclude: /flexboxgrid/,
                    use: [
                        {
                            loader: 'style-loader',
                        }, {
                            loader: 'css-loader',
                        },
                    ],
                },
                {
                    test: /\.(jpe|jpeg|png|gif|svg|eot|ttf|woff|woff2)$/i,
                    use: [{ loader: 'file-loader' }],
                },
                {
                    test: /\.css$/,
                    include: /flexboxgrid/,
                    use: [
                        {
                            loader: 'style-loader',
                        }, {
                            loader: 'css-loader',
                            options: {
                                modules: true,
                                // localIdentName: '[path][name]__[local]--[hash:base64:5]'
                                localIdentName: '[local]__[hash:base64:5]-rfbg',
                            },
                        },
                    ],
                },
            ]
        },
        //        presets: ["@babel/preset-env"],
        plugins: [
            new CheckerPlugin(),
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new webpack.optimize.UglifyJsPlugin(),
                new ExtractTextPlugin('site.css')
            ])
    }];
};