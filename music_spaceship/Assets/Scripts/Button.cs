using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Button : MonoBehaviour
{
    public instrument_Randomer manager;
    public int buttonOrder;
    public FMODUnity.EventReference frenchHornSound;
    FMOD.Studio.EventInstance frenchHornInstance;
    FMOD.Studio.PARAMETER_ID frenchHornInstanceID;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();
        frenchHornFMOD();

    }

    void frenchHornFMOD()
    {
        frenchHornInstance = FMODUnity.RuntimeManager.CreateInstance(frenchHornSound);
        FMOD.Studio.EventDescription frenchHornSoundDescription;
        frenchHornInstance.getDescription(out frenchHornSoundDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION frenchHornPramaterDescription;
        frenchHornSoundDescription.getParameterDescriptionByName("french_horn", out frenchHornPramaterDescription);
        frenchHornInstanceID = frenchHornPramaterDescription.id;
    }
  
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        if (this.gameObject.layer == 0)
        {
            audioSourceCheckThenSetParameter(0);
            playSound();
        }
        else if (this.gameObject.layer == 1)
        {
            audioSourceCheckThenSetParameter(1);
            playSound();
        }
        else if (this.gameObject.layer == 2)
        {
            audioSourceCheckThenSetParameter(2);
            playSound();
        }
        else if (this.gameObject.layer == 3)
        {
            audioSourceCheckThenSetParameter(3);
            playSound();
        }
        else if (this.gameObject.layer == 4)
        {
            audioSourceCheckThenSetParameter(4);
            playSound();
        }
    }
    /*void buttonPlaySound()
    {
        if (this.gameObject.layer == 0)
        {
            audioSourceCheckThenSetParameter(0);
            playSound();
        }
        else if (this.gameObject.layer == 1)
        {
            audioSourceCheckThenSetParameter(1);
            playSound();
        }
        else if(this.gameObject.layer == 2)
        {
            audioSourceCheckThenSetParameter(2);
            playSound();
        }
        else if(this.gameObject.layer == 3)
        {
            audioSourceCheckThenSetParameter(3);
            playSound();
        }
        else if(this.gameObject.layer == 4)
        {
            audioSourceCheckThenSetParameter(4);
            playSound();
        }
    }*/

    GameObject FindNearestWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearestObject = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject obj in objectsWithTag)
        {
            float distanceToObj = Vector3.Distance(currentPosition, obj.transform.position);

            if (distanceToObj < shortestDistance)
            {
                shortestDistance = distanceToObj;
                nearestObject = obj;
            }
        }

        return nearestObject;
    }

    void audioSourceCheckThenSetParameter( int buttonOrder )
    {
        if (manager.buttonAudioSourceList[buttonOrder] == "Gong")
        {
            frenchHornInstance.setParameterByID(frenchHornInstanceID, 1);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Shang")
        {
            frenchHornInstance.setParameterByID(frenchHornInstanceID, 2);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Jue")
        {
            frenchHornInstance.setParameterByID(frenchHornInstanceID, 3);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Zhi")
        {
            frenchHornInstance.setParameterByID(frenchHornInstanceID, 4);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Yu")
        {
            frenchHornInstance.setParameterByID(frenchHornInstanceID, 5);
        }
    }

    void playSound()
    {
        if (frenchHornInstance.isValid())
        {
            FMOD.Studio.PLAYBACK_STATE playbackstate;
            frenchHornInstance.getPlaybackState(out playbackstate);
            if (playbackstate == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
                frenchHornInstance.start();
            }
        }
    }
}
