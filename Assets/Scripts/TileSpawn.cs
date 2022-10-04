using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    [Tooltip("How much time to wait before destroying " +
    "the tile after reaching the end")]
    public float destroyTime = 1.5f;
    private void OnTriggerEnter(Collider col)
    {
    // First check if we collided with the player
        if (col.gameObject.GetComponent<PlayerController>())
        {
            // If we did, spawn a new tile
            GameObject.FindObjectOfType<GameManager>
            ().SpawnNextTile();
            // And destroy this entire tile after a short delay
            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}
