using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelSerializableRepository
{
    /// <summary>
    /// Return level data based on level id.
    /// </summary>
    /// <param name="levelId"></param>
    /// <returns></returns>
    public LevelSerializable GetById(int levelId)
    {
        string content = this.ReadFile(this.GetFilePath(levelId));
        LevelSerializable levelData = JsonUtility.FromJson<LevelSerializable>(content);
        return levelData;
    }

    private string GetFilePath(int levelId)
    {
        return Application.streamingAssetsPath + "/Level/Level" + levelId.ToString("00") + ".json";
    }

    private string ReadFile(string path)
    {
        if (File.Exists(path)) {
            using (StreamReader reader = new StreamReader(path)) {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        throw new System.Exception("File not found: " + path);
    }

}
