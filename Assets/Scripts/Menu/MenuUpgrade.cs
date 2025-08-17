using UnityEngine.UI;
using UnityEngine;

public class MenuUpgrade : MonoBehaviour
{
    public Slider slider;

    public void Upgrade()
    {
        if (PlayerData.money > 10)
        {
            PlayerData.money -= 10;
            slider.value++;
        }
    }

    void ViewMoney()
    {

    }
}
