using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlanet : MonoBehaviour
{
    public GameObject planet;
    public InputField input_mass;
    public InputField input_speed;
    public InputField input_spin;


    public Slider slider;


    public GameObject params_folder;
    public Text Name;
    public Text Mass;
    public Text Speed;
    public Toggle Follow;

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
        if (slider.value != Planet.slow / 2)
        {
            Planet.slow = slider.value * 2;
        }
        if(GetSelectedPlanet() != null && timer > 1)
        {
            params_folder.SetActive(true);
            Name.text = "NAME: " + GetSelectedPlanet().Name;
            Mass.text = "MASS: " + GetSelectedPlanet().Mass;
            Speed.text = "SPEED: " + GetSelectedPlanet().Speed * 100;
            timer = 0;
        }
        if(Follow.isOn)
        {
            Camera.main.transform.position = new Vector3(GetSelectedPlanet().Game_obj.transform.position.x,  
                                                        Camera.main.transform.position.y, 
                                                        GetSelectedPlanet().Game_obj.transform.position.z);
        }
        //Debug.Log(GetSelectedPlanet().Speed);
        timer += Time.deltaTime;
    }

    public void Add()
    {
        Gravity.planets.Add(new Planet(int.Parse(input_mass.text), 
                                       int.Parse(input_speed.text), 
                                       int.Parse(input_spin.text), 
                                       Instantiate(planet, 
                                                   new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z),
                                                   new Quaternion())));
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
}
