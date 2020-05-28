using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemsInfo : MonoBehaviour
{
    public Text Name, planets_count;
    public Dropdown systems_list;
    void Update()
    {
        SetParams();
        SetOptions();
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
        planets_count.text = "PLANETS: " + GetSelectedSystem().planets.Count.ToString();
    }

    void SetOptions()
    {
        List<string> options = new List<string>();
        foreach(Systems s in Systems.systems)
        {
            options.Add(s.name);
        }
        systems_list.AddOptions(options);
    }
}
