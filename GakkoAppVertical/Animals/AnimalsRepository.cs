using System.Data.SqlClient;

namespace GakkoAppVertical.Animals;

public class AnimalsRepository : IAnimalsRepository
{
    private IConfiguration configuration;
    
    public AnimalsRepository(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY @orderBy";
        cmd.Parameters.AddWithValue("@orderBy", orderBy);
        
        var reader = cmd.ExecuteReader();
        if (!reader.Read())
            return null;
        
        var animals = new List<Animal>();
        while (reader.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString(),
                Area = reader["Area"].ToString()
            };
            animals.Add(animal);
        }

        return animals;
    }

    public int AddAnimal(Animal animal)
    {
        using var connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO Animal(IdAnimal, Name, Description, Category, Area) VALUES (@IdAnimal, @Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        return cmd.ExecuteNonQuery();
    }

    public int UpdateAnimal(int idAnimal, AnimalProperties animalProperties)
    {
        using var connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        cmd.Parameters.AddWithValue("@Name", animalProperties.Name);
        cmd.Parameters.AddWithValue("@Description", animalProperties.Description);
        cmd.Parameters.AddWithValue("@Category", animalProperties.Category);
        cmd.Parameters.AddWithValue("@Area", animalProperties.Area);
        return cmd.ExecuteNonQuery();
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        return cmd.ExecuteNonQuery();
    }
}
