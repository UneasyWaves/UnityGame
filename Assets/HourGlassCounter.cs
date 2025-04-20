// Jack Glenn-Kennedy   T00063898  April 19, 2025
// hourglass counter on canvas
// https://stackoverflow.com/questions/64922749/unity-counting-collected-objects
// and other google searches to figure this out as well as countdownaddminustime script


using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class HourGlassCounter : MonoBehaviour
{
    public TMP_Text counterText;
    private int currentCount = 0;
    private int totalCount = 4;

    private void UpdateCounter()
    {
        counterText.text = $"{currentCount} / {totalCount}";
    }

    private void Start()
    {
        UpdateCounter();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.CompareTag("AddTime"))
        {
           Debug.Log("addtime detected!");
            if(currentCount < totalCount)
            {
                currentCount++;
                UpdateCounter();
            }
        }
    }

}


/*
[SerializeField]
    private int eggsLeft = 1;

    public bool collectedAll
    {
        get { return eggsLeft == 0; }
    }

    public void CollectEgg ( )
    {
        if ( eggsLeft > 0 ) eggsLeft--;
    }
}


public class Eggs : MonoBehaviour
{

    GameController gc;

    void Start ( )
    {
        gc = FindObjectOfType<GameController> ( );
        if ( !gc ) Debug.LogError ( "Could not find a GameController!" );
    }

    void OnMouseDown ( )
    {
        Destroy ( gameObject );
        gc.CollectEgg ( );
    }
}
*/
