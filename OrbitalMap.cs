using System;
using System.Collections.Generic;
using System.IO;

class OrbitalMap 
{
  public Planet com { get; set; }

  public Dictionary<string, Planet> AllPlanets;

  public int totalOrbits = 0;

  public string MapFile { get; set; }

  public OrbitalMap(string mapFile)
  {
    AllPlanets = new Dictionary<string, Planet>();
    MapFile = mapFile;

    com = new Planet("COM");
    AllPlanets.Add(com.name, com);
    PopulateMapFromFile();
    totalOrbits = com.CalculateDistances( totalOrbits );
  }

  public void PopulateMapFromFile()
  {
    String line;
    try 
    {
      //Pass the file path and file name to the StreamReader constructor
      StreamReader sr = new StreamReader(MapFile);   

      //Continue to read until you reach end of file
      while (!sr.EndOfStream) 
      {
        line = sr.ReadLine();
        var components = line.Split(')');
        var orbittedName = components[0];
        Planet orbittedPlanet;

        var orbitingName = components[1];
        Planet orbitingPlanet;

        AllPlanets.TryGetValue(orbittedName, out orbittedPlanet);
        if (orbittedPlanet == null)
        {
          orbittedPlanet = new Planet(orbittedName);
          AllPlanets.Add(orbittedPlanet.name, orbittedPlanet);
        }

        AllPlanets.TryGetValue(orbitingName, out orbitingPlanet);
        if (orbitingPlanet == null)
        {
          orbitingPlanet = new Planet(orbitingName);
          AllPlanets.Add(orbitingPlanet.name, orbitingPlanet);
        }

        orbittedPlanet.AddOrbitedBy(orbitingPlanet);
      }

      //close the file
      sr.Close();
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
    }
      finally 
    {
      Console.WriteLine("Executing finally block.");
    }
    }
}


class Planet
{
  public string name { get; set; }

  public List<Planet> OrbitedBy { get; set; }

  public Planet InOrbitAround { get; set; }

  public int directlyOrbiting { get; set; } = 0;

  public int totalOrbiting { get; set; } = 0;

  public Planet(string name)
  {
    OrbitedBy = new List<Planet>();
    this.name = name;
  }

  public int CalculateDistances(int total)
  {
    total = totalOrbiting = InOrbitAround == null ? 0 : InOrbitAround.totalOrbiting + 1;
    directlyOrbiting = InOrbitAround == null ? 0 : 1;

    foreach(var planet in OrbitedBy)
    {
      total += planet.CalculateDistances(total);
    }

    return total;
  }

  public void SetInOrbit(Planet inOrbitAround)
  {
    InOrbitAround = inOrbitAround;
  }

  public void AddOrbitedBy(Planet orbitedBy)
  {
    OrbitedBy.Add(orbitedBy);
    orbitedBy.SetInOrbit(this);
  }
}