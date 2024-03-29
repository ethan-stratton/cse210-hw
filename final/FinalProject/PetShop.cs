public class PetShop
{
    private List<Pet> _availablePets;

    public PetShop()
    {
        _availablePets = new List<Pet>();
        // Populate available pets
        _availablePets.Add(new Pet("Fluffy", "Cat", 2));
        _availablePets.Add(new Pet("Buddy", "Dog", 3));
        // Add more pets as needed...
    }

    public void DisplayAvailablePets()
    {
        Console.WriteLine("Available Pets:");
        foreach (Pet pet in _availablePets)
        {
            Console.WriteLine($"Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}");
        }
    }
    public Pet AdoptPet(string name)
    {
        Pet petToAdopt = _availablePets.FirstOrDefault(pet => pet.Name == name);
        if (petToAdopt != null)
        {
            _availablePets.Remove(petToAdopt);
        }
        return petToAdopt;
    }
}
