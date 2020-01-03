using System;

class DayTwo {

  public int[] mainInput = new int[] {1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,1,9,27,31,1,31,10,35,2,13,35,39,1,39,10,43,1,43,9,47,1,47,13,51,1,51,13,55,2,55,6,59,1,59,5,63,2,10,63,67,1,67,9,71,1,71,13,75,1,6,75,79,1,10,79,83,2,9,83,87,1,87,5,91,2,91,9,95,1,6,95,99,1,99,5,103,2,103,10,107,1,107,6,111,2,9,111,115,2,9,115,119,2,13,119,123,1,123,9,127,1,5,127,131,1,131,2,135,1,135,6,0,99,2,0,14,0};

  public DayTwo() {

  }

  public int[] Compute(int[] opCodes, int currentPosition) {

    if(opCodes[currentPosition] == 99)
    {
      Console.WriteLine("terminate");
      return opCodes;
    }

    var operandOnePosition = opCodes[currentPosition + 1];
    var operandTwoPosition = opCodes[currentPosition + 2];
    var target = opCodes[currentPosition + 3];
    var nextOpCode = currentPosition + 4;

    switch (opCodes[currentPosition])
    {
        // addition
        case 1:
          opCodes[target] = opCodes[operandOnePosition] + opCodes[operandTwoPosition];
          break;
        // multiply
        case 2:
            opCodes[target] = opCodes[operandOnePosition] * opCodes[operandTwoPosition];
            break;
        default:
            throw new System.Exception("unknown opcode");
            break;
    }

    opCodes = Compute(opCodes, nextOpCode);
    return opCodes;
  }

  public int RunTestsAndGetResultPartOne () {
    RunTestsPartOne();
    return Compute(mainInput,0)[0];    
  }

  public void RunTestsPartOne () {
    var testOneInput = new int[] {1,9,10,3,2,3,11,0,99,30,40,50};
    var testOneOutput = Compute(testOneInput,0);
    if(testOneOutput[0] != 3500) {
      Console.WriteLine(testOneOutput[0]);
      throw new System.Exception();
    }

    var testTwoInput = new int[] {1,0,0,0,99};
    var testTwoOutput = Compute(testTwoInput,0);
    if(testTwoOutput[0] != 2) {
      Console.WriteLine(testTwoOutput[0]);
      throw new System.Exception();
    } 

    var testThreeInput = new int[] {2,3,0,3,99};
    var testThreeOutput = Compute(testThreeInput,0);
    if(testThreeOutput[3] != 6) {
      Console.WriteLine(testThreeOutput[3]);
      throw new System.Exception();
    }    

    var testFourInput = new int[] {2,4,4,5,99,0};
    var testFourOutput = Compute(testFourInput,0);
    if(testFourOutput[5] != 9801) {
      Console.WriteLine(testFourOutput[5]);
      throw new System.Exception();
    }

    var testFiveInput = new int[] {1,1,1,4,99,5,6,0,99};
    var testFiveOutput = Compute(testFiveInput,0);
    if(testFiveOutput[0] != 30 && testFiveOutput[4] != 2) {
      Console.WriteLine(testFiveOutput[0]);
      throw new System.Exception();
    }
  }    

  
}