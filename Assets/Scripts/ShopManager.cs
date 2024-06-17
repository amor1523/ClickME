using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject purchasePanel;
    public GameObject errorBox;
    public TextMeshProUGUI purchaseText;

    private RewardManager rewardManager;

    private string selectedItem;
    private int selectedPrice;
    private GameObject selectedButton; // 구매 성공 시 비활성화할 버튼 참조

    void Start()
    {
        purchasePanel.SetActive(false);
        errorBox.SetActive(false);

        rewardManager = FindObjectOfType<RewardManager>();
    }

    public void OnPurchaseClick(string itemName, int price, GameObject button)
    {
        selectedItem = itemName;
        selectedPrice = price;
        selectedButton = button;
        purchaseText.text = $"Want to purchase {itemName} for {price} EA?";
        purchasePanel.SetActive(true);
    }

    public void OnFruit1Purchase(GameObject button) => OnPurchaseClick("Apple", 100, button);
    public void OnFruit2Purchase(GameObject button) => OnPurchaseClick("Banana", 100, button);
    public void OnFruit3Purchase(GameObject button) => OnPurchaseClick("Cherry", 100, button);
    public void OnFriend1Purchase(GameObject button) => OnPurchaseClick("Apple", 500, button);
    public void OnFriend2Purchase(GameObject button) => OnPurchaseClick("Banana", 500, button);
    public void OnFriend3Purchase(GameObject button) => OnPurchaseClick("Cherry", 500, button);


    public void OnYesButtonClick()
    {
        bool purchaseSuccess = false;
        switch (selectedItem)
        {
            case "Apple":
                purchaseSuccess = rewardManager.UseApples(selectedPrice);
                break;
            case "Banana":
                purchaseSuccess = rewardManager.UseBananas(selectedPrice);
                break;
            case "Cherry":
                purchaseSuccess = rewardManager.UseCherries(selectedPrice);
                break;
        }

        if (purchaseSuccess)
        {
            selectedButton.SetActive(false);
        }
        else
        {
            errorBox.SetActive(true);
        }
        purchasePanel.SetActive(false);
    }

    public void OnNoButtonClick()
    {
        purchasePanel.SetActive(false);
    }

    public void OnConfirmButtonClick()
    {
        errorBox.SetActive(false);
    }
}