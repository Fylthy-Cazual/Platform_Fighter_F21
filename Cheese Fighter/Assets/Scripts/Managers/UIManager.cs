
using UnityEngine;

[CreateAssetMenu(fileName = "UIManager", menuName = "Managers/UIManager")]
public class UIManager : ManagerSO<UIManager>
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public GameObject BattleUI;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    private GUIStyle hpStyle = new GUIStyle();
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION

    public override void Initialize()
    {
        hpStyle.fontSize = 80;
        UnityManager.Instance.InstantiatePrefab(BattleUI);
    }
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public override void Update() { }
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
}

// -------------------------------------------------------------------------- STATIC MEMBERS
#region STATIC MEMBERS
#endregion
    
// -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
#region SERIALIZABLE INSPECTOR
#endregion
    
// -------------------------------------------------------------------------- INSTANCE PROPERTIES
#region INSTANCE PROPERTIES
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
#endregion
    
// -------------------------------------------------------------------------- CASTING
#region CASTING
#endregion
    
// -------------------------------------------------------------------------- HELPER CLASSES
#region HELPER CLASSES
#endregion
