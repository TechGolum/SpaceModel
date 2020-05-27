using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetsInfo : MonoBehaviour
{
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
    static public bool diselected = false;
    public Text Pause_Button;
    static public bool pause;

    void Update()
    {
        if (Gravity.planets.Count > 0)
        {
            destroy = destroy_planet.isOn;
            CreateOptions();
            Diselect();

            if (Input.GetKeyDown(KeyCode.P)) Pause();

            ShowParams();
            FollowPlanet();
        }
        else
            params_folder.SetActive(false);
        d_folder.SetActive(Follow.isOn);
    }

    void Diselect()
    {
        if (planets_list.value > 0 && GetSelectedPlanet() != Gravity.planets[planets_list.value - 1])
        {
            if (GetSelectedPlanet() != null) GetSelectedPlanet().selected = false;
            Gravity.planets[planets_list.value - 1].selected = true;
            Follow.isOn = Gravity.planets[planets_list.value - 1].followed;
            diselected = true;
        }
        if (Gravity.planets.Count > 0 && GetSelectedPlanet() != null && planets_list.value == 0) GetSelectedPlanet().selected = false;
    }

    void FollowPlanet()
    {
        if (diselected)
        {
            Follow.isOn = GetSelectedPlanet().followed;
            diselected = false;
        }
        if (Follow.isOn)
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
            GetSelectedPlanet().followed = false;
    }

    void ShowParams()
    {
        if (GetSelectedPlanet() != null)
        {
            params_folder.SetActive(true);
            Name.text = "NAME: " + GetSelectedPlanet().Name;
            Mass.text = "MASS: " + GetSelectedPlanet().Mass;
            Speed.text = "SPEED: " + GetSelectedPlanet().Speed;
            Spin.text = "SPIN: " + GetSelectedPlanet().Spin;
        }
        else
            params_folder.SetActive(false);
    }

    void CreateOptions()
    {
        planets_list.ClearOptions();
        options = new List<string>();
        options.Add("None");
        foreach (Planet p in Gravity.planets)
        {
            options.Add(p.Name);
        }
        planets_list.AddOptions(options);
    }

    static public Planet GetSelectedPlanet()
    {
        foreach (Planet p in Gravity.planets)
        {
            if (p.selected)
                return p;
        }
        return null;
    }

    static public Planet GetFollowedPlanet()
    {
        try
        {
            foreach (Planet p in Gravity.planets)
            {
                if (p.followed)
                    return p;
            }
        }
        catch { }
        return null;
    }

    static public Planet GetPlanet(GameObject gObj)
    {
        foreach (Planet p in Gravity.planets)
        {
            if (p.Game_obj == gObj)
                return p;
        }
        return null;
    }

    public void Pause()
    {
        pause = !pause;
        Pause_Button.text = pause ? "PLAY" : "PAUSE";
    }
}
