using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float goldStart;
    [SerializeField] private List<ObjectScript> objectsNeeded;
    [SerializeField] private string GameOverScene, WinScene;
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

                SceneManager.LoadScene(WinScene);
            }
            else if(!CheckWinCondition())
            {
                Debug.Log("LOSE");

                SceneManager.LoadScene(GameOverScene);
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
