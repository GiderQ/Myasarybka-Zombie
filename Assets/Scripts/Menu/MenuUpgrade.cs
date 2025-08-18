using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MenuUpgrade : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI money;

    private void Start()
    {
        ViewMoney();
    }
    public void Upgrade()
    {
        if (PlayerData.money >= 10)
        {
            PlayerData.money -= 10;
            slider.value++;
            Debug.Log("Upgrade++");
            ViewMoney();
        }
    }

    void ViewMoney()
    {
        if (PlayerData.money > 0)
        {
            money.text = $"Money: {PlayerData.money}";
        }
        else money.text = "Money: 0";
    }
    public void DebugMoney()
    {
        PlayerData.money += 10;
        ViewMoney();
    }

}
