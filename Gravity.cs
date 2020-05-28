using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    static public List<Planet> planets = new List<Planet>();
    float g;
    Vector3 R;
    float dt = 0.02f;

    void Update()
    {
        if (!PlanetsInfo.pause)
        {
            Planet.number_of_planets = planets.Count;
            if (!PlanetsInfo.GetPlanet(gameObject).moused)
            {
                foreach (Planet planet in planets)
                {
                    if (planet.Game_obj != this.gameObject)
                    {
                        R = this.gameObject.transform.position - planet.Game_obj.transform.position;
                        g = planet.Mass / (R.x * R.x + R.y * R.y + R.z * R.z);
                        PlanetsInfo.GetPlanet(gameObject).delta += R * g;
                    }
                }
                transform.Translate(PlanetsInfo.GetPlanet(gameObject).Initial_Direction * PlanetsInfo.GetPlanet(gameObject).Initial_Speed * dt -
                    PlanetsInfo.GetPlanet(gameObject).delta * Planet.G * dt * dt / 2, Space.World);
                if (!PlanetsInfo.pause)
                    transform.Rotate(0, PlanetsInfo.GetPlanet(gameObject).Spin * Time.deltaTime, 0, Space.Self);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!PlanetsInfo.pause && PlanetsInfo.destroy)
        {
            planets.Remove(PlanetsInfo.GetPlanet(gameObject));
            Destroy(gameObject);
        }
    }
}
