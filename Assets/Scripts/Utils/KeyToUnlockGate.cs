using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.U2D;

public class KeyToUnlockGate : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private BoxCollider2D keyCollider;
    [SerializeField] private SpriteRenderer keySprite;

    private void Start()
    {
        keyCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            player.hasKey = true;
            keyCollider.enabled = false;
            keySprite.enabled = false;
            Debug.Log("Key collect!");
        }
    }
}
