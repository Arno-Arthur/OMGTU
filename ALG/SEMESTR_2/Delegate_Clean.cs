class Car
{
    public string Model { get; private set; }
    public bool IsClean { get; private set; }


    public Car(string model)
    {
        Model = model;
        IsClean = false;
    }

    public void Wash()
    {
        Console.WriteLine($"Очищаем {Model}");
        IsClean = true;
    }
}

class Garage
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void WashAllCars(Clean clean)
    {
        foreach (Car car in cars) clean.WashCar(car);
    }
}

class Clean
{
    public void WashCar(Car car)
    {
        if (car.IsClean) Console.WriteLine($"{car.Model} уже чистая");
        else car.Wash();
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car("Toyota");
        Car car2 = new Car("Mercedes");
        Car car3 = new Car("BMW");
        
        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);
        
        Clean clean = new Clean();

        Console.WriteLine("Мойка:");
        garage.WashAllCars(clean);

        Car car4 = new Car("MClaren");
        garage.AddCar(car4);

        Console.WriteLine("\n" + "Попытка повторной мойки:");
        garage.WashAllCars(clean);

        Console.WriteLine("\n" + "И наконец:");
        garage.WashAllCars(clean);
    }
}
