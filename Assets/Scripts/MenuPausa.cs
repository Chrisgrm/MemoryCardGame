using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    private Button pausabutton;
    public GameObject panelPausa;
    public GameObject canvasPrincipal;

    void Start()
    {

    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        panelPausa.SetActive(true);
    }

    public void back()
    {
        panelPausa.SetActive(false);
    }

    public void MenuPrincipal()
    {
        titleScreen.SetActive(true);
        canvasPrincipal.SetActive(false);
    }
}
