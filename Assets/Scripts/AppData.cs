using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AppData
{
    // this system will have generic methods to serialize and deserialize almost any kind of data we want
    // except Monobehaviours, gameobjects, prefabs, etc.
    // however almost everything is ok, built in types, your own POCo

    // this system needs Two generic methods

    // one method to save object of Any type
    // needs to check if a DIRECTORY exsits, and if not creat it automatically!
    // needs to check if file exists, and if not, create it automatically
    // needs to save the file, with the serialized object
    // public static Save<T>

    // for example using save will look like this
    // AppDataSystem.Save(obj, fileName);

    // one method to Load objects of any type
    // public static Load<T>
    // needs to Load and return the requested object, if the file exists
    // needs to Load and return a default object, if the file doesn't exsit

    public static void Save<T>(T obj, string filename)
    {
        var directoryPath = $"{Application.dataPath}/Hackman/StreamingAssets/" + typeof(T).Name;
        var fullFilePath = directoryPath + "/" + filename;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (!File.Exists(fullFilePath))
        {
            var fileStream = File.Create(fullFilePath);
            fileStream.Close();
        }

        var level = JsonConvert.SerializeObject(obj);
        File.WriteAllText(fullFilePath, level);
    }

    public static void Load<T>(string filename)
    {

    }
}
