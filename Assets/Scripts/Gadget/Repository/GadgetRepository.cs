using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetRepository
{
    private string DICTIONARY_PATH = "ScriptableObjects/Gadget/GadgetDictionary";

    private static GadgetDictionary _dictionary;

    /// <summary>
    /// Return all gadget prefabs
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetAll()
    {
        if (GadgetRepository._dictionary == null) GadgetRepository._dictionary = Resources.Load<GadgetDictionary>(this.DICTIONARY_PATH);
        return GadgetRepository._dictionary.GetAll();
    }

    /// <summary>
    /// Return gadget prefab based on id in dictionary.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public GameObject GetById(int id)
    {
        return this.GetAll()[id - 1];
    }
}