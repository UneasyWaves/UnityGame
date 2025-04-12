using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
// following  https://www.youtube.com/watch?v=PqkBuU08MOQ
// Jack Glenn-Kennedy   T00063898,  April 1 2025
// gamemanager script 
//Works!!
public class SimonSays : MonoBehaviour
{
   public SpriteRenderer[] colours;
   private int colourSelect;
   public float stayLit;
   private float stayLitCounter;
   public float waitBetweenLights;
   private float waitBetweenCounter;
   private bool shouldBeLit;
   private bool shouldBeDark;
   public List<int> activeSequence;
   private int positionInSequence;
   private bool gameActive = false;
   private int inputInSequence;
   public TMP_Text levelLost;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelLost.color = new Color(levelLost.color.r, levelLost.color.g, levelLost.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;

            if(stayLitCounter < 0)
            {
                colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, .5f);
                shouldBeLit = false;
                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;
                positionInSequence++;
            }
        }

        if(shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;
            if(positionInSequence >= activeSequence.Count)
            {
                shouldBeDark = false;
                gameActive = true;
            }
            else{
                if(waitBetweenCounter < 0)
                {
                    
                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }
        }
        
    }

    public void StartGame()
    {
        levelLost.color = new Color(levelLost.color.r, levelLost.color.g, levelLost.color.b, 0f);
        activeSequence.Clear();
        inputInSequence = 0;
        positionInSequence = 0;
        
        colourSelect = Random.Range(0, colours.Length);

        activeSequence.Add(colourSelect);

        colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);

        stayLitCounter = stayLit;
        shouldBeLit = true;
    }

    public void ColourPressed(int whichButton)
    {
       if(gameActive)
       {
       
            if(activeSequence[inputInSequence] == whichButton)
            {
              // level 'you lost' text
               levelLost.color = new Color(levelLost.color.r, levelLost.color.g, levelLost.color.b, 0f);
               
                Debug.Log("Correct");
                inputInSequence++;
                if(inputInSequence >= activeSequence.Count)
                {
                   positionInSequence =0;
                   inputInSequence = 0;
                   
                    colourSelect = Random.Range(0, colours.Length);

                    activeSequence.Add(colourSelect);

                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    gameActive = false;
                }
            }
            else
            {
                Debug.Log("Wrong");
                gameActive = false;
                // put time loss or something here? 
                // and some indication that the game was lost - wrong input
                levelLost.color = new Color(levelLost.color.r, levelLost.color.g, levelLost.color.b, 1f);

            }
        }
    }


}







