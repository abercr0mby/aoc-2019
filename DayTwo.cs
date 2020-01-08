using System;

class DayTwo {

  public int[] mainInput = new int[] {1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,1,9,27,31,1,31,10,35,2,13,35,39,1,39,10,43,1,43,9,47,1,47,13,51,1,51,13,55,2,55,6,59,1,59,5,63,2,10,63,67,1,67,9,71,1,71,13,75,1,6,75,79,1,10,79,83,2,9,83,87,1,87,5,91,2,91,9,95,1,6,95,99,1,99,5,103,2,103,10,107,1,107,6,111,2,9,111,115,2,9,115,119,2,13,119,123,1,123,9,127,1,5,127,131,1,131,2,135,1,135,6,0,99,2,0,14,0};

  public int RunTestsAndGetResultPartOne () {
    RunTestsPartOne();
    var computer = new IntCodeComputer((int[]) mainInput.Clone(), null);
    return computer.Compute()[0];
  }

  public int GetResultPartTwo () {
    for ( var i = 0; i < 100; i++ ) {
      for ( var j = 0; j < 100; j++ ) {
        int[] workingCopy = (int[]) mainInput.Clone();
        workingCopy[1] = i;
        workingCopy[2] = j;
        var computer = new IntCodeComputer(workingCopy, null);
        workingCopy = computer.Compute();
        if(workingCopy[0] == 19690720) {
          return ( workingCopy[1] * 100 ) + workingCopy[2];
        }
      }
    }
    return 0;
  }

  public void RunTestsPartOne () {
    var computer = new IntCodeComputer(new int[] {1,9,10,3,2,3,11,0,99,30,40,50}, null);
    var testOneOutput = computer.Compute();
    if(testOneOutput[0] != 3500) {
      Console.WriteLine(testOneOutput[0]);
      throw new System.Exception();
    }

    computer = new IntCodeComputer(new int[] {1,0,0,0,99}, null);
    var testTwoOutput = computer.Compute();
    if(testTwoOutput[0] != 2) {
      Console.WriteLine(testTwoOutput[0]);
      throw new System.Exception();
    } 

    computer = new IntCodeComputer(new int[] {2,3,0,3,99}, null);
    var testThreeOutput = computer.Compute();
    if(testThreeOutput[3] != 6) {
      Console.WriteLine(testThreeOutput[3]);
      throw new System.Exception();
    }    

    computer = new IntCodeComputer(new int[] {2,4,4,5,99,0}, null);
    var testFourOutput = computer.Compute();
    if(testFourOutput[5] != 9801) {
      Console.WriteLine(testFourOutput[5]);
      throw new System.Exception();
    }

    computer = new IntCodeComputer( new int[] {1,1,1,4,99,5,6,0,99},null);
    var testFiveOutput = computer.Compute();
    if(testFiveOutput[0] != 30 && testFiveOutput[4] != 2) {
      Console.WriteLine(testFiveOutput[0]);
      throw new System.Exception();
    }
  }    

  
}