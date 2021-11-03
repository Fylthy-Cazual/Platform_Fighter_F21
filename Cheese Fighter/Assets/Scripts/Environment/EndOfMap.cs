using UnityEngine;

public class EndOfMap : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D c) {
        Rat rat = c.gameObject.GetComponent<Rat>();
        rat.die();
    }
}
