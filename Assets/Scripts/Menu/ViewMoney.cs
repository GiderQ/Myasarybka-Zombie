using UnityEngine;
using TMPro;
public class ViewMoney : MonoBehaviour
{
    public TextMeshProUGUI money;
    void Update()
    {
        ViewMoneyFunc();
    }

    public void ViewMoneyFunc()
    {
        money.text = $"Money: {PlayerData.money}";
    }

}
