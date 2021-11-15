using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : UIElement
{
    // ---------------------------------------------- STATIC
    
    // ---------------------------------------------- SERIALIZABLE
    public Text text;
    public float enterTime;
    public float holdTime;
    public float exitTime;
        
    // ---------------------------------------------- PROPERTIES
    public override bool Blocking() => false;
    private IEnumerator moveText;

    // ---------------------------------------------- METHODS AND ROUTINES
    private IEnumerator MoveText()
    {
        Vector2 start = new Vector2(-Screen.width, Screen.height);
        Vector2 center = new Vector2(Screen.width / 2, Screen.height);
        Vector2 end = new Vector2(2 * Screen.width, Screen.height);
        float currTime = 0.0f;
        while (currTime < enterTime)
        {
            float factor = 1.0f - Mathf.Pow(1 - currTime / enterTime, 2);
            text.transform.position = Vector2.Lerp(start, center, factor);
            currTime += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(holdTime);
        
        currTime = 0.0f;
        while (currTime < exitTime)
        {
            float factor = Mathf.Pow(currTime / enterTime, 2);
            text.transform.position = Vector2.Lerp(center, end, factor);
            currTime += Time.unscaledDeltaTime;
            yield return null;
        }
        
        UIManager.Instance.PopUI(this);
    }

    // ---------------------------------------------- UNITY EVENT FUNCTIONS
    public override void Awake()
    {
        base.Awake();
        transform.position = new Vector2(-Screen.width, Screen.height);
        moveText = MoveText();
    }

    public override void BlockedUpdate()
    {
        moveText.MoveNext();
    }

    // ---------------------------------------------- CASTING
        
    // ---------------------------------------------- HELPER CLASSES

}

// ---------------------------------------------- STATIC
    
// ---------------------------------------------- SERIALIZABLE
    
// ---------------------------------------------- PROPERTIES

// ---------------------------------------------- METHODS AND ROUTINES
    
// ---------------------------------------------- UNITY EVENT FUNCTIONS
    
// ---------------------------------------------- CASTING
    
// ---------------------------------------------- HELPER CLASSES