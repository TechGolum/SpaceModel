using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CreateSystem : MonoBehaviour
{
    public InputField Name;
    BinaryFormatter bf;
    void Update()
    {
        
    }

    public void AddSystem()
    {
        Systems.systems.Add(new Systems(Name.text));
        Systems.systems[Systems.systems.Count - 1].selected = false;
        bf = new BinaryFormatter();
        FileStream file;
        file = File.Open(Application.persistentDataPath + "/" + Systems.systems_file, FileMode.Open);
        Systems.count++;
        bf.Serialize(file, Systems.count);
        for (int i = 0; i < Systems.count; i++)
        {
            bf.Serialize(file, Systems.systems[i].name);
        }
        file.Close();
    }
}
