using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    static public List<Planet> planets = new List<Planet>();
    Vector3 distanse;
    Vector3 delta;
    Vector3 initial_direction;
    float g;
    float initial_speed;
    Vector3 R;
    static public bool pause = false;
    float dt = 0.02f;

    void Start()
    {
        initial_speed = planets[planets.Count - 1].Initial_Speed;
        distanse = this.gameObject.transform.position;
        initial_direction = Vector3.left;
    }

    void Update()
    {
        if (!pause)
        {
            if (!GetPlanet(gameObject).moused)
            {
                delta = new Vector3();
                foreach (Planet planet in planets)
                {
                    if (planet.Game_obj != this.gameObject)
                    {
                        R = this.gameObject.transform.position - planet.Game_obj.transform.position;
                        g = planet.Mass / (R.x * R.x + R.y * R.y + R.z * R.z);
                        delta += R * g;
                    }
                }
                transform.Translate(initial_direction * initial_speed * dt - delta * Planet.G * dt * dt / 2);
                GetPlanet(gameObject).Speed = Mathf.Sqrt(Mathf.Pow(transform.position.x - distanse.x, 2) + Mathf.Pow(transform.position.y - distanse.y, 2) + Mathf.Pow(transform.position.z - distanse.z, 2)) / dt;
                initial_speed = GetPlanet(gameObject).Speed;
                initial_direction = (transform.position - distanse) * 50f;
                Debug.Log(initial_direction);
            }
            distanse = transform.position;
        }
    }

    static public Planet GetPlanet(GameObject gObj)
    {
        foreach (Planet p in planets)
        {
            if (p.Game_obj == gObj)
                return p;
        }
        return null;
    }
}
