public class PauseMenu : UIElement
{
    
    // ---------------------------------------------- STATIC
        
    // ---------------------------------------------- SERIALIZABLE

    // ---------------------------------------------- PROPERTIES
    public override bool Blocking() => true;

    // ---------------------------------------------- METHODS AND ROUTINES
    public void Return()
    {
        UIManager.Instance.PopUI(this);
    }
    
    public void MainMenu()
    {
        UIManager.Instance.MainMenu();
    }
    
    // ---------------------------------------------- UNITY EVENT FUNCTIONS
    public override void BlockedUpdate() { }

    // ---------------------------------------------- CASTING

    // ---------------------------------------------- HELPER CLASSES
}