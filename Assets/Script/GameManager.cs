using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float goldStart;
    private float gold;

    private List<ObjectData> inventoryList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gold = goldStart;
        inventoryList = new List<ObjectData>();
    }

    public void AddObjectToInventory(ObjectData obj)
    {
        inventoryList.Add(obj);
        Debug.Log(obj.data.ID);
    }
}
