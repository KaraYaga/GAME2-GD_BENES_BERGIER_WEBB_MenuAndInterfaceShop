using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shop1Canva, shop2Canva, UI, ingredientsList, inventoryObject;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private float inventorySize;
    private int numberOfItemInventory;
    private bool listIsShowing = false;
    private ObjectData shopItem;
    private GameObject objectButton;
    private GameManager gameManager;

    [Header("PopUp")]
    [SerializeField] private RawImage popUpImage;
    [SerializeField] GameObject popUp, moneyPopUp, shopKeeperPopUp;
    [SerializeField] TextMeshProUGUI popUpName, popUpRarity, popUpPrice;

    private void Start()
    {
        gameManager = GameManager.instance;

        UI.SetActive(false);
        shop1Canva.SetActive(false); 
        shop2Canva.SetActive(false);
        popUp.SetActive(false);
        moneyPopUp.SetActive(false);
        shopKeeperPopUp.SetActive(false);

        numberOfItemInventory = 0;
        money.text = "" + gameManager.GetGold();
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

        if(Input.GetKey(KeyCode.Escape) && shop1Canva.activeSelf && !popUp.activeSelf && !moneyPopUp.activeSelf && !shopKeeperPopUp.activeSelf)
        {
            shop1Canva.SetActive(false);
            UI.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape) && shop2Canva.activeSelf && !popUp.activeSelf && !moneyPopUp.activeSelf && !shopKeeperPopUp.activeSelf)
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

    public void ExitPopUp(GameObject popUpObject)
    {
        popUpObject.SetActive(false);
    }

    public void BuyObject()
    {
        if(numberOfItemInventory < gameManager.GetObjectNeeded().Count)
        {
            if(gameManager.GetGold() >= shopItem.data.price)
            {
                gameManager.AddObjectToInventory(shopItem.data);
                popUp.SetActive(false);
                Destroy(objectButton);

                inventoryObject.transform.GetChild(numberOfItemInventory).GetComponent<TextMeshProUGUI>().text = shopItem.data.ID;
                numberOfItemInventory++;

                gameManager.LoseGold(shopItem.data.price);
                money.text = "" + gameManager.GetGold();
            }
            else
            {
                moneyPopUp.SetActive(true);
                popUp.SetActive(false);
            }
        }
    }

    public void ShopKeeperInteraction()
    {
        shopKeeperPopUp.SetActive(true);
    }
}
