using System;

class DaySix 
{
  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne();
    var map = new OrbitalMap("OrbitalData.txt");
    return map.totalOrbits;
  }

  public void RunTestsPartOne () 
  {
    var map = new OrbitalMap("OrbitalDataTestOne.txt");
    if(map.totalOrbits != 42) 
    {
      throw new System.Exception(map.totalOrbits + " should  be 42");
    }
  }  
}