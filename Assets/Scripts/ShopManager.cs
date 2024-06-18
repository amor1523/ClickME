using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject purchasePanel;
    public GameObject errorBox;
    public TextMeshProUGUI purchaseText;

    private RewardManager rewardManager;
    private ClickManager clickManager;
    private GameManager gameManager;

    private string selectedItem;
    private int selectedPrice;
    private GameObject selectedButton; // 구매 성공 시 비활성화할 버튼 참조

    void Start()
    {
        purchasePanel.SetActive(false);
        errorBox.SetActive(false);

        rewardManager = FindObjectOfType<RewardManager>();
        clickManager = FindObjectOfType<ClickManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnPurchaseClick(string itemName, int price, Object button)
    {
        selectedItem = itemName;
        selectedPrice = price;

        //Unity에서 이벤트 함수의 매개변수로 전달되는 객체는 Object 타입이다.
        //하지만 우리가 실제로 필요로 하는 것은 GameObject 타입이므로, 이 객체를 GameObject로 변환(캐스팅)해야 한다.
        //as 키워드를 사용하여 안전하게 캐스팅할 수 있습니다.
        //Unity의 이벤트 시스템에서는 매개변수로 전달되는 객체가 UnityEngine.Object 타입이기 때문에,
        //이를 실제 사용할 수 있는 GameObject 타입으로 변환해줘야 한다.
        //이렇게 변환하지 않으면 GameObject의 메서드나 속성을 사용할 수 없다.
        selectedButton = button as GameObject; // Object 타입을 GameObject로 캐스팅

        purchaseText.text = $"Want to purchase {itemName} for {price} EA?";
        purchasePanel.SetActive(true);
        Debug.Log($"OnPurchaseClick called with item: {itemName}, price: {price}");
    }

    public void OnFruit1Purchase(Object button) => OnPurchaseClick("Apple", 100, button);
    public void OnFruit2Purchase(Object button) => OnPurchaseClick("Banana", 100, button);
    public void OnFruit3Purchase(Object button) => OnPurchaseClick("Cherry", 100, button);
    public void OnFriend1Purchase(Object button) => OnPurchaseClick("Friend1", 500, button); // TroubleShooting - 잘못된 매개변수를 전달하여 Friend가 Initiate되지 못함.
    public void OnFriend2Purchase(Object button) => OnPurchaseClick("Friend2", 500, button);
    public void OnFriend3Purchase(Object button) => OnPurchaseClick("Friend3", 500, button);

    // BigInteger 기능을 위한 생산량 대폭 증가 구매리스트 등록
    public void OnFruit4Purchase(Object button) => OnPurchaseClick("Fruit4", 1000, button);
    public void OnFruit5Purchase(Object button) => OnPurchaseClick("Fruit5", 1000, button);
    public void OnFruit6Purchase(Object button) => OnPurchaseClick("Fruit6", 1000, button);

    public void OnYesButtonClick()
    {
        bool purchaseSuccess = false;
        Debug.Log($"OnYesButtonClick called with selectedItem: {selectedItem}, selectedPrice: {selectedPrice}");
        switch (selectedItem)
        {
            case "Apple":
                purchaseSuccess = rewardManager.UseApples(selectedPrice);
                if (purchaseSuccess) clickManager.IncreaseClickDamage(5);
                break;

            case "Banana":
                purchaseSuccess = rewardManager.UseBananas(selectedPrice);
                if (purchaseSuccess) clickManager.IncreaseClickDamage(5);
                break;

            case "Cherry":
                purchaseSuccess = rewardManager.UseCherries(selectedPrice);
                if (purchaseSuccess) clickManager.IncreaseClickDamage(5);
                break;

            case "Friend1":
                purchaseSuccess = rewardManager.UseApples(selectedPrice);
                if (purchaseSuccess) gameManager.SpawnFriend(1);
                break;

            case "Friend2":
                purchaseSuccess = rewardManager.UseBananas(selectedPrice);
                if (purchaseSuccess) gameManager.SpawnFriend(2);
                break;

            case "Friend3":
                purchaseSuccess = rewardManager.UseCherries(selectedPrice);
                if (purchaseSuccess) gameManager.SpawnFriend(3);
                break;

            case "Fruit4":
                purchaseSuccess = rewardManager.UseApples(selectedPrice);
                if (purchaseSuccess) gameManager.IncreaseBaseRewardAmount(100000);
                break;

            case "Fruit5":
                purchaseSuccess = rewardManager.UseBananas(selectedPrice);
                if (purchaseSuccess) gameManager.IncreaseBaseRewardAmount(100000);
                break;

            case "Fruit6":
                purchaseSuccess = rewardManager.UseCherries(selectedPrice);
                if (purchaseSuccess) gameManager.IncreaseBaseRewardAmount(100000);
                break;

            default:
                Debug.LogWarning($"Unknown item: {selectedItem}");
                break;
        }

        if (purchaseSuccess)
        {
            selectedButton.SetActive(false);
        }
        else
        {
            errorBox.SetActive(true);
            Debug.Log("Purchase failed: Not enough resources");
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