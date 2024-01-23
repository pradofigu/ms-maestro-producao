namespace BackofficeService.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class StockMovements
    {
        public static string GetList => $"{Base}/stockMovements";
        public static string GetAll => $"{Base}/stockMovements/all";
        public static string GetRecord(Guid id) => $"{Base}/stockMovements/{id}";
        public static string Delete(Guid id) => $"{Base}/stockMovements/{id}";
        public static string Put(Guid id) => $"{Base}/stockMovements/{id}";
        public static string Create => $"{Base}/stockMovements";
        public static string CreateBatch => $"{Base}/stockMovements/batch";
    }

    public static class Invetories
    {
        public static string GetList => $"{Base}/invetories";
        public static string GetAll => $"{Base}/invetories/all";
        public static string GetRecord(Guid id) => $"{Base}/invetories/{id}";
        public static string Delete(Guid id) => $"{Base}/invetories/{id}";
        public static string Put(Guid id) => $"{Base}/invetories/{id}";
        public static string Create => $"{Base}/invetories";
        public static string CreateBatch => $"{Base}/invetories/batch";
    }
}
