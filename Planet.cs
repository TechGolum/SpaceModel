using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{
    private string name;
    private float mass;
    private float initial_speed;
    private float speed;
    private Vector3 initial_direction;

    public bool selected = false;
    public bool moused = false;
    public bool followed = false;

    static public float G = 6.67f;
    static private int count = 1;

    public Planet(float mass, float speed, GameObject game_obj, string name)
    {
        Mass = mass;
        Initial_Speed = speed;
        Speed = speed;
        Name = name;
        Game_obj = game_obj;
        Game_obj.GetComponent<Transform>().localScale = setRadius(mass);
    }

    private Vector3 setRadius(float mass)
    {
        return new Vector3(Mathf.Sqrt(mass), Mathf.Sqrt(mass), Mathf.Sqrt(mass));
    }

    public float Mass
    {
        get { return mass; }
        set { if (value > 0 && value.GetType() == 1f.GetType()) mass = value; else mass = 1; }
    }
    public float Initial_Speed 
    {
        get { return initial_speed; }
        set { if (value >= 0 && value.GetType() == 1f.GetType()) initial_speed = value; else initial_speed = 0; }
    }
    public float Speed
    {
        get { return speed; }
        set { if (value >= 0 && value.GetType() == 1f.GetType()) speed = value; else speed = 0; }
    }
    public string Name
    {
        get { return name; }
        set { if (value != null && value != "" && value != "0") name = value; else name = "Planet" + count++; }
    }
    public Vector3 Initial_Direction
    {
        get { return initial_direction; }
        set { if (value.GetType() == new Vector3().GetType()) initial_direction = value; }
    }
    public GameObject Game_obj { get; set; }
}
