using UnityEngine;

[CreateAssetMenu(fileName = "CameraManager", menuName = "Managers/CameraManager")]
public class CameraManager : ManagerSO<CameraManager>
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    public static readonly float MIN_ORTHOGRAPHIC_SIZE = 4.0f;
    public static readonly float MAX_ORTHOGRAPHIC_SIZE = 12.0f;
    public static readonly float ORTHOGRAPHIC_SCALE = 1.0f;
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    [ReadOnly] public Camera camera;
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    public override void Initialize()
    {
        camera = Camera.main;
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
            avgPos = avgPos * i / (i - 1) + ratPosition / i;
            avgVar = avgVar * i / (i - 1) + (ratPosition - avgPos).magnitude / i;
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
        UpdateCameraPose();
    }
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
}