using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private SpriteRenderer gateGraphic;
    [SerializeField] private int nextLevel;
    [SerializeField] private GameObject eKeySprite;
    private bool canEnter;
    private bool tryingOpen;

    [SerializeField] private TextMeshProUGUI gateClosedTxt;

    [Header("GateAnimation")]
    [SerializeField] private Sprite openGate;
    [SerializeField] private Sprite closedGate;

    [Header("LevelLoader")]
    [SerializeField] private LevelLoader levelLoader;

    private void Start()
    {
        canEnter = false;
        tryingOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canEnter)
        {
            levelLoader.LoadNextLevel();
            player.hasKey = false;
        }
        if(Input.GetKeyDown(KeyCode.E) && !canEnter && tryingOpen)
        {
            AnimateText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() && player.hasKey)
        {
            canEnter = true;
            eKeySprite.SetActive(true);
            gateGraphic.sprite = openGate;
        }
        if (other.GetComponent<PlayerController>() && !player.hasKey)
        {
            tryingOpen = true;
            canEnter = false;
            eKeySprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() && player.hasKey)
        {
            canEnter = false;
            eKeySprite.SetActive(false);
            gateGraphic.sprite = closedGate;
        }
        if (other.GetComponent<PlayerController>() && !player.hasKey && tryingOpen)
        {
            gateClosedTxt.enabled = false;
            tryingOpen = false;
        }
    }

    public void AnimateText()
    {
        gateClosedTxt.enabled = true;

        // Definir a cor inicial do texto com opacidade zero
        Color initialColor = gateClosedTxt.color;
        initialColor.a = 0f;
        gateClosedTxt.color = initialColor;

        // Usar o DoTween para animar a opacidade para 1 em 1 segundo
        gateClosedTxt.DOFade(1f, 1f)
            .OnComplete(() =>
            {
                gateClosedTxt.DOFade(0f, 1f);
            });
    }
}
