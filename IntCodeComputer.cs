using System;

class IntCodeComputer
{
  private int[] Program { get; set; }
  private int CurrentPosition { get; set; }
  private string NextOpCode { get; set; } 
  public bool Halted { get; set; }

  public int[] Inputs { get; set; }
  private int CurrentInput { get; set; }
  public int Output { get; set; }

  public IntCodeComputer(int[] program, int[] inputs)
  {
    CurrentPosition = 0;    
    this.Program = (int[]) program.Clone();

    this.Inputs = inputs;
    CurrentInput = 0;
    Halted = false;
  }

  public void SetInputSignal(int inputSignal)
  {
    Inputs[1] = inputSignal;
  }

  public bool [] GetParameterImmediacyFromOpCodeValue(string opCodeValue, string opCode)
  {
    if(opCode.Length < opCodeValue.Length)
    {
      var parameters = opCodeValue.Substring(0 ,opCodeValue.Length - opCode.Length);
      var charArray = parameters.ToCharArray();
      Array.Reverse( charArray );
      return Array.ConvertAll(charArray, c => c == '1');
    }
    return null;
  }

  private void SetNextOpCode()
  {
    var opCodeValue = Program[CurrentPosition].ToString();
    var opCodeLength = opCodeValue.Length > 1 ? 2 : 1;
    NextOpCode = opCodeValue.Substring(opCodeValue.Length - opCodeLength ,opCodeLength).PadLeft(2, '0');
  }

  public bool IsParameterImmediate(int parameterPosition, bool[] immediacies)
  {
    if(immediacies == null || immediacies.Length < parameterPosition)
    {
      return false;
    }
    return immediacies[parameterPosition - 1];   
  }

  public void Add(bool [] immediacies)
  {
    var x = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
    var y = IsParameterImmediate(2, immediacies) ? Program[CurrentPosition + 2] : Program[Program[CurrentPosition + 2]];
    Program[Program[CurrentPosition + 3]] = x + y;
    CurrentPosition += 4;
  }

  public void Multiply(bool [] immediacies)
  {
    var x = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
    var y = IsParameterImmediate(2, immediacies) ? Program[CurrentPosition + 2] : Program[Program[CurrentPosition + 2]];
    Program[Program[CurrentPosition + 3]] = x * y;
    CurrentPosition += 4;
  }

  public void ShowOutput(bool[] immediacies)
  {
    Output = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
        
    // Console.WriteLine(x);
    CurrentPosition += 2;
  }

  public void GetInput()
  {
    if (Inputs != null && Inputs.Length >= CurrentInput)
    {
      Program[Program[CurrentPosition + 1]] = Inputs[CurrentInput];
      if(Inputs.Length - 1 > CurrentInput)
      {
        CurrentInput ++;
      }
      CurrentPosition += 2; 
      return;
    }

    string val;
    Console.Write("Enter integer: ");
    val = Console.ReadLine();  
    try
    {
      Program[Program[CurrentPosition + 1]] = Convert.ToInt32(val);  
    }
    catch(Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
    CurrentPosition += 2;
  }  

  public void JumpIfTrue(bool [] immediacies)
  {
    var x = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
    var y = IsParameterImmediate(2, immediacies) ? Program[CurrentPosition + 2] : Program[Program[CurrentPosition + 2]];
    if (x != 0)
    {
      CurrentPosition = y;
      return;
    }    
    CurrentPosition += 3;
  }

  public void JumpIfFalse(bool [] immediacies)
  {
    var x = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
    var y = IsParameterImmediate(2, immediacies) ? Program[CurrentPosition + 2] : Program[Program[CurrentPosition + 2]];
    if (x == 0)
    {
      CurrentPosition = y;
      return;
    }   
    CurrentPosition += 3; 
  }

  public void LessThan(bool [] immediacies)
  {
    var x = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
    var y = IsParameterImmediate(2, immediacies) ? Program[CurrentPosition + 2] : Program[Program[CurrentPosition + 2]];
    Program[Program[CurrentPosition + 3]] = x < y ? 1 : 0;
    CurrentPosition += 4;
  }

  public void Equals(bool [] immediacies)
  {
    var x = IsParameterImmediate(1, immediacies) ? Program[CurrentPosition + 1] : Program[Program[CurrentPosition + 1]];
    var y = IsParameterImmediate(2, immediacies) ? Program[CurrentPosition + 2] : Program[Program[CurrentPosition + 2]];
    Program[Program[CurrentPosition + 3]] = x == y ? 1 : 0;
    CurrentPosition += 4;
  }

  public int[] Compute() 
  {
    // Console.WriteLine(Inputs[0] + " - " + Inputs[1]);

    while(NextOpCode != "99")
    {
      //Console.Write(" - " + CurrentPosition);      
      var opCodeValue = Program[CurrentPosition].ToString();            

      //Console.Write(" - " + opCodeValue);

      SetNextOpCode();

      //Console.Write(" - " + NextOpCode);
      //Console.WriteLine();

      bool [] parametersImmediacy = GetParameterImmediacyFromOpCodeValue(opCodeValue, NextOpCode);      

      switch (NextOpCode)
      {
        case "01":
          Add(parametersImmediacy);
          break;

        case "02":
          Multiply(parametersImmediacy);
          break;

        case "03":
          GetInput();
          break;

        case "04":
          ShowOutput(parametersImmediacy);
          break;

        case "05":
          JumpIfTrue(parametersImmediacy);
          break;

        case "06":
          JumpIfFalse(parametersImmediacy);
          break;

        case "07":
          LessThan(parametersImmediacy);
          break;

        case "08":
          Equals(parametersImmediacy);
          break;                                    

        case "99":
          break;  

        default:
          throw new System.Exception("unknown opcode - " + NextOpCode);        
      }      
      
      if(NextOpCode == "04")
      {  
        break;
      }

      if(NextOpCode == "99")
      {
        Halted = true;
        break;
      } 
    }
      
    return Program;
  }
}