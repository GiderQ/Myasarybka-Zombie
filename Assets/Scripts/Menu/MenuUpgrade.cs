using UnityEngine;
using UnityEngine.UI;

public class MenuUpgrade : MonoBehaviour
{
    public Slider slider;

    public void UpgradeHp()
    {
        if (PlayerData.money >= 10)
        {
            PlayerData.money -= 10;
            slider.value++;
            PlayerData.upgradeHp++;
        }
    }
    public void UpgradeAtk()
    {
        if (PlayerData.money >= 10)
        {
            PlayerData.money -= 10;
            slider.value++;
            PlayerData.upgradeAtk++;
        }
    }
    public void UpgradeAtkSpeed()
    {
        if (PlayerData.money >= 10)
        {
            PlayerData.money -= 10;
            slider.value++;
            PlayerData.upgradeAtkSpeed++;
        }
    }
        public void UpgradeSpeed()
    {
        if (PlayerData.money >= 10)
        {
            PlayerData.money -= 10;
            slider.value++;
            PlayerData.upgradeSpeed++;
        }
    }

}
