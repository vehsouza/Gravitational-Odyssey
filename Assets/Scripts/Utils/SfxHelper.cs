using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxHelper : MonoBehaviour
{
    [SerializeField] private AudioSource footstepsSfx;
    [SerializeField] private AudioSource jumpSfx;
    [SerializeField] private AudioSource landingSfx;
    [SerializeField] private AudioSource gravitySfx;
    [SerializeField] private AudioSource turnDirectionSfx;

    public void PlayFootstepsSfx()
    {
        if (footstepsSfx != null) footstepsSfx.Play();
    }

    public void PlayJumpSfx()
    {
        if (jumpSfx != null) jumpSfx.Play();
    }

    public void PlayLandingSfx()
    {
        if (landingSfx != null) landingSfx.Play();
    }

    public void PlayGravitySfx()
    {
        if (gravitySfx != null) gravitySfx.Play();
    }

    public void StopGravitySfx()
    {
        if (gravitySfx != null) gravitySfx.Stop();
    }

    public void PlayTurnSfx()
    {
        if (turnDirectionSfx != null) turnDirectionSfx.Play();
    }

}
