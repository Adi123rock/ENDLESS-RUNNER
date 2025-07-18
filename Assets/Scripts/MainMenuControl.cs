using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public static int sceneNum = 1;
    [SerializeField] GameObject MMfadeOut;
    [SerializeField] GameObject bounceText;
    [SerializeField] GameObject bigButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControls;
    [SerializeField] AudioSource buttonSelect;
    public static bool hasClicked;
    [SerializeField] GameObject fadeIn;

    void Start()
    {
        StartCoroutine(fadeInTurnOff());
        if (hasClicked)
        {
            mainCam.SetActive(true);
            animCam.SetActive(false);
            menuControls.SetActive(true);
            bounceText.SetActive(false);
            bigButton.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void ChangeMap()
    {
        SceneManager.LoadScene(2);
    }
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
        buttonSelect.Play();
        MMfadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneNum);
    }

    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("AnimMenuCam");
        bounceText.SetActive(false);
        bigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);
        hasClicked = true;
    }

    IEnumerator fadeInTurnOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}
