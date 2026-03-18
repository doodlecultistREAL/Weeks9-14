using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedScript : MonoBehaviour
{


    public Transform player1;
    public Transform player2;
  
    public Transform cursor;
    public Button attackButton1;
    public Button attackButton2;

    AnimationCurve playerAnim;

    float minTime;
    float maxTime = 2;
    float time;
    int playerNum = 1;

    Vector3 cursorRotate;
    Coroutine BattleHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    IEnumerator onAttack()
    {

        time = 0;

        if (playerNum == 1)
        {
            attackButton2.interactable = false;
            while (time < maxTime)
            {

                attackButton1.interactable = false;       
                time += Time.deltaTime;
                player1.transform.localScale = Vector3.one * time;
                yield return null;
            }
            playerNum = 2;
            attackButton2.interactable = true;
           
        }
        if (playerNum == 2)
        {
            attackButton1.interactable = false;
            while (time < maxTime)
            {

                attackButton2.interactable = false;
                time += Time.deltaTime;
                player2.transform.localScale = Vector3.one * time;
                yield return null;
            }
            playerNum = 1;
            attackButton1.interactable = true;

        }
    }

    public void StartBattleHandler()
    {

       BattleHandler = StartCoroutine(onAttack());


    }
    // Update is called once per frame
    void FixedUpdate()
    { 
        

    }
}
