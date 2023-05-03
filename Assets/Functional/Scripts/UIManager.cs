using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject panelVictoria;
    public GameObject panelPausa;
    public Button botonPausa;
    public TMP_Text movimientosContador;
    private GameManager gameManager;
    public TMP_Text movimientosContadorVictoria;
    public Button volverAlMenu;
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      
    }

    
    void Update()
    {
        ActualizarMovimientos();
        
    }

    public void BotonPausaFunc()
    {              
        panelPausa.SetActive(true);
    }
    public void BotonVolverAlMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void ActualizarMovimientos()
    {
        movimientosContador.text = gameManager.getTryNumber().ToString();
    }
    public void ActivateVictoryPanel()
    {
        
        panelVictoria.SetActive(true);
        movimientosContadorVictoria.text = movimientosContador.text;
    }
}
