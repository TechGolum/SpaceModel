using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.IO;

public class SavingSystems : MonoBehaviour
{
    static List<string> names;
    static List<float> speeds;
    static List<float> masses;
    static List<float> spins;
    static List<SaveVector3> init_poses;
    static List<SaveVector3> deltas;
    static List<Sprite> types;
    float timer = 0f;
    static void GetAll()
    {
        names = new List<string>();
        speeds = new List<float>();
        masses = new List<float>();
        spins = new List<float>();
        init_poses = new List<SaveVector3>();
        deltas = new List<SaveVector3>();
        types = new List<Sprite>();
        foreach (Planet p in Systems.planets)
        {
            names.Add(p.Name);
            speeds.Add(p.Speed);
            masses.Add(p.Mass);
            spins.Add(p.Spin);
            init_poses.Add(new SaveVector3(p.Game_obj.transform.position.x, p.Game_obj.transform.position.y, p.Game_obj.transform.position.z));
            deltas.Add(new SaveVector3(p.delta.x, p.delta.y, p.delta.z));
            types.Add(p.type_planet);
        }
    }
    public void SaveGame()
    {
        GetAll();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        file = File.Create(Application.persistentDataPath + "/" + SystemsInfo.GetSelectedSystem().name + ".save");

        bf.Serialize(file, Planet.number_of_planets);
        bf.Serialize(file, masses);
        bf.Serialize(file, speeds);
        bf.Serialize(file, names);
        bf.Serialize(file, spins);
        bf.Serialize(file, init_poses);
        bf.Serialize(file, deltas);
        bf.Serialize(file, types);
        file.Close();
        Debug.Log("Game Saved");
    }
    private void Update()
    {
        Planet.number_of_planets = Systems.planets.Count;
        if (timer >= 1)
        {
            if(!SystemsInfo.changed && Systems.planets.Count > 0) SaveGame();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
