using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSelected;
    private GameManager gameManager;
    private GameObject[] unocupedPositionsReferences;
    private int failedMatchCounter;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        RandomPosition();        
    }

    // Update is called once per frame
    void Update()
    {
        if (failedMatchCounter > 3)
        {
            print("cambiooo");
            RestarTagsPositions();
            RandomPosition();
            failedMatchCounter = 0;
        }
    }

    private void OnMouseDown()
    {            
        
        if (!isSelected)
        {
            isSelected = true;
            if (gameManager.setSelectedCards(this))
            {                
                failedMatchCounter= gameManager.getFailedMatchCounter();
                RestarCards();  
                
            }
        }        
        
    }
    void RestarCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].isSelected = false;
        }
    }

    //metodos para manejar las posiciones de las cartas
    public void RandomPosition()
    {
        List<GameObject> unocupedPositionsReferencesList;
        unocupedPositionsReferences = GameObject.FindGameObjectsWithTag ("Position");
        unocupedPositionsReferencesList = unocupedPositionsReferences.ToList();
        int randomIndex = Random.Range(0, unocupedPositionsReferencesList.Count);        
        transform.position = unocupedPositionsReferencesList[randomIndex].transform.position;
        unocupedPositionsReferencesList[randomIndex].tag = "OcupedPosition";
    }
    public void RestarTagsPositions()
    {
        GameObject[] ocupedPositions = GameObject.FindGameObjectsWithTag("OcupedPosition");
        for (int i = 0; i < ocupedPositions.Length; i++)
        {
            ocupedPositions[i].tag = "Position";
        }

    }
}
