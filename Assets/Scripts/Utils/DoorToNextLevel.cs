using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLevel : MonoBehaviour
{
    private SpriteRenderer doorSprite;
    [SerializeField] private Sprite closed;
    [SerializeField] private Sprite open;
    [SerializeField] private int nextLevel;
    private bool canEnter;

    private void Start()
    {
        doorSprite = GetComponent<SpriteRenderer>();
        canEnter = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && canEnter)
        {
            LoadScene.Load(nextLevel);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            canEnter = true;
            doorSprite.sprite = open;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            canEnter = false;
            doorSprite.sprite = closed;
        }

    }
}
