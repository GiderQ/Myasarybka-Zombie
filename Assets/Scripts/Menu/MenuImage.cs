using UnityEngine;
using UnityEngine.UI;


public class MenuImage : MonoBehaviour
{
    public Sprite calm, start, setting, quit, dead;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Calm()
    {
        image.sprite = calm;
    }

    public void StartButton()
    {
        image.sprite = start;
    }
    public void SettingButton()
    {
        image.sprite = setting;

    }
    public void QuitButton()
    {
        image.sprite = quit;

    }
    public void DeadButton()
    {
        image.sprite = dead;

    }

}
