using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public Animator pauseIconAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                pauseMenu.SetActive(isPaused);
                pauseIconAnimator.SetTrigger("ScaleDown");
            }
            else if (isPaused == true)
            {
                pauseIconAnimator.SetTrigger("ScaleUp");
                StartCoroutine(WaitForAnimationToEnd("ScaleUp"));
                isPaused = false;
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator WaitForAnimationToEnd(string animationName)
    {
        yield return new WaitForSeconds(0.2f); // Wait for 20ms

        while (pauseIconAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }

        pauseMenu.SetActive(isPaused);
    }
}


// to do: make the scaledown animation work lmfao
