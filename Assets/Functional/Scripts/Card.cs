using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSelected;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {            
        
        if (!isSelected)
        {
            isSelected = true;
            if (gameManager.setTagSelectedCards(tag))
            {
                restarCards();   
            }
        }        
        
    }
    void restarCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].isSelected = false;
        }
    }
}
