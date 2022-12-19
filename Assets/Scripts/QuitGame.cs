using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime;
    private bool isQuitting;
    private bool isFading;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isQuitting && !isFading)
            {
                StartCoroutine(FadeCoroutine());
            }
        }
    }

    IEnumerator FadeCoroutine()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        float elapsedTime = 0f;
        while (Input.GetKey(KeyCode.Escape) && elapsedTime < fadeTime)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            fadeImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (elapsedTime >= fadeTime)
        {
            StartCoroutine(QuitGameCoroutine());
        }
        else
        {
            // Store the current alpha value of the fade image
            float alpha = fadeImage.color.a;
            elapsedTime = 0f;
            // Use a shorter fade time for the reverse fade
            float reverseFadeTime = fadeTime / 1.5f;
            while (!Input.GetKey(KeyCode.Escape) && elapsedTime < reverseFadeTime)
            {
                // Use the stored alpha value as the starting point for the reverse fade
                color.a = Mathf.Lerp(alpha, 0f, elapsedTime / reverseFadeTime);
                fadeImage.color = color;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            fadeImage.gameObject.SetActive(false);
            isFading = false;
        }
    }

    IEnumerator QuitGameCoroutine()
    {
        isQuitting = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
        Debug.Log("Quit!");
    }
}
