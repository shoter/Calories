const {defaults} = require('jest-config');
module.exports = {
  // ...
  "transform": {
    "^.+\\.tsx?$": "ts-jest"
  },
  moduleFileExtensions: [...defaults.moduleFileExtensions, 'ts', 'tsx'],
  testRegex:  "tests/.*\\.test.tsx?" 
  // ...
};