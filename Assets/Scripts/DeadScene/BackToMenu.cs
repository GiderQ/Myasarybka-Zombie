using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToMenu : MonoBehaviour
{

    public void ButtonClick()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }


}
