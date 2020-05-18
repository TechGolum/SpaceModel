//using NUnit.Framework.Internal.Execution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlanet : MonoBehaviour
{
    public GameObject planet;
    public InputField input_mass;
    public InputField input_speed;
    public InputField input_name;

    public GameObject params_folder;
    public Text Name;
    public Text Mass;
    public Text Speed;
    public Toggle Follow;
    static public bool diselected = true;

    float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Gravity.pause = !Gravity.pause;
        }
        if(GetSelectedPlanet() != null)
        {
            params_folder.SetActive(true);
            Name.text = "NAME: " + GetSelectedPlanet().Name;
            Mass.text = "MASS: " + GetSelectedPlanet().Mass;
            Speed.text = "SPEED: " + GetSelectedPlanet().Speed;
            timer = 0;
        }
        if(!diselected)
        {
            Follow.isOn = false;
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
            GetSelectedPlanet().followed = false;
        }
        if(GetFollowedPlanet() != null)
        {
            Camera.main.transform.position = new Vector3(GetFollowedPlanet().Game_obj.transform.position.x,  
                                                        Camera.main.transform.position.y, 
                                                        GetFollowedPlanet().Game_obj.transform.position.z);
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
            input_speed.text = input_speed.text == "" ? "0" : input_speed.text;
            input_name.text = input_name.text == "" || input_name.text == "Planet" + (Planet.Count - 1) ? "Planet" + Planet.Count : input_name.text;
            Gravity.planets.Add(new Planet(int.Parse(input_mass.text),
                                           int.Parse(input_speed.text),
                                           Instantiate(planet,
                                                       init_pos,
                                                       new Quaternion()),
                                           input_speed.text));
            Camera.main.transform.Translate(Vector3.left * int.Parse(input_mass.text)* 2);
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
}
