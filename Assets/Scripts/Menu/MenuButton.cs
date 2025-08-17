using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject upgradeMenu;
    public void StartGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartButton()
    {
        StartCoroutine(StartWithDelay());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(3f);

        upgradeMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
