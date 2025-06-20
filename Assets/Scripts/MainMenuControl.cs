using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject bounceText;
    [SerializeField] GameObject BigButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControls;

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }
    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        SceneManager.LoadScene(1);
    }
    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("AnimMenuCam");
        bounceText.SetActive(false);
        BigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);
    }
}
