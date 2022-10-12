using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRepository
{
    private string DICTIONARY_PATH = "ScriptableObjects/Robot/RobotDictionary";

    private static RobotDictionary _dictionary;

    /// <summary>
    /// Return all robot prefabs
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetAll()
    {
        if (RobotRepository._dictionary == null) RobotRepository._dictionary = Resources.Load<RobotDictionary>(this.DICTIONARY_PATH);
        return RobotRepository._dictionary.GetAll();
    }

    /// <summary>
    /// Return robot prefab based on id in dictionary.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public GameObject GetById(int id)
    {
        return this.GetAll()[id - 1];
    }
}
