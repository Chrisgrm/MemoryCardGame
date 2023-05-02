using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private List<Card> cards;
    private Card card1,card2;  
    private int tryCounter = 0;
    private int starCounter = 0;
    private int failedMatchCounter = 0;    
    public bool cardsSelected = false;
    private bool cardsCompared = false;


    //private UIManager uIManager;
    void Start()
    {
        cards = FindObjectsOfType<Card>().ToList();
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
      
        if(cardsSelected && !cardsCompared)
        {
            CardComparer();            
        }else if(cardsSelected && cardsCompared)
        {
            if (card2.AnimationFinished())
            {
                cardsCompared = false;  
                card2.RestartAnimationsState();
                DeselectCards();
            }
        }
        if (starCounter == 4) {
            Victory();
            print("Victory");
        }        
    }

    void CardComparer()
    {
      
        if (card2.CompareTag(card1.tag))
        {      
            StartCoroutine(MatchAnimation());
        }
        else
        {
            StartCoroutine(BadMatchAnimation());            
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
            card2.SetSelectableCards(false);
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
        
        card2.SetSelectableCards(true);
        card1 = null;
        card2 = null;
        cardsSelected = false;
    }

    void MixCards() {
        
        cards[0].RestarTagsPositions();
        cards = FindObjectsOfType<Card>().ToList();
        for (int i=0; i < cards.Count; i++)
        {
            cards[i].RandomPosition();
        }
        
    }
    IEnumerator  BadMatchAnimation()
    {
        cardsCompared = true;
        failedMatchCounter += 1;
        yield return new WaitForSeconds(1);
        card1.StartBadMatchAnimation();
        card2.StartBadMatchAnimation();
        DeselectCards();
        cardsCompared = false;
    }

    IEnumerator MatchAnimation()
    {
        cardsCompared = true;
        starCounter += 1;
        yield return new WaitForSeconds(1);        
        card1.StartMatchAnimation();
        card2.StartMatchAnimation();

        
    }




}
