public class PetShop
{
    private List<Pet> availablePets;

    public PetShop()
    {
        availablePets = new List<Pet>();
        // Populate available pets
        availablePets.Add(new Pet("Fluffy", "Cat", 2));
        availablePets.Add(new Pet("Buddy", "Dog", 3));
        // Add more pets as needed
    }

    public void DisplayAvailablePets()
    {
        Console.WriteLine("Available Pets:");
        foreach (Pet pet in availablePets)
        {
            Console.WriteLine($"Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}");
        }
    }

    public Pet AdoptPet(string name)
    {
        Pet petToAdopt = availablePets.FirstOrDefault(pet => pet.Name == name);
        if (petToAdopt != null)
        {
            availablePets.Remove(petToAdopt);
        }
        return petToAdopt;
    }
}
