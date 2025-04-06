namespace TestADRES.Application.Common
{
    namespace TestADRES.Application.Common
    {
        public static class GlobalMessages
        {
            // Mensajes de éxito
            public static string SuppliersRetrievedSuccessfully => "Suppliers retrieved successfully.";

            // Mensajes de error
            public static string NoSuppliersFound => "No suppliers found.";

            public static string ErrorRetrievingSuppliers(string errorMessage) =>
                $"An error occurred while retrieving suppliers: {errorMessage}";

        }
    }

}
