namespace App.Infrastructure.Dapper
{
    public static class HomeServiceQueries
    {
        public static string GetHouseWorks = @"
    SELECT h.Id, h.Title AS Title, h.Description, h.BasePrice, 
           c.Title AS SubCategory, h.ImagePath
    FROM HouseWorks h 
    INNER JOIN Categories c ON h.CategoryId = c.Id";


        public static string GetCities = @"SELECT * FROM Cities";

        public static string GetCategories = @"
        SELECT c.Id, c.Title, c.ImagePath 
        FROM Categories c 
        WHERE c.ParentId IS NOT NULL";

        public static string GetParentCategories = @"
        SELECT c.Id, c.Title, c.ImagePath 
        FROM Categories c 
        WHERE c.ParentId IS NULL";
    }

}


