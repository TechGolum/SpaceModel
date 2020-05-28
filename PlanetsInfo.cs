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

    public GameObject add_folder, params_folder;
    public Text Name;
    public Text Mass;
    public Text Speed;
    public Text Spin;
    public Toggle Follow;
    public GameObject d_folder;
    static public bool diselected = false;
    public Text Pause_Button;
    static public bool pause;
    public Toggle showSpace;

    void Update()
    {
        if (SystemsInfo.GetSelectedSystem().planets.Count > 0)
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
        add_folder.SetActive(showSpace.isOn);
    }

    void Diselect()
    {
        if (planets_list.value > 0 && GetSelectedPlanet() != SystemsInfo.GetSelectedSystem().planets[planets_list.value - 1])
        {
            if (GetSelectedPlanet() != null) GetSelectedPlanet().selected = false;
            SystemsInfo.GetSelectedSystem().planets[planets_list.value - 1].selected = true;
            Follow.isOn = SystemsInfo.GetSelectedSystem().planets[planets_list.value - 1].followed;
            diselected = true;
        }
        if (SystemsInfo.GetSelectedSystem().planets.Count > 0 && GetSelectedPlanet() != null && planets_list.value == 0) GetSelectedPlanet().selected = false;
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
            foreach (Planet p in SystemsInfo.GetSelectedSystem().planets)
            {
                if (p.selected)
                {
                    foreach (Planet p1 in SystemsInfo.GetSelectedSystem().planets)
                    {
                        p1.followed = false;
                    }
                    p.followed = true;
                    break;
                }
            }
        }
        else
            if(GetSelectedPlanet() != null) GetSelectedPlanet().followed = false;
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
        foreach (Planet p in SystemsInfo.GetSelectedSystem().planets)
        {
            options.Add(p.Name);
        }
        planets_list.AddOptions(options);
    }

    static public Planet GetSelectedPlanet()
    {
        if (SystemsInfo.GetSelectedSystem().planets.Count > 0)
        {
            foreach (Planet p in SystemsInfo.GetSelectedSystem().planets)
            {
                if (p.selected)
                    return p;
            }
        }
        return null;
    }

    static public Planet GetFollowedPlanet()
    {
        if (SystemsInfo.GetSelectedSystem().planets.Count > 0)
        {
            foreach (Planet p in SystemsInfo.GetSelectedSystem().planets)
            {
                if (p.followed)
                    return p;
            }
        }
        return null;
    }

    static public Planet GetPlanet(GameObject gObj)
    {
        if (SystemsInfo.GetSelectedSystem().planets.Count > 0)
        {
            foreach (Planet p in SystemsInfo.GetSelectedSystem().planets)
            {
                if (p.Game_obj == gObj)
                    return p;
            }
        }
        return null;
    }

    public void Pause()
    {
        pause = !pause;
        Pause_Button.text = pause ? "PLAY" : "PAUSE";
    }
}
