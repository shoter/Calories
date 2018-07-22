"use strict";
console.log("Running test.js");
const jest = require("jest");
const tsc = require("typescript");
const fs = require("fs");
const path = require("path");
const nrc = require("node-run-cmd");
function reportDiagnostics(diagnostics) { 
    diagnostics.forEach(diagnostic => {
        let message = "TS";
        if (diagnostic.file) {
            let { line, character } = diagnostic.file.getLineAndCharacterOfPosition(diagnostic.start);
            message += ` ${diagnostic.file.fileName} (${line + 1},${character + 1})`;
        }
        message += ": " + diagnostic.messageText;
        console.log(message);
    });
}

function readConfigFile(configFileName) { 
    // Read config file
    const configFileText = fs.readFileSync(configFileName).toString();  

    // Parse JSON, after removing comments. Just fancier JSON.parse
    const result = tsc.parseConfigFileTextToJson(configFileName, configFileText);
    const configObject = result.config;
    if (!configObject) {
        reportDiagnostics([result.error]);
        process.exit(1);;
    }

    // Extract config infromation
    const configParseResult = tsc.parseJsonConfigFileContent(configObject, tsc.sys, path.dirname(configFileName));
    if (configParseResult.errors.length > 0) {
        reportDiagnostics(configParseResult.errors);
        process.exit(1);
    }
    return configParseResult;
}


function compile(configFileName) {
    // Extract configuration from config file
    let config = readConfigFile(configFileName);
    // Compile
    let program = tsc.createProgram(config.fileNames, config.options);
    let emitResult = program.emit();

    // Report errors
    reportDiagnostics(tsc.getPreEmitDiagnostics(program).concat(emitResult.diagnostics));

    // Return code
    let exitCode = emitResult.emitSkipped ? 1 : 0;
   // process.exit(exitCode);
}


nrc.run("tsc -p .\tsconfig.tests.json")
jest.run();
console.log("Completed running test.js");
