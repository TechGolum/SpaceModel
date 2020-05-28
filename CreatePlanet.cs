//using NUnit.Framework.Internal.Execution;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlanet : MonoBehaviour
{
    public GameObject planet;
    public InputField input_mass;
    public InputField input_speed;
    public InputField input_name;
    public InputField input_spin;
    public void Add()
    {
        if (PlanetsInfo.GetFollowedPlanet() == null)
        {
            Vector3 init_pos = !ChangeScreens.v2 ?
                new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z) :
                new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

            input_mass.text = input_mass.text == "" ? "1" : input_mass.text;
            if (int.Parse(input_mass.text) > Planet.max_mass) input_mass.text = Planet.max_mass.ToString();
            if (int.Parse(input_mass.text) <= 0) input_mass.text = "1";

            input_speed.text = input_speed.text == "" ? "0" : input_speed.text;
            if (int.Parse(input_speed.text) > Planet.max_speed) input_speed.text = Planet.max_speed.ToString();
            if (int.Parse(input_speed.text) <= 0) input_speed.text = "0";

            input_spin.text = input_spin.text == "" ? "30" : input_spin.text;
            if (int.Parse(input_spin.text) > Planet.max_spin) input_spin.text = Planet.max_spin.ToString();
            if (int.Parse(input_spin.text) <= 0) input_spin.text = "0";

            input_name.text = input_name.text == "" || input_name.text == "Planet" + (Planet.Count - 1) ? "Planet" + Planet.Count : input_name.text;
            if (nameExists(input_name.text)) input_name.text += "*";
            GameObject g = Instantiate(planet, init_pos, new Quaternion());
            Systems.planets.Add(new Planet(int.Parse(input_mass.text), int.Parse(input_speed.text), g, input_name.text, int.Parse(input_spin.text)));
            Systems.planets[Systems.planets.Count - 1].selected = true;
            Camera.main.transform.Translate(Vector3.left * int.Parse(input_mass.text) * 2, Space.Self);
        }
    }
    bool nameExists(string name)
    {
        try
        {
            foreach (Planet p in Systems.planets)
            {
                if (p.Name == name) return true;
            }
        }
        catch { }
        return false;
    }

}
