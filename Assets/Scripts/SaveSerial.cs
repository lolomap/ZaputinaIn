using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSerial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/progress.dat");
        SaveData data = new SaveData();
        data.score = Clicker.score;
        data.upgrades = Upgrade.upgrades;
        data.employers = Clicker.employers;
        data.coinsPerSecond = TimeClicker.coinsPerSecond;
        bf.Serialize(file, data);
        file.Close();
    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/progress.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/progress.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Clicker.score = data.score;
            Upgrade.upgrades = data.upgrades;
            Clicker.employers = data.employers;
            TimeClicker.coinsPerSecond = data.coinsPerSecond;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.Log("There is no save data!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class SaveData
{
    public int score, employers, coinsPerSecond;
    public Dictionary<string, bool> upgrades;
}
