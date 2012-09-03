using System;
using PortableFCSLib;

namespace Chapter14
{
  class SalesReport
  {
    public static void Run()
    {
      // fn to extract sales volumes
      var salesVolumeExtractor = Functional.Apply(Functional.MapDelegate<Customer, decimal>(), c => c.SalesVolume);

      // curried fn to sort decimal values
      var cSort = Functional.Curry(SortUtility.SortDelegate<decimal>());

      // fn to extract sales volumes AND sort them
      var getOrderedSalesVolumes = Functional.Uncurry(Functional.Compose(salesVolumeExtractor, cSort));

      // curried take fn with reversed arguments
      var cTake = Functional.Swap(Functional.Curry(Functional.TakeDelegate<decimal>()));

      // curried fn to extract sales volumes, order them, and take only the first n values
      var cGetRelevantSalesVolumes = Functional.Curry(Functional.Compose(getOrderedSalesVolumes, cTake));

      // fn to extract sales volumes, order them, and take only the first n values
      var getRelevantSalesVolumes = Functional.Uncurry(cGetRelevantSalesVolumes);

      // fn to calculate an average decimal value
      var avgCalculator = Functional.Compose(Functional.Apply(
        Functional.FoldLDelegate<decimal, Tuple<decimal, decimal>>(),
        (r, v) => Tuple.Create(r.Item1 + 1, r.Item2 + v), Tuple.Create(0m, 0m)),
                                             t => t.Item2 / t.Item1);

      // fn to extract sales volumes, order them, take only the first n values, and calculate
      // the average sales volume.
      var salesVolumeAverage = Functional.Compose(getRelevantSalesVolumes, avgCalculator);

      // Display the sales average for the top 5 sales people.
      Console.WriteLine("Average sales (top 5): {0}",
                        salesVolumeAverage(CustomerStore.GetCustomers(),
                                           SortUtility.SortOrder.Descending, 5));

      // Display the sales average for the bottom 5 sales people.
      Console.WriteLine("Average sales (bottom 5): {0}",
                        salesVolumeAverage(CustomerStore.GetCustomers(),
                                           SortUtility.SortOrder.Acending, 5));

      Console.Read();
    }
  }
}
