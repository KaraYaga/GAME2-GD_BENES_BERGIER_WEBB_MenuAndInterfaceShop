using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float goldStart;

    private Sprite shopItemImage;
    private int shopItemPrice;
    private float gold;
    private string shopItemName, shopItemRarity;

    private void Start()
    {
        gold = goldStart;
    }

    public void ShowItemData(GameObject button)
    {
        ObjectData shopItem = button.GetComponent<ObjectData>();

        shopItemName = shopItem.data.ID;
        shopItemRarity = shopItem.data.rarity;
        shopItemPrice = shopItem.data.price;
        shopItemImage = shopItem.data.image;
    }
}
