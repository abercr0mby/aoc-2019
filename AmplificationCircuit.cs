using System;
using System.Collections.Generic;
using System.Linq;

class AmplificationCircuit
{

  private int[] Program { get; set; }
  private int InputSignal { get; set; }
  private Dictionary<string, int> Outputs { get; set; }

  public int currentBoosterOutput = 0;

  private List<IntCodeComputer> Computers {get; set; }

  public AmplificationCircuit(int[] program)
  {
    Program = program;
    Outputs = new Dictionary<string, int>();
    Computers = new List<IntCodeComputer>();
  }


  public int RunFeedbackCircuitPermutations(int[] phaseSettings)
  {
    //Get the permutations
    var perms = GetPermutations(phaseSettings, phaseSettings.Length);
    foreach(var p in perms)
    {
      var permName = "";
      InputSignal = 0;      

      foreach(var a in p)
        permName += a + " - ";

      var output = RunFeedbackCircuit(p.ToArray());
      Outputs.Add(permName, output);
    }

    return Outputs.Select(o => o.Value).Max();
  }

  public int RunFeedbackCircuit(int[] phaseSettings)
  {
      Computers = new List<IntCodeComputer>();

      foreach(var phaseSetting in phaseSettings)
      {
        Computers.Add(new IntCodeComputer(Program, new int[] {phaseSetting, 0}));
      }      

      do
      {
        var restart = 0;
        for(; restart < Computers.Count(); restart ++)
        {          
          var c = Computers[restart];

          c.SetInputSignal(InputSignal);          
          c.Compute();
          InputSignal = c.Output;
          //Console.WriteLine(c.Output);

          if(restart == Computers.Count() - 1)
          {
            currentBoosterOutput = InputSignal;
          }

          if(c.Halted)
          {
            return currentBoosterOutput;
          }
        }
      } while(true);

      return currentBoosterOutput;
  }

  public int RunCircuitPermutations(int[] phaseSettings)
  {
    //Get the permutations
    var perms = GetPermutations(phaseSettings, phaseSettings.Length);
    foreach(var p in perms)
    {
      var permName = "";
      InputSignal = 0;

      foreach(var phaseSetting in p)
      {
        var computer = new IntCodeComputer(Program, new int[] {phaseSetting, InputSignal});
        computer.Compute();
        InputSignal = computer.Output;
        permName += "-" + phaseSetting;
      }
      Outputs.Add(permName, InputSignal);      
    }

    return Outputs.Select(o => o.Value).Max();
  }

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