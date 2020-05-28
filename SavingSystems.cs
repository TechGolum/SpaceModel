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

    static SavingSystems()
    {
        names = new List<string>();
        speeds = new List<float>();
        masses = new List<float>();
        spins = new List<float>();
        init_poses = new List<SaveVector3>();
        deltas = new List<SaveVector3>();
    }
    static void GetAll()
    {
        foreach(Planet p in SystemsInfo.GetSelectedSystem().planets)
        {
            names.Add(p.Name);
            speeds.Add(p.Speed);
            masses.Add(p.Mass);
            spins.Add(p.Spin);
            init_poses.Add(new SaveVector3(p.Game_obj.transform.position.x, p.Game_obj.transform.position.y, p.Game_obj.transform.position.z));
            deltas.Add(new SaveVector3(p.delta.x, p.delta.y, p.delta.z));
        }
    }
    public void SaveGame()
    {
        GetAll();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, Planet.number_of_planets);
        bf.Serialize(file, masses);
        bf.Serialize(file, speeds);
        bf.Serialize(file, names);
        bf.Serialize(file, spins);
        bf.Serialize(file, init_poses);
        bf.Serialize(file, deltas);
        file.Close();
        Debug.Log("Game Saved");
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.A) && SystemsInfo.GetSelectedSystem().planets.Count > 0)
        {
            SaveGame();
        }
    }
}
