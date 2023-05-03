using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public GameObject creditsScreen;
    public GameObject menuInicio;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        menuInicio.SetActive(false);
    }

    public void Credits()
    {
        creditsScreen.SetActive(true);
        menuInicio.SetActive(false);
    }

    public void creditsBack()
    {
        creditsScreen.SetActive(false);
        menuInicio.SetActive(true);
    }
}
