using System;
using System.Linq;

class DayTen
{
  public void RunTestsAndShowResultPartOne()
  {
    RunTestsPartOne();
  }

  public void RunTestsPartOne()
  {    
    if(true) 
    {
      throw new System.Exception("Day Ten Test One: ");
    }  
    else
    {
      Console.WriteLine("Day Ten Test One Passed");
    }
  }


}