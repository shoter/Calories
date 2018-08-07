import {ValidationResult} from "../../src/Validators/ValidationResult";
import { ValidationStatus } from "../../src/Validators/ValidationStatus";
import { ValidationError } from "../../src/Validators/ValidationError";

describe("Validation result tests", function() {
    it("is success if newly created", function() {
        var r = new ValidationResult();
       
        expect(r.validationStatus)
        .toBe(ValidationStatus.SUCCESS);
    });

    it("is success for prototype.success", function() {
        var r = ValidationResult.prototype.success;

        expect(r.validationStatus)
        .toBe(ValidationStatus.SUCCESS);
    });

    it("is failed for prototype.fail", function() {
        var r = ValidationResult.prototype.fail;

        expect(r.validationStatus)
        .toBe(ValidationStatus.FAILED);
    });

    it("is failed after adding one error", function() {
        var r= new ValidationResult();
        r.addError("Siema eniu");

        expect(r.validationStatus)
        .toBe(ValidationStatus.FAILED);
    });

    it("Can add errors by string", function() {
        var str = "kek error";
        var r = new ValidationResult();
        r.addError(str);

        expect(r.validationErrors[0].errorMessage)
        .toBe(str);
        expect(r.validationErrors.length)
        .toBe(1);
    });

    it("Can add errors by ValidationError", function() {
        var error = new ValidationError("kek");
        var r = new ValidationResult();
        r.addError(error);

        expect(r.validationErrors[0])
        .toBe(error);
        expect(r.validationErrors.length)
        .toBe(1);
    });

});