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
    static public bool pause = true;
    public Toggle showSpace;

    void Update()
    {
        if (Systems.planets.Count > 0)
        {
            destroy = destroy_planet.isOn;
            CreateOptions();
            Diselect();

            if (Input.GetKeyDown(KeyCode.P)) Pause();

            ShowParams();
            FollowPlanet();
        }
        else
        {
            params_folder.SetActive(false);
            planets_list.ClearOptions();
            options = new List<string>();
            options.Add("None");
            planets_list.AddOptions(options);
        }
        d_folder.SetActive(GetFollowedPlanet() != null && showSpace.isOn);
        add_folder.SetActive(showSpace.isOn);
        if (GetSelectedPlanet() != null)
        {
            params_folder.SetActive(showSpace.isOn);
        }
    }

    void Diselect()
    {
        if (planets_list.value > Systems.planets.Count) planets_list.value = 0;
        if (planets_list.value > 0 && planets_list.value <= Systems.planets.Count && GetSelectedPlanet() != Systems.planets[planets_list.value - 1])
        {
            if (GetSelectedPlanet() != null) GetSelectedPlanet().selected = false;
            Systems.planets[planets_list.value - 1].selected = true;
            Follow.isOn = Systems.planets[planets_list.value - 1].followed;
            diselected = true;
        }
        if (Systems.planets.Count > 0 && GetSelectedPlanet() != null && planets_list.value == 0) GetSelectedPlanet().selected = false;
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
            foreach (Planet p in Systems.planets)
            {
                if (p.selected)
                {
                    foreach (Planet p1 in Systems.planets)
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
        foreach (Planet p in Systems.planets)
        {
            options.Add(p.Name);
        }
        planets_list.AddOptions(options);
    }

    static public Planet GetSelectedPlanet()
    {
        if (Systems.planets.Count > 0)
        {
            foreach (Planet p in Systems.planets)
            {
                if (p.selected)
                    return p;
            }
        }
        return null;
    }

    static public Planet GetFollowedPlanet()
    {
        if (Systems.planets.Count > 0)
        {
            foreach (Planet p in Systems.planets)
            {
                if (p.followed)
                    return p;
            }
        }
        return null;
    }
    static public Planet GetMousedPlanet()
    {
        if (Systems.planets.Count > 0)
        {
            foreach (Planet p in Systems.planets)
            {
                if (p.moused)
                    return p;
            }
        }
        return null;
    }

    static public Planet GetPlanet(GameObject gObj)
    {
        if (Systems.planets.Count > 0)
        {
            foreach (Planet p in Systems.planets)
            {
                if (p.Game_obj == gObj)
                    return p;
            }
        }
        return null;
    }

    public void DeletePlanet()
    {
        if (GetSelectedPlanet() == GetFollowedPlanet()) Follow.isOn = false;
        Destroy(GetSelectedPlanet().Game_obj);
        Systems.planets.Remove(GetSelectedPlanet());
    }

    public void Pause()
    {
        pause = !pause;
        Pause_Button.text = pause ? "PLAY" : "PAUSE";
    }
}
