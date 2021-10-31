using UnityEngine;

public abstract class ManagerSO : ScriptableObject, IManager
{
    
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion
    
    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public bool playModeAutomatedSetup = true;
    #endregion
    
    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    #endregion
    
    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion
    
    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    public abstract void Initialize();
    #endregion
    
    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    #endregion
    
    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public abstract void Update();
    #region (automated_imanager_setup)
    private void OnEnable()
    {
        if (playModeAutomatedSetup)
        {
            ManagerSet.Managers.Add(this);
        }
    }
    private void OnDisable()
    {
        if (playModeAutomatedSetup)
        {
            ManagerSet.Managers.Remove(this);
        }
    }
    #endregion
    #endregion
    
    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion
    
    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion

}

public abstract class ManagerSO<T> : ManagerSO where T : ManagerSO
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    [ReadOnly] public static T Instance;
    #endregion
}