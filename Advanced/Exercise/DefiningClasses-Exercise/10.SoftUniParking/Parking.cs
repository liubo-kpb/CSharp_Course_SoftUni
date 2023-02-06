using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    internal class Parking
    {
        private int capacity;
        private List<Car> cars;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count { get => cars.Count; }
        public int Capacity { get => capacity; }
        public List<Car> Cars { get => cars; }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            if (cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                cars.Remove(cars.First(c => c.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            if (cars.Any(c => c.RegistrationNumber == registrationNumber))
                return cars.First(c => c.RegistrationNumber == registrationNumber);
            return null;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                Car car = GetCar(registrationNumber);
                if (car != null)
                {
                    cars.Remove(car);
                }
            }
        }
    }
}
