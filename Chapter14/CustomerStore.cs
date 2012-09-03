using System.Collections.Generic;

namespace Chapter14
{
  class CustomerStore
  {
    public static IEnumerable<Customer> GetCustomers()
    {
      yield return new Customer { Name = "Harry", SalesVolume = 3462.74m };
      yield return new Customer { Name = "Anna", SalesVolume = 112.9m };
      yield return new Customer { Name = "James", SalesVolume = 1269m };
      yield return new Customer { Name = "July", SalesVolume = 634.86m };
      yield return new Customer { Name = "Pete", SalesVolume = 1764.29m };
      yield return new Customer { Name = "Mike", SalesVolume = 534.23m };
      yield return new Customer { Name = "Joanne", SalesVolume = 984.30m };
      yield return new Customer { Name = "Ben", SalesVolume = 1152.00m };
      yield return new Customer { Name = "Lisa", SalesVolume = 2310.90m };
      yield return new Customer { Name = "Martin", SalesVolume = 205.77m };
    }
  }
}
