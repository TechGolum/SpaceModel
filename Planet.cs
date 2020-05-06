using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{
    private string name = "Jupiter";
    private float mass = 1;
    private float initial_speed = 0;
    private float speed = 0;
    private float spin = 0;
    private Vector3 initial_direction;

    public bool selected = false;
    public bool moused = false;
    public bool followed = false;

    static public float G = 6.67f;
    static public float slow = 1;

    public Planet(float mass, float speed, float spin, GameObject game_obj)
    {
        Mass = mass;
        Spin = spin;
        Initial_Speed = speed;
        Speed = speed;
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
        set { if (value > 0 && value.GetType() == 1f.GetType()) mass = value; }
    }
    public float Initial_Speed 
    {
        get { return initial_speed; }
        set { if (value >= 0 && value.GetType() == 1f.GetType()) initial_speed = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { if (value >= 0 && value.GetType() == 1f.GetType()) speed = value; }
    }
    public float Spin
    {
        get { return spin; }
        set { if (value >= 0 && value.GetType() == 1f.GetType()) spin = value; }
    }
    public string Name
    {
        get { return name; }
        set { if (value != null) name = value; }
    }
    public Vector3 Initial_Direction
    {
        get { return initial_direction; }
        set { if (value.GetType() == new Vector3().GetType()) initial_direction = value; }
    }
    public GameObject Game_obj { get; set; }
}
