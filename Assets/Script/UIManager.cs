using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shop1Canva, shop2Canva, UI, ingredientsList;
    private bool listIsShowing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !listIsShowing)
        {
            ingredientsList.SetActive(true);
            listIsShowing = true;
        }

        if (Input.GetKeyUp(KeyCode.E) && listIsShowing)
        {
            ingredientsList.SetActive(false);
            listIsShowing = false;
        }

        if(Input.GetKey(KeyCode.Escape) && shop1Canva.activeSelf)
        {
            shop1Canva.SetActive(false);
            UI.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape) && shop2Canva.activeSelf)
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
}
