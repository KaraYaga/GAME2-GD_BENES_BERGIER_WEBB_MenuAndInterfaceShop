using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float goldStart;

    [Header("PopUp")]
    [SerializeField] GameObject popUp;
    [SerializeField] private RawImage popUpImage;
    [SerializeField] TextMeshProUGUI popUpName, popUpRarity, popUpPrice;

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

        popUpPrice.text = "" + shopItem.data.price;
        popUpName.text = shopItem.data.ID;
        popUpRarity.text = shopItem.data.rarity;
        popUpImage.texture = shopItem.data.image;

        popUp.SetActive(true);
    }
}
