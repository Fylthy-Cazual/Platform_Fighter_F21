using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CameraManager", menuName = "Managers/CameraManager")]
public class CameraManager : ManagerSO<CameraManager>
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    public static readonly float MIN_ORTHOGRAPHIC_SIZE = 4.0f;
    public static readonly float MAX_ORTHOGRAPHIC_SIZE = 12.0f;
    public static readonly float ORTHOGRAPHIC_SCALE = 1.0f;
    public static Vector3 DEFAULT_POSITION = new Vector3(0f, 0f, 0f);
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    [ReadOnly] public Camera camera;
    public bool fixedCam; //Is the camera dynamic or in a fixed position?
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    public override void Initialize()
    {
        Instance = this;
        camera = Camera.main;
        fixedCam= false;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    private void UpdateCameraPose()
    {
        Rat[] allPlayers = GameplayManager.Instance.allPlayers;
        Vector2 avgPos = (allPlayers[0].transform.position + allPlayers[1].transform.position) / 2;
        float avgVar = ((Vector2) allPlayers[1].transform.position - avgPos).magnitude;
        for (int i = 3; i < allPlayers.Length + 1; i += 1)
        {
            Vector2 ratPosition = allPlayers[i - 1].transform.position;
            avgPos = avgPos * (i - 1) / i + ratPosition / i;
            avgVar = avgVar * (i - 1) / i + (ratPosition - avgPos).magnitude / i;
        }
        camera.transform.position = new Vector3(avgPos.x, avgPos.y, -10f);
        camera.orthographicSize = Mathf.Clamp(ORTHOGRAPHIC_SCALE * avgVar,
            MIN_ORTHOGRAPHIC_SIZE, MAX_ORTHOGRAPHIC_SIZE);
    }
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public override void Update()
    {
        if (fixedCam == false) 
        {
            UpdateCameraPose();
        }
        else
        {
            camera.transform.position = DEFAULT_POSITION;
        }
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("updated camera");
        camera = Camera.main;
    }
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    public void FixCameraPos()
    {
        fixedCam = true;
    }
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
}