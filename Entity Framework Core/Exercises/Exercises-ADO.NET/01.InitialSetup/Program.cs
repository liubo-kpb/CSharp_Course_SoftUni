using Microsoft.Data.SqlClient;
using System.Text;

namespace _01.InitialSetup
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();
            SqlCommand command = new SqlCommand("CREATE DATABASE MinionsDB", sqlConnection);
            command.ExecuteNonQuery();

            await using SqlConnection newSqlConnection = new SqlConnection(Config.ConnectionString2);
            await newSqlConnection.OpenAsync();
            createTables(newSqlConnection);
            insertToTables(newSqlConnection);

            Console.WriteLine(await getVillainsAsync(newSqlConnection));

            int villainId = int.Parse(Console.ReadLine());
            Console.WriteLine(await getVillainAndTheirMinionsAsync(newSqlConnection, villainId));

            await AddMinionAsync(newSqlConnection);
            Console.WriteLine(await changeTownCasingAsync(newSqlConnection));
            Console.WriteLine(await RemoveVillainAsync(newSqlConnection));
            await PrintAllMinionNamesAsync(newSqlConnection);
            await IncreaseMinionAgeAsync(newSqlConnection);
            createStoredProcecure(newSqlConnection);
            UseStoredProcedure(newSqlConnection);
        }

        private static void UseStoredProcedure(SqlConnection sqlConnection)
        {
            int minionId = int.Parse(Console.ReadLine());
            string useProcedureQuery = @"EXEC usp_GetOlder @id";
            SqlCommand execCommand = new SqlCommand(useProcedureQuery, sqlConnection);
            execCommand.Parameters.AddWithValue("@id", minionId);
            execCommand.ExecuteNonQuery();

            string getMinionsQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(getMinionsQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", minionId);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            Console.WriteLine($"{reader[0]} - {reader[1]} years old");
        }

        private static void createStoredProcecure(SqlConnection sqlConnection)
        {
            string createProcedureQuery = @"CREATE PROC usp_GetOlder @id INT
                                            AS
                                            UPDATE Minions
                                               SET Age += 1
                                             WHERE Id = @id";
            SqlCommand sqlCommand = new SqlCommand(createProcedureQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        private static async Task IncreaseMinionAgeAsync(SqlConnection sqlConnection)
        {
            int[] ids = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string updateMinionsAge = @"UPDATE Minions
                                           SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                         WHERE Id = @Id";
            for (int i = 0; i < ids.Length; i++)
            {
                SqlCommand updateAgesCommand = new SqlCommand(updateMinionsAge, sqlConnection);
                updateAgesCommand.Parameters.AddWithValue("@Id", ids[i]);
                await updateAgesCommand.ExecuteNonQueryAsync();
            }
            string getMinionsQuery = @"SELECT Name, Age FROM Minions";
            SqlCommand sqlCommand = new SqlCommand(getMinionsQuery, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            Dictionary<string, int> minions = new Dictionary<string, int>();
            while (reader.Read())
            {
                minions[(string)reader[0]] = (int)reader[1];
            }
            foreach (var minion in minions)
            {
                Console.WriteLine($"{minion.Key} {minion.Value}");
            }
        }

        private static async Task PrintAllMinionNamesAsync(SqlConnection sqlConnection)
        {
            string getNamesQuery = @"SELECT Name FROM Minions";
            SqlCommand sqlCommand = new SqlCommand(getNamesQuery, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            List<string> minions = new List<string>();
            while (reader.Read())
            {
                minions.Add(reader.GetString(0));
            }
            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - 1 - i]);
                if (i == minions.Count / 2 && minions.Count % 2 == 1)
                {
                    Console.WriteLine(minions[++i]);
                }
            }
        }

        private static async Task<string> RemoveVillainAsync(SqlConnection sqlConnection)
        {
            int villainId = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            SqlTransaction transaction = sqlConnection.BeginTransaction();
            try
            {
                string checkVillainQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
                SqlCommand sqlCommand = new SqlCommand(checkVillainQuery, sqlConnection, transaction);
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                string? villainName = (string?)await sqlCommand.ExecuteScalarAsync();
                if (villainName != null)
                {
                    string deleteMinionVillainRelationQuery = @"DELETE FROM MinionsVillains 
                                                                 WHERE VillainId = @villainId";
                    sqlCommand = new SqlCommand(deleteMinionVillainRelationQuery, sqlConnection, transaction);
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                    int minionsReleased = await sqlCommand.ExecuteNonQueryAsync();
                    string deleteVillainQuery = @"DELETE FROM Villains
                                                   WHERE Id = @villainId";
                    sqlCommand = new SqlCommand(deleteVillainQuery, sqlConnection, transaction);
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                    await sqlCommand.ExecuteNonQueryAsync();
                    sb.AppendLine($"{villainName} was deleted.");
                    sb.AppendLine($"{minionsReleased} minions were released.");
                }
                else
                {
                    sb.AppendLine("No such villain was found.");
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                sb.Append(ex.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        private static async Task<string> changeTownCasingAsync(SqlConnection sqlConnection)
        {
            string countryName = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            string updateTownNamesQuery = @"UPDATE Towns
                                               SET Name = UPPER(Name)
                                             WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            SqlCommand command = new SqlCommand(updateTownNamesQuery, sqlConnection);
            command.Parameters.AddWithValue("@countryName", countryName);
            int affectedRows = await command.ExecuteNonQueryAsync();
            if (affectedRows > 0)
            {
                string getAffectedCities = @"SELECT t.Name 
                                               FROM Towns as t
                                               JOIN Countries AS c ON c.Id = t.CountryCode
                                              WHERE c.Name = @countryName";
                command = new SqlCommand(getAffectedCities, sqlConnection);
                command.Parameters.AddWithValue("@countryName", countryName);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<string> townName = new List<string>();
                while (reader.Read())
                {
                    townName.Add((string)reader["Name"]);
                }
                reader.Close();
                sb.AppendLine($"{affectedRows} town names were affected.");
                sb.AppendLine($"[{string.Join(", ", townName)}]");
            }
            else
            {
                sb.AppendLine("No town names were affected.");
            }

            return sb.ToString().TrimEnd();
        }

        private static async Task AddMinionAsync(SqlConnection sqlConnection)
        {
            string minionInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];
            string[] minion = minionInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string minionName = minion[0];
            int minionAge = int.Parse(minion[1]);
            string minionTown = minion[2];
            string villainName = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                string checkTownQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
                SqlCommand sqlCommand = new SqlCommand(checkTownQuery, sqlConnection, sqlTransaction); ;
                sqlCommand.Parameters.AddWithValue("@townName", minionTown);
                int? townId = (int?)await sqlCommand.ExecuteScalarAsync();
                if (!townId.HasValue)
                {
                    string insertTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";
                    SqlCommand insertTownCommand = new SqlCommand(insertTownQuery, sqlConnection, sqlTransaction);
                    insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
                    await insertTownCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                    townId = (int?)await sqlCommand.ExecuteScalarAsync();
                }

                string checkVillainQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
                sqlCommand = new SqlCommand(checkVillainQuery, sqlConnection, sqlTransaction);
                sqlCommand.Parameters.AddWithValue("@Name", villainName);
                int? villainId = (int?)await sqlCommand.ExecuteScalarAsync();
                if (!villainId.HasValue)
                {
                    string insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                    SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuery, sqlConnection, sqlTransaction);
                    insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                    await insertVillainCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                    villainId = (int?)await sqlCommand.ExecuteScalarAsync();
                }

                string checkMinionQuery = @"SELECT Id FROM Minions WHERE Name = @Name";
                sqlCommand = new SqlCommand(checkMinionQuery, sqlConnection, sqlTransaction);
                sqlCommand.Parameters.AddWithValue("@Name", minionName);
                int? minionId = (int?)await sqlCommand.ExecuteScalarAsync();
                if (!minionId.HasValue)
                {
                    string insertMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                    SqlCommand insertMinionCommand = new SqlCommand(insertMinionQuery, sqlConnection, sqlTransaction);
                    insertMinionCommand.Parameters.AddWithValue("@name", minionName);
                    insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                    insertMinionCommand.Parameters.AddWithValue("@townId", townId);
                    await insertMinionCommand.ExecuteNonQueryAsync();
                    minionId = (int?)await sqlCommand.ExecuteScalarAsync();
                }

                string insertMinnionVillainRelation = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                sqlCommand = new SqlCommand(insertMinnionVillainRelation, sqlConnection, sqlTransaction);
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                await sqlCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

                await sqlTransaction.CommitAsync();
                Console.WriteLine("Changes complete!");
            }
            catch (Exception ex)
            {
                await sqlTransaction.RollbackAsync();
                Console.WriteLine("Transaction failed.");
            }
        }

        private static async Task<string> getVillainAndTheirMinionsAsync(SqlConnection sqlConnection, int villainId)
        {
            string getVillainQuery = @"SELECT Name FROM Villains WHERE Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(getVillainQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            if (!reader.Read())
            {
                return $"No villain with ID {villainId} exists in the database.";
            }
            string villainName = (string)reader["Name"];
            reader.Close();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villainName}");

            string getMinionsQuery = @"   SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                 m.Name, 
                                                 m.Age
                                            FROM MinionsVillains AS mv
                                            JOIN Minions As m ON mv.MinionId = m.Id
                                           WHERE mv.VillainId = @Id
                                        ORDER BY m.Name";
            sqlCommand = new SqlCommand(getMinionsQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", villainId);
            reader = await sqlCommand.ExecuteReaderAsync();
            int minions = 0;
            while (reader.Read())
            {
                sb.AppendLine($"{++minions}. {(string)reader["Name"]} {(int)reader["Age"]}");
            }
            if (minions == 0)
            {
                sb.AppendLine("(no minions)");
            }

            reader.Close();
            return sb.ToString().TrimEnd();
        }

        private static async Task<string> getVillainsAsync(SqlConnection sqlConnection)
        {
            string query = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                 FROM Villains AS v 
                                 JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                             GROUP BY v.Id, v.Name 
                               HAVING COUNT(mv.VillainId) > 3 
                             ORDER BY COUNT(mv.VillainId)";

            StringBuilder sb = new StringBuilder();

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];
                sb.AppendLine($"{villainName} - {minionsCount}");
            }
            reader.Close();
            return sb.ToString().TrimEnd();
        }

        private static void createTables(SqlConnection sqlConnection)
        {
            string query = @"CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))

                             CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))
                             
                             CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))
                             
                             CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))
                             
                             CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))
                             
                             CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
        }
        private static void insertToTables(SqlConnection sqlConnection)
        {
            string query = @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 5)

INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)

INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')

INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)

INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,7),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
        }
    }
}