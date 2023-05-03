using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelVictoria;
    public GameObject panelPausa;
    private Button botonPausa;
    public TMP_Text movimientosContador;
    void Start()
    {
        botonPausa = GetComponent<Button>();
    }

    
    void Update()
    {
        
    }

    public void BotonPausaFunc()
    {
        print("funciono");
        botonPausa.gameObject.SetActive(false);
        panelPausa.SetActive(true);
    }
}
