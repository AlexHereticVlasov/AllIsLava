﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Saver
{
    public static void SaveData<T>(T data, string fileName)
    {
        string path = GetPath(fileName);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static T LoadData<T>(string fileName)
    {
        string path = GetPath(fileName);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            T resoult = (T)formatter.Deserialize(fileStream);
            fileStream.Close();
            return resoult;
        }
        return default;
    }

    public static void DeleteFile(string fileName)
    {
        File.Delete(GetPath(fileName));
    }

    private static string GetPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName + ".sav";
    }
}
