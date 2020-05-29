using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

    public void DeleteSystem()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file= File.Open(Application.persistentDataPath + "/" + Systems.systems_file, FileMode.Open);
        File.Delete(Application.persistentDataPath + "/" + GetSelectedSystem().name + ".save");
        changed = true;
        if (Systems.count > 1)
        {

            Systems.systems.Remove(GetSelectedSystem());
            Systems.systems[0].selected = true;
            Systems.count--;
            bf.Serialize(file, Systems.count);
            for (int i = 0; i < Systems.count; i++)
            {
                bf.Serialize(file, Systems.systems[i].name);
            }
        }
        else
        {
            Systems.systems.Remove(GetSelectedSystem());
            Systems.systems.Add(new Systems("System1"));
            bf.Serialize(file, 1);
            bf.Serialize(file, "System1");
        }
        systems_list.value = 0;
        file.Close();
    }
}
