using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// following  https://www.youtube.com/watch?v=PqkBuU08MOQ
// Jack Glenn-Kennedy   T00063898,  April 1 2025
// gamemanager script 
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            }
        }
    }


}




