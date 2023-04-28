using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string tagCard1="1";
    private string tagCard2="2";
    private int tryCounter = 0;
    private int starCounter = 0;
    //private UIManager uIManager;
    void Start()
    {
       // uIManager=GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tagCard1!= "1" && tagCard2 != "2")
        {
            CardComparer();
        }
        if (starCounter == 4) {
            Victory();
            print("Victory");
        }        
    }

    void CardComparer()
    {
      
        if (tagCard1 == tagCard2)
        {
            starCounter += 1;
            print("match");            
        }
        else
        {
            print("failedMatch");            
        }
        tagCard1 = "1";
        tagCard2 = "2";
    }
    public bool setTagSelectedCards(string tag)
    {
        bool cardsSelected=false;
        if (tagCard1 == "1")
        {
            tagCard1 = tag;
        }
        else if (tagCard2 == "2")
        {            
            tagCard2 = tag;
            cardsSelected = true;
            tryCounter += 1;
        }
        return cardsSelected;
    }
    private void Victory()
    {
        //uIManager.ActivateVictoryPanel();
    }

}
