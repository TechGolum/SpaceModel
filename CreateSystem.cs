using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSystem : MonoBehaviour
{
    public InputField Name;
    void Update()
    {
        
    }

    public void AddSystem()
    {
        if (Name.text == "") Name.text = "System1";
        Systems.systems.Add(new Systems(Name.text));
    }
}
