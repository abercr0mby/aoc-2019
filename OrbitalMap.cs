using System;

class OrbitalMap 
{

}

class Planet
{
  public string name { get; set; }

  public List<Planet> OrbitedBy { get; set; }

  public Planet InOrbitAround { get; set; }

  public Planet(string name)
  {
    this.name = name;
  }

  public SetInOrbit(Planet inOrbitAround)
  {
    InOrbitAround = inOrbitAround;
  }

  public AddOrbitedBy(Planet orbitedBy)
  {
    OrbitedBy.Add(orbitedBy);
    orbitedBy.SetInOrbit(this;)
  }
}