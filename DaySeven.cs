using System;

class DaySeven
{
  public int RunTestsAndGetResultPartOne()
  {
    RunTestsPartOne();
    return 0;
  }

  public void RunTestsPartOne () 
  {
    var amp = new AmplificationCircuit();
    amp.GeneratePhasePermutations(new int[] {0,1,2,3,4});

    if(true) 
    {
      throw new System.Exception(" should  be 42");
    }
  }
}