using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    static public List<Planet> planets = new List<Planet>();
    Vector3 delta;
    Vector3 initial_direction;
    float g;
    float initial_speed;
    Vector3 R;
    float dt = 0.02f;

    void Start()
    {
        initial_speed = planets[planets.Count - 1].Initial_Speed;
        initial_direction = Vector3.left;
    }

    void Update()
    {
        if (!CreatePlanet.pause)
        {
            if (!GetPlanet(gameObject).moused)
            {
                foreach (Planet planet in planets)
                {
                    if (planet.Game_obj != this.gameObject)
                    {
                        R = this.gameObject.transform.position - planet.Game_obj.transform.position;
                        g = planet.Mass / (R.x * R.x + R.y * R.y + R.z * R.z);
                        delta += R * g;
                    }
                }
                transform.Translate(initial_direction * initial_speed * dt - delta * Planet.G * dt * dt / 2, Space.World);
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!CreatePlanet.pause && CreatePlanet.destroy)
        {
            planets.Remove(GetPlanet(gameObject));
            Destroy(gameObject);
        }
    }
}
