using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class SwitchGravity : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject level;
    public static bool switchingGravity;

    [Header("VFX")]
    [SerializeField] private GameObject vfx;

    [Header("SFX")]
    [SerializeField] private SfxHelper sfxHelper;

    [Header("Arrows")]
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject leftArrow;

    [Header("Animation")]
    [SerializeField] private float durationToTurnUp = 1f;
    [SerializeField] private float durationToTurnRL = .5f;
    [SerializeField] private Ease ease = Ease.Linear;


    private bool gravityUp, gravityDown, gravityRight, gravityLeft;


    private void Start()
    {
        switchingGravity = false;

        ResetGravityAndArrowSprites();
    }

    private void Update()
    {
        ActiveZeroGravity();
    }

    private void ResetGravityAndArrowSprites()
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);

        gravityUp = false;
        gravityDown = false;
        gravityRight = false;
        gravityLeft = false;
    }

    private void ActiveZeroGravity()
    {
        if (Input.GetMouseButton(1))
        {
            player.TakeDownGravity();
            vfx.SetActive(true);
            switchingGravity = true;

            ChooseGravityDirection();
        }
        if (Input.GetMouseButtonUp(1))
        {
            player.GiveBackGravity();
            vfx.SetActive(false);
            sfxHelper.StopGravitySfx();
            switchingGravity = false;
            ChangeGravityDirection();
            ResetGravityAndArrowSprites();
        }
    }

    private void ChooseGravityDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            upArrow.SetActive(true);
            downArrow.SetActive(false);
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);

            gravityUp = true;
            gravityDown = false;
            gravityRight = false;
            gravityLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);

            gravityUp = false;
            gravityDown = true;
            gravityRight = false;
            gravityLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            upArrow.SetActive(false);
            downArrow.SetActive(false);
            rightArrow.SetActive(true);
            leftArrow.SetActive(false);

            gravityUp = false;
            gravityDown = false;
            gravityRight = true;
            gravityLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            upArrow.SetActive(false);
            downArrow.SetActive(false);
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);

            gravityUp = false;
            gravityDown = false;
            gravityRight = false;
            gravityLeft = true;
        }
    }

    private void ChangeGravityDirection()
    {
        if(gravityUp)
        {
            //level.transform.Rotate(0f, 0f, 180f);
            level.transform.DORotate(new Vector3(0f, 0f, 180f), durationToTurnUp, RotateMode.WorldAxisAdd).SetEase(ease);
            player.RotatePlayer(-180f);
            sfxHelper.PlayTurnSfx();
        }
        if(gravityDown)
        {
            //level.transform.Rotate(0f, 0f, 0f);
            level.transform.DORotate(new Vector3(0f, 0f, 0f), durationToTurnRL, RotateMode.WorldAxisAdd).SetEase(ease);
            player.RotatePlayer(0f);
            sfxHelper.PlayTurnSfx();
        }
        if (gravityRight)
        {
            //level.transform.Rotate(0f, 0f, -90f);
            level.transform.DORotate(new Vector3(0f, 0f, -90f), durationToTurnRL, RotateMode.WorldAxisAdd).SetEase(ease);
            player.RotatePlayer(90f);
            sfxHelper.PlayTurnSfx();
        }
        if (gravityLeft)
        {
            //level.transform.Rotate(0f, 0f, 90f);
            level.transform.DORotate(new Vector3(0f, 0f, 90f), durationToTurnRL, RotateMode.WorldAxisAdd).SetEase(ease);
            player.RotatePlayer(-90f);
            sfxHelper.PlayTurnSfx();
        }
    }
}
