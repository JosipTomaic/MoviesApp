const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = 'https://localhost:7059';

const context = [
  "/weatherforecast",
];

module.exports = function (app) {
  debugger;
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false
  });

  app.use(appProxy);
};
