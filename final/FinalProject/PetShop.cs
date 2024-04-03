public class PetShop
{
    private List<Pet> _availablePets;
    public PetShop()
    {
        //randomly generate pets from a list of names...

        _availablePets = new List<Pet>();
        //hardcoded available pets
        _availablePets.Add(new Cat("Fluffy", "Cat", 2));
        _availablePets.Add(new Dog("Buddy", "Dog", 3));
        _availablePets.Add(new Fish("Bubbles", "Fish", 1));
        // Add more pets as needed
    }

    public void DisplayAvailablePets() // displays pets in the pet shop
    {
        Console.WriteLine("Available Pets:");
        foreach (Pet pet in _availablePets)
        {
            Console.WriteLine($"Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}");
        }
    }
    public Pet AdoptPet(string name) // returns the pet the user wants
    {
        Pet petToAdopt = _availablePets.FirstOrDefault(pet => pet.Name == name);
        if (petToAdopt != null)
        {
            _availablePets.Remove(petToAdopt);
        }
        return petToAdopt;
    }
}
