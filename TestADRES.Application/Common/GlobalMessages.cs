namespace TestADRES.Application.Common
{
    public static class GlobalMessages
    {
        // Mensajes Exceptions
        public static string ValidationExceptionMessage => "Se presentaron uno o mas errores de validacion.";
        public static string InvalidGuidMessage(string fieldName) => $"{fieldName} is not a valid GUID.";

        // Mensajes de éxito
        public static string SuppliersRetrievedSuccessfully => "Suppliers retrieved successfully.";
        public static string BusinessUnitsRetrievedSuccessfully => "Business units retrieved successfully.";
        public static string RequirementStatusesRetrievedSuccessfully => "Requirement statuses retrieved successfully.";

        // Mensajes de error
        public static string NoSuppliersFound => "No suppliers found.";
        public static string NoBusinessUnitsFound => "No business units found.";
        public static string NoRequirementStatusesFound => "No requirement statuses found.";
        public static string NoRequirementFound => "No requirement  found.";

        public static string ErrorRetrievingSuppliers(string errorMessage) =>
            $"An error occurred while retrieving suppliers: {errorMessage}";

        public static string ErrorRetrievingBusinessUnits(string errorMessage) =>
            $"An error occurred while retrieving business units: {errorMessage}";

        public static string ErrorRetrievingRequirementStatuses(string errorMessage) =>
            $"An error occurred while retrieving requirement statuses: {errorMessage}";

        // Mensajes de validación
        public static string GuidValidationMessage(string fieldName) => $"{fieldName} must be a valid GUID.";
        public static string ValidGuidMessage(string fieldName) => $"{fieldName} must be a valid GUID.";
        public static string NotEmptyMessage(string fieldName) => $"{fieldName} cannot be empty.";
        public static string NotNullMessage(string fieldName) => $"{fieldName} cannot be null.";
        public static string GreaterThanZeroMessage(string fieldName) => $"{fieldName} must be greater than zero.";
        public static string MinLengthMessage(string fieldName, int length) => $"{fieldName} must be at least {length} characters long.";
        public static string ValidDateMessage(string fieldName) => $"{fieldName} cannot be a future date.";

        // Mensajes adicionales para los errores de negocio
        public static string BudgetExceededMessage => "The total value (Quantity * UnitValue) cannot exceed the Budget.";
        public static string ItemTypeNotValidMessage => "ItemType is invalid or empty.";
        public static string SupplierNotFoundMessage => "The supplier was not found.";
        public static string RequirementStatusNotFoundMessage => "The requirement status was not found.";
    }
}
