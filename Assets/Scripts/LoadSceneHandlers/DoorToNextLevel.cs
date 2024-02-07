using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLevel : MonoBehaviour
{
    [SerializeField] private int nextLevel;
    [SerializeField] private GameObject eKeySprite;
    private bool canEnter;

    [SerializeField] private LevelLoader levelLoader;

    private void Start()
    {
        canEnter = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canEnter)
        {
            levelLoader.LoadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            canEnter = true;
            eKeySprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            canEnter = false;
            eKeySprite.SetActive(false);
        }
    }
}
