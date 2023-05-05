using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchingCards : MonoBehaviour
{
    private GameObject target;
    //private Vector3 endPosition = new Vector3(10, 10, 10);
    private Vector3 startPosition;
    private float desiredDuration = 1f;
    private float desiredMoveDuration = 2f;
    private float elapsedTime;
    [SerializeField] AnimationCurve curve;
    public GameObject cardChild;
    
    private Animator anim;
    public bool badMatchAnimationFinished;
    public bool matchAnimationFinished;
    public bool turnCardAnimationFinished;
    public bool movingCardsAnimation;
    Vector3 newPosition;


    void Start()
    {        
        startPosition = transform.position;
        target = GameObject.Find("Target");
        anim = cardChild.GetComponent<Animator>();       
    }


    void Update()
    {
        startPosition = transform.position;
    }


    public IEnumerator MatchingCardsAnimation()
    {
        while (elapsedTime < desiredDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, target.transform.position, curve.Evaluate(percentageComplete));

            yield return null;
        }

        int con = 0;
        if (elapsedTime >= desiredDuration && con == 0)
        {
            target.GetComponent<ParticlePlay>().PlayPart();
            gameObject.SetActive(false);
            matchAnimationFinished = true;
            con++;
        }
    }

    public IEnumerator TurnCardAnimation()
    {
        anim.SetBool("turn1Param", true);
        yield return new WaitForSeconds(0.51f);
        anim.SetBool("turn1Param", false);
        turnCardAnimationFinished = true;
    }
    public IEnumerator BadCardsAnimation()
    {
        anim.SetBool("turn2Param", true);
        yield return new WaitForSeconds(1.21f);
        anim.SetBool("turn2Param", false);
        badMatchAnimationFinished = true;
    }

    internal void SetNewPositions(GameObject gameObject)
    {
        newPosition = gameObject.transform.position;
    }

    public void RestartAnimationsState()
    {
        badMatchAnimationFinished = false;
        matchAnimationFinished = false;
        turnCardAnimationFinished = false;
    }

    public IEnumerator MovingCardsAnimation()
    {
        movingCardsAnimation = true;
        while (elapsedTime < desiredMoveDuration)
        {           
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredMoveDuration;
            transform.position = Vector3.Lerp(startPosition, newPosition, curve.Evaluate(percentageComplete));
            yield return null;
        }

        int con = 0;
        if (elapsedTime >= desiredMoveDuration && con == 0)
        {        
            elapsedTime = 0;
            movingCardsAnimation = false;
        }
    }
}
