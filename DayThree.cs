using System;
using System.Collections.Generic;

class FMSystem {
  private Wire wireOne;
  private Wire wireTwo;  

  public FMSystem(string [] directionsOne, string [] directionsTwo) {
    this.wireOne = new Wire ( directionsOne );
    this.wireTwo = new Wire ( directionsTwo );
  }

  public int CalculateCrossOverDistance(){
    return 0;
  }



}

class Wire {
  private string [] directions;

  private int currentStep;

  private Point currentPoint;

  public List<Point> path;

  public Wire( string [] directions ) {
    this.directions = directions;
    currentStep = 0;
  }

  public void Step() {  
    currentStep ++;
    var direction = directions[currentStep][0];
    var distance = (int) directions[currentStep][1];

    var nextPoint = new Point( currentPoint.x, currentPoint.y);

    for (int i = 0; i < distance; i++)
    {
      switch (direction)
      {
        case 'U':
          nextPoint.y = nextPoint.y + 1;
          break;
        case 'D':
          nextPoint.y = nextPoint.y -1;
          break;      
        case 'L':
          nextPoint.x = nextPoint.x -1;
          break;
        case 'R':
          nextPoint.x = nextPoint.x + 1;
          break;
        default:
          throw new System.Exception("Unknown direction");
      }
      path.Add( new Point( nextPoint.x, nextPoint.y ) );
    }
    currentPoint = nextPoint;
  }

}

class Point {
  public int x { get; set; }
  public int y { get; set; }

  public int distance 
  { 
    get
    {
      return Math.Abs(x) + Math.Abs(y);      
    } 
  }

  public Point(int x, int y) {
    this.x = x;
    this.y = y;
  }
}

class DayThree {

  public int RunTestsAndGetResultPartOne() {
    RunTestsPartOne();
    return 0;
    // return CalculateCrossOverDistance();
  }

  public void RunTestsPartOne () {
    var fMSystemOne = new FMSystem( new int[] {1,2,3,4}, new int[] {1,2,3,4} );
    if(fMSystemOne.CalculateCrossOverDistance() != 2) {
      throw new System.Exception("Failed test one");
    }
  }  
}