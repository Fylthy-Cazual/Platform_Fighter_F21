using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UIElement
{
    
    // ---------------------------------------------- STATIC
        
    // ---------------------------------------------- SERIALIZABLE
    public string NewGameScene = "Placeholder";

    // ---------------------------------------------- PROPERTIES
    public override bool Blocking() => true;

    // ---------------------------------------------- METHODS AND ROUTINES
    public void Return()
    {
        UIManager.Instance.PopUI(this);
    }
    
    public void NewGame()
    {
        UIManager.Instance.PopUI(this);
        SceneManager.LoadScene(NewGameScene);
    }

    public void Quit()
    {
        UIManager.Instance.PopUI(this);
        Application.Quit();
    }

    // ---------------------------------------------- UNITY EVENT FUNCTIONS
    public override void BlockedUpdate() { }

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