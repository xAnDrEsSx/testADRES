namespace TestADRES.Application.Common
{
    public static class GlobalMessages
    {
        // Mensajes de éxito
        public static string SuppliersRetrievedSuccessfully => "Suppliers retrieved successfully.";
        public static string BusinessUnitsRetrievedSuccessfully => "Business units retrieved successfully.";
        public static string RequirementStatusesRetrievedSuccessfully => "Requirement statuses retrieved successfully.";

        // Mensajes de error
        public static string NoSuppliersFound => "No suppliers found.";
        public static string NoBusinessUnitsFound => "No business units found.";
        public static string NoRequirementStatusesFound => "No requirement statuses found.";

        public static string ErrorRetrievingSuppliers(string errorMessage) =>
            $"An error occurred while retrieving suppliers: {errorMessage}";

        public static string ErrorRetrievingBusinessUnits(string errorMessage) =>
            $"An error occurred while retrieving business units: {errorMessage}";

        public static string ErrorRetrievingRequirementStatuses(string errorMessage) =>
            $"An error occurred while retrieving requirement statuses: {errorMessage}";
    }
}
