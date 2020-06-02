using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Sprite { Alien, Desert, Earth, Frozen, Temperature, Tundra}
public class Planet
{
    private string name;
    private float mass;
    private float initial_speed;
    private float speed;
    private float spin;
    private Vector3 initial_direction;

    static public float max_mass = 10f;
    static public float max_speed = 10f;
    static public float max_spin = 100f;
    [SerializeField]
    static public int number_of_planets;

    public bool selected = false;
    public bool moused = false;
    public bool followed = false;


    static public float G = 6.67f;
    static private int count = 1;

    public Sprite type_planet;

    public Planet(float mass, float speed, GameObject game_obj, string name, float spin, int type)
    {
        Mass = mass;
        Initial_Speed = speed;
        Speed = speed;
        Name = name;
        Spin = spin;
        Game_obj = game_obj;
        Game_obj.GetComponent<Transform>().localScale = setRadius(mass);
        delta = new Vector3();
        this.type_planet = (Sprite)type;
    }

    public Planet(float mass, float speed, GameObject game_obj, string name, float spin, Vector3 delta, int type)
    {
        Mass = mass;
        Initial_Speed = speed;
        Speed = speed;
        Name = name;
        Spin = spin;
        Game_obj = game_obj;
        Game_obj.GetComponent<Transform>().localScale = setRadius(mass);
        this.delta = delta;
        this.type_planet = (Sprite)type;
    }

    private Vector3 setRadius(float mass)
    {
        return new Vector3(Mathf.Sqrt(mass), Mathf.Sqrt(mass), Mathf.Sqrt(mass));
    }

    [SerializeField]
    public float Mass
    {
        get { return mass; }
        set { if (value > 0 && value.GetType() == 1f.GetType()) mass = value; else mass = 1; }
    }

    [SerializeField]
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

    [SerializeField]
    public string Name
    {
        get { return name; }
        set { if (value != null && value != "" && value != "0" && value != "Planet" + Count) name = value; else name = "Planet" + count++; }
    }

    [SerializeField]
    public Vector3 Initial_Direction
    {
        get { return Vector3.left; }
        set { if (value.GetType() == new Vector3().GetType()) initial_direction = value; }
    }
    [SerializeField]
    public Vector3 delta { get; set; }
    [SerializeField]
    public float Spin
    {
        get { return spin; }
        set { if (value >= 0 && value.GetType() == 1f.GetType()) spin = value; else spin = 0; }
    }
    [SerializeField]
    public static int Count
    {
        get { return count; }
        set { if (value >= 0 && value.GetType() == 1.GetType()) count = value; }
    }
    [SerializeField]
    public GameObject Game_obj { get; set; }
}
