using UnityEngine;

public class ShopBTN : MonoBehaviour
{
    public GameObject shopUI;
    private bool isShopOpen = false;

    void Start()
    {
        shopUI.SetActive(false);
    }

    public void OnToggleShop()
    {
        isShopOpen = !isShopOpen;
        shopUI.SetActive(isShopOpen);

        if (isShopOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
