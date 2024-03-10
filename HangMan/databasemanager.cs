namespace hangmanDatabase;
using System.Data.SQLite; 
class HangmanGame
{
    private SQLiteConnection connection;

    public HangmanGame(string databasePath)
    {
        // Initialize the SQLite connection
        string connectionString = $"Data Source={databasePath};Version=3;";
        connection = new SQLiteConnection(connectionString);
    }

    public void Connect()
    {
        try
        {
            connection.Open();
           /*  Console.WriteLine("Database connection established."); */
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the database: {ex.Message}");
        }
    }

    public void Disconnect()
    {
        connection.Close();
        Console.WriteLine("Database connection closed.");
    }

    public string WordSelector()
    {
        string? randomWord = null;

        try
        {
            // Execute SQL query to fetch a random word from the database
            string query = "SELECT words FROM hangmanWords ORDER BY RANDOM() LIMIT 1;";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        randomWord = reader.GetString(0);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error selecting random word from database: {ex.Message}");
        }

        return randomWord;
    }
}