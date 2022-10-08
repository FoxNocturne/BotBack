using System.Collections.Generic;
using UnityEngine;

public class Dictionary<T> : ScriptableObject
{
    [SerializeField] private List<T> _listItem;

    public List<T> GetAll()
    {
        return this._listItem;
    }

    public T GetById(int index)
    {
        return this._listItem[index];
    }
}