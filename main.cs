  
using System;

class MainClass {
  public static void Main (string[] args) {
  /*  try{
      var dayOne = new DayOne();
      Console.WriteLine(dayOne.RunTestsAndGetResultPartOne());
      Console.WriteLine(dayOne.RunTestsAndGetResultPartTwo());
    }
    catch(Exception ex){
      Console.WriteLine(ex.Message);
    } 
  */

    try{
      var dayTwo = new DayTwo();
      Console.WriteLine(dayTwo.RunTestsAndGetResultPartOne());      
    }
    catch(Exception ex){
      Console.WriteLine(ex.Message);
    }

  }
}