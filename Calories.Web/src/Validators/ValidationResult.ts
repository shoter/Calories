import { ValidationError } from "./ValidationError";
import { ValidationStatus } from "./ValidationStatus";

class ValidationResult {
  validationErrors: ValidationError[];
  validationStatus: ValidationStatus;

  constructor() {
    this.validationErrors = [];
    this.validationStatus = ValidationStatus.SUCCESS;
  }

  addError(error: ValidationError | string) {
    let validationError: ValidationError;
    if (error instanceof ValidationError) validationError = error;
    else validationError = new ValidationError(error);

    this.validationErrors.push(validationError);
    this.validationStatus = ValidationStatus.FAILED;
  }

  isValid(): Boolean {
    return this.validationStatus == ValidationStatus.SUCCESS;
  }
}

interface ValidationResult {
  success: ValidationResult;
  fail: ValidationResult;
}

ValidationResult.prototype.success = new ValidationResult();
ValidationResult.prototype.fail = new ValidationResult();
ValidationResult.prototype.fail.validationStatus = ValidationStatus.FAILED;

export { ValidationResult };
