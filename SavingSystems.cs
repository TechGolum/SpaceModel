using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.IO;

public class SavingSystems
{
    static public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, Gravity.planets);
        file.Close();
        Debug.Log("Game Saved");
    }
}
