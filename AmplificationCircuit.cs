using System;
using System.Collections.Generic;
using System.Linq;

class AmplificationCircuit
{

  public int RunCircuit()
  {
    // Run 5 amplifiers
    for(int i = 0; i < 5; i++)
    {

    }
    return 0;
  }

  /*
  public IEnumerable<IEnumerable<int>> GetPermutations(List<int> input, int length)
  {
      if (length == 1) return input.Select(t => new List<List<int>>() { new List<int>() {t} });
      return GetPermutations(input, length - 1)
          .SelectMany(t => input.Where(o => !t.Contains(o)),
              (t1, t2) => t1.Concat(new List<int> { t2 }));
  }
  */

  public IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
  {
    if (length == 1) return list.Select(t => new T[] { t });

    return GetPermutations(list, length - 1)
        .SelectMany(t => list.Where(o => !t.Contains(o)), (t1, t2) => t1.Concat(new T[] { t2 }));
  }

  public IEnumerable<IEnumerable<int>> GeneratePhasePermutations(int[] phaseValues)
  {
    var perms = GetPermutations(phaseValues, phaseValues.Length);
    return perms;
  }

}