using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FinalLevelTextAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float timeToWait = 1.2f;

    private void Start()
    {
        ShowText();
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(timeToWait);
        anim.SetTrigger("Start");
    }
}
