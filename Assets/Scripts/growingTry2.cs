using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class growingTry2 : MonoBehaviour
{
    
    public Transform tree;
    public Transform apple;
    float endingSize;

    Coroutine growAppleCoroutine;

    //doesn't work cause I was doing it to figure out coroutines!!
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;
    }



    //the only issue im having so far is when to yield a return.
    IEnumerator GrowTree()
    {

        Debug.Log("Asynchronous start");
        float time = 0;
        
        while (time < 1){

            Vector2.Lerp(tree.localScale, Vector2.one, time);
            time += Time.deltaTime;

        }
        yield return new WaitForSeconds(5);
        Debug.Log("Asynchronous stop");
        StopCoroutine(GrowTree());
     
    }

    IEnumerator GrowApple()
    {
        Debug.Log("start wait for time");
        StartCoroutine(GrowTree());
        yield return new WaitForSeconds(5);
        Debug.Log("stop");
        StopCoroutine(GrowApple());
    }


    public void StartTreeGrowing()
    {

        growAppleCoroutine = StartCoroutine(GrowApple());


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
