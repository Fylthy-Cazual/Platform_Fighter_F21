using UnityEngine;

public class EndOfMap : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D c) {
        if (c.gameObject.TryGetComponent(out Rat rat))
        {
            rat.die();
        }
    }
}
