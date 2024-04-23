namespace GakkoAppVertical.Animals;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(Animal animal);
    int UpdateAnimal(int idAnimal, AnimalProperties animalProperties);
    int DeleteAnimal(int idAnimal);
}
