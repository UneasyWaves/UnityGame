// following https://www.youtube.com/watch?v=OKWNXsdFqKU
// and using https://www.youtube.com/watch?v=x9IFMcwqkPY
// to edit to 00:00 visual format
// Jack Glenn-Kennedy  March 24, 2025

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CountdownAddMinusTime : MonoBehaviour
{
    
    public bool timeIsRunning = true;
    public float timeLeft;
    public TMP_Text countdown;
     /// <summary>
     /// maybe have tutorial info start here, get tmpro text to show up when it starts then fade when time 
     // has gone down 5 seconds/10 seconds etc
     /// 
     /// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeIsRunning)
        {
            if (timeLeft>= 0)
            {
                timeLeft -= Time.deltaTime;
                DisplayTime(timeLeft);
            }
        }
    }



    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        countdown.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("I hit "+other.gameObject.name + other.gameObject.name.CompareTo("MinusTime"));
        if (other.gameObject.name.CompareTo("AddTime")==0)   // enter object to collide withs name*** like the hourgalss sprite etc - do this but minus time for objects that take away time
        {
      
            print("add time "+other.gameObject.name);
            print("the time before is "+timeLeft);
            timeLeft += 55;
            print("the time after is "+timeLeft);

            Destroy(other.gameObject);
        }

       if (other.gameObject.name.CompareTo("MinusTime")==0)//||other.gameObject.name.CompareTo("MinusTime2")==0)   // enter object to collide withs name*** like the hourgalss sprite etc - do this but minus time for objects that take away time
        {
           
           print("minus time "+ other.gameObject.name);
            print("the time before is: " + timeLeft);
            timeLeft -= 115;
            if (timeLeft<0) timeLeft = 0;

            print("the time after is: " + timeLeft);

            Destroy(other.gameObject);
        }

    }

   


}
