using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadingSystems : MonoBehaviour
{
    public GameObject planet;
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/" + SystemsInfo.GetSelectedSystem().name + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + SystemsInfo.GetSelectedSystem().name + ".save", FileMode.Open);
            int count = (int)bf.Deserialize(file);
            List<float> masses = (List<float>)bf.Deserialize(file);
            List<float> speeds = (List<float>)bf.Deserialize(file);
            List<string> names = (List<string>)bf.Deserialize(file);
            List<float> spins = (List<float>)bf.Deserialize(file);
            List<SaveVector3> init_poses = (List<SaveVector3>)bf.Deserialize(file);
            List<SaveVector3> deltas = (List<SaveVector3>)bf.Deserialize(file);
            List<Sprite> sprites = (List<Sprite>)bf.Deserialize(file);
            file.Close();
            GameObject g;
            foreach(Planet p in Systems.planets)
            {
                Destroy(p.Game_obj);
            }
            Systems.planets = new List<Planet>();
            for (int i = 0; i < count; i++)
            {
                g = Instantiate(planet, new Vector3(init_poses[i].x, init_poses[i].y, init_poses[i].z), new Quaternion());
                Systems.planets.Add(new Planet(masses[i], speeds[i], g, names[i], spins[i], new Vector3(deltas[i].x, deltas[i].y, deltas[i].z), (int)sprites[i]));
            }
            Planet.Count = count + 1;
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("Game created");
            foreach (Planet p in Systems.planets)
            {
                Destroy(p.Game_obj);
            }
            Systems.planets = new List<Planet>();
        }
    }
    private void Start()
    {
        LoadGame();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        {
            LoadGame();
        }
        if (SystemsInfo.changed)
        {
            LoadGame();
            SystemsInfo.changed = false;
        }
    }
}
