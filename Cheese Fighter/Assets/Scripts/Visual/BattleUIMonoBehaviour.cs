using UnityEngine;

public class BattleUIMonoBehavior : MonoBehaviour
{
    
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public RectTransform rectTransform;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    private static readonly Rect BaseRect = new Rect(20, 20, 7000, 5000);
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        string health = "";
        foreach (Rat rat in GameplayManager.Instance.allPlayers) {
            health += rat.name + ": " + rat.hp + " ";
        }
        GUI.Label(rectTransform != null ? rectTransform.rect : BaseRect, health);
    }
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
    
}