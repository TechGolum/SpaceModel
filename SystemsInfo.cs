using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemsInfo : MonoBehaviour
{
    public Text Name, planets_count;
    public Dropdown systems_list;
    public GameObject System_folder;
    public Toggle hide_system;
    static public bool changed = false;
    private void Start()
    {
        systems_list.value = 0;
    }
    void Update()
    {
        SetParams();
        SetOptions();
        System_folder.SetActive(hide_system.isOn);
    }

    static public Systems GetSelectedSystem()
    {
        foreach(Systems s in Systems.systems)
        {
            if (s.selected) return s;
        }
        return null;
    }

    void SetParams()
    {
        Name.text = "NAME: " + GetSelectedSystem().name;
        planets_count.text = "PLANETS: " + Systems.planets.Count.ToString();
    }

    void SetOptions()
    {
        if (Systems.systems.IndexOf(GetSelectedSystem()) != systems_list.value) changed = true;
        if (GetSelectedSystem() != null)
        {
            List<string> options = new List<string>();
            foreach (Systems s in Systems.systems)
            {
                options.Add(s.name);
            }
            systems_list.ClearOptions();
            systems_list.AddOptions(options);
            GetSelectedSystem().selected = false;
            Systems.systems[systems_list.value].selected = true;
        }
    }
}
