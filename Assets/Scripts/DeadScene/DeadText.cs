using UnityEngine;
using TMPro;
using System.Collections;
public class DeadText : MonoBehaviour
{
    public TextMeshProUGUI deadText;
    public float duration = 1f;
    public AudioSource soundDead, fadeButton;
    public GameObject buttonBack;

    void Start()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(ButtonBack());

    }

    public IEnumerator FadeIn()
    {
        Color color = deadText.color;
        color.a = 0f;
        deadText.color = color;

        float timer = 0f;
        soundDead.Play();

        while (timer < duration)
        {
            deadText.fontSize = Mathf.Lerp(10f, 140f, timer / duration);
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / duration);
            deadText.color = color;
            yield return null;
        }
    }
    public IEnumerator ButtonBack()
    {
        yield return new WaitForSeconds(4f);
        fadeButton.Play();
        buttonBack.SetActive(true);
    }
}