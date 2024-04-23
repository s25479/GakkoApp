namespace GakkoAppVertical.Animals;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(Animal animal);
    int UpdateAnimal(int idAnimal, AnimalProperties animalProperties);
    int DeleteAnimal(int idAnimal);
}
