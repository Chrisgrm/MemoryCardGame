using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingCards : MonoBehaviour
{
    private GameObject target;
    //private Vector3 endPosition = new Vector3(10, 10, 10);
    private Vector3 startPosition;
    private float desiredDuration = 1f;
    private float elapsedTime;
    [SerializeField] AnimationCurve curve;
    public GameObject cardChild;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //card1.transform.position = Vector3.Lerp(card1.transform.position, target.transform.position, t);
        startPosition = transform.position;
        target = GameObject.Find("Target");
        anim = cardChild.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(disappearCard());
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("turn1Param", true);
            StartCoroutine(falsifyParam1());
            //anim.SetBool("turn1Param", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("turn2Param", true);
            StartCoroutine(falsifyParam2());
        }
    }

    // /**
    IEnumerator disappearCard()
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
            con++;
        }
    }
    // */

    IEnumerator falsifyParam1()
    {
        yield return new WaitForSeconds(0.51f);
        anim.SetBool("turn1Param", false);
    }
        IEnumerator falsifyParam2()
    {
        yield return new WaitForSeconds(1.21f);
        anim.SetBool("turn2Param", false);
    }
}
