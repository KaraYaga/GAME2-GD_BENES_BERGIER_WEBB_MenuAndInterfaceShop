using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float goldStart;
    [SerializeField] private List<ObjectScript> objectsNeeded;
    private float gold;
    private bool didWin;

    [SerializeField] private List<ObjectScript> inventoryList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gold = goldStart;
        inventoryList = new List<ObjectScript>();
    }

    public void AddObjectToInventory(ObjectScript obj)
    {
        inventoryList.Add(obj);
        Debug.Log(obj.ID);

        if(inventoryList.Count >= objectsNeeded.Count )
        {
            if (CheckWinCondition())
            {
                Debug.Log("WIN");

                //GoToWInScreen
            }
            else if(!CheckWinCondition())
            {
                Debug.Log("FALSE");

                //GoToGameOverScreen
            }
        }
    }

    private bool CheckWinCondition()
    {
        foreach (ObjectScript itemBought in inventoryList)
        {
            if (!objectsNeeded.Contains(itemBought)) 
            {
                return false;
            } 
        }

        return true;
    }
}
