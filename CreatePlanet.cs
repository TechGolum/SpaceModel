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
    public Toggle destroy_planet;
    public Dropdown planets_list;
    List<string> options;
    public static bool destroy = true;

    public GameObject params_folder;
    public Text Name;
    public Text Mass;
    public Text Speed;
    public Text Spin;
    public Toggle Follow;
    public GameObject d_folder;
    public Slider D;
    static public bool diselected = true;
    public Text Pause_Button;
    static public bool pause;

    float d = 20, timer;

    void Start()
    {
        timer = 0;
        d = Camera.main.transform.position.y;
    }

    void Update()
    {
        destroy = destroy_planet.isOn;
        planets_list.ClearOptions();
        options = new List<string>();
        options.Add("None");
        foreach(Planet p in Gravity.planets)
        {
            options.Add(p.Name);
        }
        planets_list.AddOptions(options);
        if (planets_list.value > 0 && GetSelectedPlanet() != Gravity.planets[planets_list.value - 1])
        {
            if(GetSelectedPlanet() != null) GetSelectedPlanet().selected = false;
            Gravity.planets[planets_list.value - 1].selected = true;
            Follow.isOn = Gravity.planets[planets_list.value - 1].followed;
        }
        if (Gravity.planets.Count > 0 && GetSelectedPlanet() != null && planets_list.value == 0) GetSelectedPlanet().selected = false;
        if (Input.GetKeyDown(KeyCode.P)) Pause();
        if(GetSelectedPlanet() != null)
        {
            params_folder.SetActive(true);
            Name.text = "NAME: " + GetSelectedPlanet().Name;
            Mass.text = "MASS: " + GetSelectedPlanet().Mass;
            Speed.text = "SPEED: " + GetSelectedPlanet().Speed;
            Spin.text = "SPIN: " + GetSelectedPlanet().Spin;
            timer = 0;
        }
        else
        {
            params_folder.SetActive(false);
        }
        if(!diselected)
        {
            Follow.isOn = GetSelectedPlanet().followed;
            diselected = true;
        }
        if(Follow.isOn)
        {
            foreach (Planet p in Gravity.planets) 
            {
                if (p.selected)
                {
                    foreach (Planet p1 in Gravity.planets)
                    {
                        p1.followed = false;
                    }
                    p.followed = true;
                    break;
                }
            }
        }
        else
        {
            try { GetSelectedPlanet().followed = false; } catch { }
        }
        d_folder.SetActive(Follow.isOn);
        if (GetFollowedPlanet() != null)
        {
            d = D.value;
            if (!ViewScroll.v2)
            {
                Camera.main.transform.position = new Vector3(GetFollowedPlanet().Game_obj.transform.position.x,
                                                         GetFollowedPlanet().Game_obj.transform.position.y + d,
                                                         GetFollowedPlanet().Game_obj.transform.position.z);
            }
            else
            {
                Camera.main.transform.position = new Vector3(GetFollowedPlanet().Game_obj.transform.position.x,
                                                              GetFollowedPlanet().Game_obj.transform.position.y,
                                                              GetFollowedPlanet().Game_obj.transform.position.z - d);
            }
        }
        timer += Time.deltaTime;

    }
    public void Add()
    {
        if (GetFollowedPlanet() == null)
        {
            Vector3 init_pos = !ViewScroll.v2 ?
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
            GameObject g = Instantiate(planet,
                                                       init_pos,
                                                       new Quaternion());
            Gravity.planets.Add(new Planet(int.Parse(input_mass.text),
                                           int.Parse(input_speed.text),
                                           g,
                                           input_name.text,
                                           int.Parse(input_spin.text)));
            Gravity.planets[Gravity.planets.Count - 1].selected = true;
            Camera.main.transform.Translate(Vector3.left * int.Parse(input_mass.text) * 2, Space.Self);
        }
    }
    static public Planet GetSelectedPlanet()
    {
        foreach(Planet p in Gravity.planets)
        {
            if (p.selected)
                return p;
        }
        return null;
    }
    static public Planet GetFollowedPlanet()
    {
        foreach (Planet p in Gravity.planets)
        {
            if (p.followed)
                return p;
        }
        return null;
    }

    public void Pause()
    {
        pause = !pause;
        Pause_Button.text = pause ? "PLAY" : "PAUSE";
    }

    bool nameExists(string name)
    {
        foreach(Planet p in Gravity.planets)
        {
            if (p.Name == name) return true;
        }
        return false;
    }

}
