using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLevel : MonoBehaviour
{
    [SerializeField] private int nextLevel;
    [SerializeField] private GameObject wKeySprite;
    private bool canEnter;

    private void Start()
    {
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
            wKeySprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            canEnter = false;
            wKeySprite.SetActive(false);
        }

    }
}
