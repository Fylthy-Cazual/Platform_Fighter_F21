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
    public int mapWidth = 35;
    public int mapHeight = 25;
    public bool testMode = false;
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
        ManagerSet.Managers.UnionWith(ProductionLoadedManagers);
        foreach (IManager manager in ManagerSet.Managers)
        {
            manager.Initialize();
        }
        GameplayManager.Instance.SetMapBounds(mapWidth, mapHeight);
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
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        foreach (IManager manager in ManagerSet.Managers)
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