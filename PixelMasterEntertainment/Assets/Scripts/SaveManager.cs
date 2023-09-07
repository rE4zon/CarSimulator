using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int currentCar;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Stotrage data = (PlayerData_Stotrage)bf.Deserialize(file);

            currentCar = data.currentCar;

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Stotrage data = new PlayerData_Stotrage();

        data.currentCar = currentCar;

        bf.Serialize(file, data);
        file.Close();
    }

    [Serializable]
    class PlayerData_Stotrage
    {
        public int currentCar;
    }
}
