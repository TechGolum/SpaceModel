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
        Systems.systems.Add(new Systems(Name.text));
        Systems.systems[Systems.systems.Count - 1].selected = false;
    }
}
