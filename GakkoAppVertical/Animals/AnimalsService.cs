namespace GakkoAppVertical.Animals;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository animalsRepository;
    
    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        this.animalsRepository = animalsRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return animalsRepository.GetAnimals(orderBy);
    }

    public int AddAnimal(Animal animal)
    {
        return animalsRepository.AddAnimal(animal);
    }

    public int UpdateAnimal(int idAnimal, AnimalProperties animalProperties)
    {
        return animalsRepository.UpdateAnimal(idAnimal, animalProperties);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return animalsRepository.DeleteAnimal(idAnimal);
    }
}
