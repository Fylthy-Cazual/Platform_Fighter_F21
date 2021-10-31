using System.Collections.Generic;

public interface IManager
{
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
    public void Initialize();
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public void Update();
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    /** The Public Static Readonly Set Of IManagers */
    public class Set
    {
        #region STATIC MEMBERS
        public static readonly HashSet<IManager> Managers = new HashSet<IManager>();
        #endregion
    }
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