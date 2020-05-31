using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Systems
{
    public string name;
    public bool selected = true;
    static public int count = 1;
    
    static public List<Systems> systems = new List<Systems>();
    static public List<Planet> planets = new List<Planet>();

    static public string systems_file = "Systems.syst";
    public Systems(string name)
    {
        this.name = name;
    }
    static Systems()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + "/" + systems_file))
        {
            file = File.Open(Application.persistentDataPath + "/" + systems_file, FileMode.Open);
            count = (int)bf.Deserialize(file);
            for(int i = 0; i < count; i++)
            {
                systems.Add(new Systems(bf.Deserialize(file).ToString()));
            }
            file.Close();
        }
        else
        {
            count = 1;
            file = File.Create(Application.persistentDataPath + "/" + systems_file);
            bf.Serialize(file, 1);
            bf.Serialize(file, "System");
            file.Close();
            systems.Add(new Systems("System"));
        }

    }
}
