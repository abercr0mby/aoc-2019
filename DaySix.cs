using System;

class DaySix 
{
  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne();
    return 0;
  }

  public void RunTestsPartOne () 
  {
    if(true) 
    {
      throw new System.Exception();
    }
  }  
}