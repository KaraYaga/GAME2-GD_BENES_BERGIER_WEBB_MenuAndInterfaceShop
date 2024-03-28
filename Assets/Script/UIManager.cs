using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shop1Canva, shop2Canva, UI, ingredientsList, inventoryObject;
    [SerializeField] private float inventorySize;
    private int numberOfItemInventory;
    private bool listIsShowing = false;
    private ObjectData shopItem;
    private GameObject objectButton;

    [Header("PopUp")]
    [SerializeField] GameObject popUp;
    [SerializeField] private RawImage popUpImage;
    [SerializeField] TextMeshProUGUI popUpName, popUpRarity, popUpPrice;

    private void Start()
    {
        shop1Canva.SetActive(false); 
        shop2Canva.SetActive(false);
        popUp.SetActive(false);

        numberOfItemInventory = 0;
    }

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
        shopItem = button.GetComponent<ObjectData>();
        objectButton = button;

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

    public void BuyObject()
    {
        if(numberOfItemInventory < inventorySize)
        {
            GameManager.instance.AddObjectToInventory(shopItem);
            popUp.SetActive(false);
            Destroy(objectButton);

            inventoryObject.transform.GetChild(numberOfItemInventory).GetComponent<TextMeshProUGUI>().text = shopItem.data.ID;
            numberOfItemInventory++;
        }
    }
}
