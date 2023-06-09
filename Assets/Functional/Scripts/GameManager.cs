using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private List<Card> cards;
    private Card card1,card2;  
    private int tryCounter = 0;
    public int starCounter = 0;
    private int failedMatchCounter = 0;    
    public bool cardsSelected = false;
    private bool cardsCompared = false;
    private UIManager uIManager;
    private bool victory;
    private AudioManager audioManager;
    


    //private UIManager uIManager;
    void Start()
    {
        cards = FindObjectsOfType<Card>().ToList();
        uIManager=GameObject.Find("CanvasPrincipal").GetComponent<UIManager>();
        audioManager = FindObjectOfType<AudioManager>();
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
        if (starCounter == 4 && !victory) {
            Victory();      
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
        StartCoroutine(ActivePanelVictoria());
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        victory = true;

    }

    public int getFailedMatchCounter()
    {

        return failedMatchCounter;
    }

    public void DeselectCards()
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
    public int getTryNumber()
    {
        return tryCounter;
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
        yield return new WaitForSeconds(1);
        card1.StartMatchAnimation();
        card2.StartMatchAnimation();
        starCounter += 1;
        card1.audioSource.Play();
        card2.audioSource.Play();


    }

    IEnumerator ActivePanelVictoria()
    {
        yield return new WaitForSeconds(1.5f);
        uIManager.ActivateVictoryPanel();
        audioManager.PlaySimpleSound(audioManager.victorySound);
    }






}
