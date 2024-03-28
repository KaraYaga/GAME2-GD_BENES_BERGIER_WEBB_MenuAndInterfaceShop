using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shop1Canva, shop2Canva, UI, ingredientsList;
    private bool listIsShowing = false;

    [Header("PopUp")]
    [SerializeField] GameObject popUp;
    [SerializeField] private RawImage popUpImage;
    [SerializeField] TextMeshProUGUI popUpName, popUpRarity, popUpPrice;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            listIsShowing = !listIsShowing;
        }

        if (listIsShowing)
        {
            ingredientsList.SetActive(true);
            listIsShowing = true;
        }
        else
        {
            ingredientsList.SetActive(false);
            listIsShowing = false;
        }

        if(Input.GetKey(KeyCode.Escape) && shop1Canva.activeSelf && !popUp.activeSelf)
        {
            shop1Canva.SetActive(false);
            UI.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape) && shop2Canva.activeSelf && !popUp.activeSelf)
        {
            shop2Canva.SetActive(false);
            UI.SetActive(false);
        }
    }

    public void OpenShop1()
    {
        shop1Canva.SetActive(true);
        UI.SetActive(true);
    }

    public void OpenShop2()
    {
        shop2Canva.SetActive(true);
        UI.SetActive(true);
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

    public void DontBuy()
    {
        popUp.SetActive(false);
    }
}
