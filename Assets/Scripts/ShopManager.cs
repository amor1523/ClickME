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
    private GameObject selectedButton; // ���� ���� �� ��Ȱ��ȭ�� ��ư ����

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

        //Unity���� �̺�Ʈ �Լ��� �Ű������� ���޵Ǵ� ��ü�� Object Ÿ���̴�.
        //������ �츮�� ������ �ʿ�� �ϴ� ���� GameObject Ÿ���̹Ƿ�, �� ��ü�� GameObject�� ��ȯ(ĳ����)�ؾ� �Ѵ�.
        //as Ű���带 ����Ͽ� �����ϰ� ĳ������ �� �ֽ��ϴ�.
        //Unity�� �̺�Ʈ �ý��ۿ����� �Ű������� ���޵Ǵ� ��ü�� UnityEngine.Object Ÿ���̱� ������,
        //�̸� ���� ����� �� �ִ� GameObject Ÿ������ ��ȯ����� �Ѵ�.
        //�̷��� ��ȯ���� ������ GameObject�� �޼��峪 �Ӽ��� ����� �� ����.
        selectedButton = button as GameObject; // Object Ÿ���� GameObject�� ĳ����

        purchaseText.text = $"Want to purchase {itemName} for {price} EA?";
        purchasePanel.SetActive(true);
        Debug.Log($"OnPurchaseClick called with item: {itemName}, price: {price}");
    }

    public void OnFruit1Purchase(Object button) => OnPurchaseClick("Apple", 100, button);
    public void OnFruit2Purchase(Object button) => OnPurchaseClick("Banana", 100, button);
    public void OnFruit3Purchase(Object button) => OnPurchaseClick("Cherry", 100, button);
    public void OnFriend1Purchase(Object button) => OnPurchaseClick("Friend1", 500, button); // TroubleShooting - �߸��� �Ű������� �����Ͽ� Friend�� Initiate���� ����.
    public void OnFriend2Purchase(Object button) => OnPurchaseClick("Friend2", 500, button);
    public void OnFriend3Purchase(Object button) => OnPurchaseClick("Friend3", 500, button);

    // BigInteger ����� ���� ���귮 ���� ���� ���Ÿ���Ʈ ���
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