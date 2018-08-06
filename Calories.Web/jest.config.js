const {defaults} = require('jest-config');
module.exports = {
  "transform": {
    "^.+\\.tsx?$": "ts-jest"
  },
  "globals": {
      'ts-jest':
      {
          "tsConfigFile" : "tsconfig.tests.json"
      }
  },
  moduleFileExtensions: [...defaults.moduleFileExtensions, "ts", "tsx"],
  testRegex: "/tests/[^^]*\\.test.tsx?"
 // testMatch: ["<rootDir>/tests/*.test.ts"]
 // testRegex:  "tests-compiled/.*\\.test.jsx?" 
  // ...
};