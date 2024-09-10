namespace WorkoutApi.Repositories.Sql
{
    public static class LoadSql
    {
        private static string SqlFolderPath = Path.Combine(AppContext.BaseDirectory, "Repositories", "sql");

        public static string LoadSqlQuery(string fileName)
        {
            var filePath = Path.Combine(SqlFolderPath, fileName);
            if (!File.Exists(filePath)) throw new Exception("Sql file not found");

            return File.ReadAllText(filePath);
        }
    }
}
