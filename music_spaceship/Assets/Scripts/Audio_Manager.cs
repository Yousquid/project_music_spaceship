using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Audio_Manager : MonoBehaviour
{
    public FMODUnity.EventReference wrongSound;
    public FMODUnity.EventReference correctSound;
    public FMODUnity.EventReference spaceshipForwardSound;
    public FMODUnity.EventReference spaceshipTurnSound;
    public FMODUnity.EventReference spaceshipShootSound;
    public FMODUnity.EventReference stickOnSound;
    public FMODUnity.EventReference stickOffSound;
    public FMODUnity.EventReference guideBookSound;
    public FMODUnity.EventReference asteroidDestroySound;
    public FMODUnity.EventReference buttonSound;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCorrectSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(correctSound);
    }
    public void playWrongSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(wrongSound);

    }
    public void playSpaceshipForward()
    {
        FMODUnity.RuntimeManager.PlayOneShot(spaceshipForwardSound);

    }
    public void playSpaceshipTurn()
    {
        FMODUnity.RuntimeManager.PlayOneShot(spaceshipTurnSound);

    }
    public void playSpaceshipShoot()
    {
        FMODUnity.RuntimeManager.PlayOneShot(spaceshipShootSound);
    }
    public void playStickOnSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(stickOnSound);
    }
    public void playStickOffSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(stickOffSound);
    }
    public void playGuidebookSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(guideBookSound);
    }
    public void playAesteroidSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(asteroidDestroySound);
    }

    public void playButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(buttonSound);
    }
}
