const {defaults} = require('jest-config');
module.exports = {
  setupFiles: [
    "./tests.compile.js"
  ],
  moduleFileExtensions: [...defaults.moduleFileExtensions, 'ts', 'tsx'],
  testRegex:  "tests/.*\\.test.tsx?" 
  // ...
};