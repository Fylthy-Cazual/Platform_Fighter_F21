using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour, IManager
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    [ReadOnly] public static UnityManager Instance;
    #endregion
    
    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public ManagerSO[] ProductionLoadedManagers;
    #endregion
    
    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    private HashSet<IManager> Managers;
    #endregion
    
    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion
    
    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    public void Initialize()
    {
        Instance = this;
        IManager.Set.Managers.UnionWith(ProductionLoadedManagers);
        foreach (IManager manager in IManager.Set.Managers)
        {
            manager.Initialize();
        }
    }
    #endregion
    
    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    public GameObject InstantiatePrefab(GameObject prefab)
    {
        return Instantiate(prefab);
    }
    #endregion
    
    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public void Awake()
    {
        Initialize();
    }

    public void Update()
    {
        foreach (IManager manager in IManager.Set.Managers)
        {
            manager.Update();
        }
    }
    #endregion
    
    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion
    
    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
}