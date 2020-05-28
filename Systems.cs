using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems
{
    public string name;
    public bool selected = true;
    
    static public List<Systems> systems = new List<Systems>();
    static public List<Planet> planets = new List<Planet>();
    public Systems(string name)
    {
        this.name = name;
    }
    static Systems()
    {
        systems.Add(new Systems("System1"));
    }
}
