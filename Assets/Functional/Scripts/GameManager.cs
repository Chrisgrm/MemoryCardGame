using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Card[] cards;
    private Card card1,card2;  
    private int tryCounter = 0;
    private int starCounter = 0;
    private int failedMatchCounter = 0;    
    private bool cardsSelected = false;

    //private UIManager uIManager;
    void Start()
    {
        cards = FindObjectsOfType<Card>();
       // uIManager=GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (failedMatchCounter >= 3)
        {
            MixCards();
            failedMatchCounter = 0;
            
        }
      
        if(cardsSelected)
        {
            CardComparer();
            DeselectCards();
            
        }
        if (starCounter == 4) {
            Victory();
            print("Victory");
        }        
    }

    void CardComparer()
    {
      
        if (card1.tag == card2.tag)
        {
            starCounter += 1;
            print("match");            
        }
        else
        {
            failedMatchCounter += 1;
            print("failedMatch");            
        }

    }
    public bool setSelectedCards(Card card)
    {          
        if (card1==(null))
        {
            card1 = card;
        }
        else if (card2==(null))
        {
            card2 = card;
            cardsSelected = true;
            tryCounter += 1;
        }
        return cardsSelected;
    }
    private void Victory()
    {
        //uIManager.ActivateVictoryPanel();
    }

    public int getFailedMatchCounter()
    {
        return failedMatchCounter;
    }

    void DeselectCards()
    {
        card1 = null;
        card2 = null;
        cardsSelected = false;
    }

    void MixCards() {
        cards[0].RestarTagsPositions();
        for(int i=0; i < cards.Length; i++)
        {
            cards[i].RandomPosition();
        }
        
    }




}
