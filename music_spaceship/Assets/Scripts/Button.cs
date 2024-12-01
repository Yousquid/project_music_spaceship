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

    public FMODUnity.EventReference frenchHornHighSound;
    FMOD.Studio.EventInstance frenchHornHighInstance;
    FMOD.Studio.PARAMETER_ID frenchHornHighInstanceID;


    public Sprite sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();
        // frenchHornLowFMOD();
        frenchHornInstance = initiateInstance(frenchHornSound, frenchHornInstance, frenchHornInstanceID,"french_horn");
        frenchHornInstanceID = initiateInstanceID(frenchHornSound, frenchHornInstance, frenchHornInstanceID, "french_horn");
        frenchHornHighInstance = initiateInstance(frenchHornHighSound, frenchHornHighInstance, frenchHornHighInstanceID,"french_horn_high");
        frenchHornHighInstanceID = initiateInstanceID(frenchHornHighSound, frenchHornHighInstance, frenchHornHighInstanceID, "french_horn_high");
    }

    void frenchHornLowFMOD()
    {
        frenchHornInstance = FMODUnity.RuntimeManager.CreateInstance(frenchHornSound);
        FMOD.Studio.EventDescription frenchHornSoundDescription;
        frenchHornInstance.getDescription(out frenchHornSoundDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION frenchHornPramaterDescription;
        frenchHornSoundDescription.getParameterDescriptionByName("french_horn", out frenchHornPramaterDescription);
        frenchHornInstanceID = frenchHornPramaterDescription.id;
    }

    FMOD.Studio.EventInstance initiateInstance(FMODUnity.EventReference tempSound, FMOD.Studio.EventInstance tempInstance, FMOD.Studio.PARAMETER_ID tempID,string parameterName)
    {
        tempInstance = FMODUnity.RuntimeManager.CreateInstance(tempSound);
        FMOD.Studio.EventDescription tempDescription;
        tempInstance.getDescription(out tempDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION tempParameterDescription;
        tempDescription.getParameterDescriptionByName(parameterName, out tempParameterDescription);
        tempID = tempParameterDescription.id;
        return tempInstance;
    }

    FMOD.Studio.PARAMETER_ID initiateInstanceID(FMODUnity.EventReference tempSound, FMOD.Studio.EventInstance tempInstance, FMOD.Studio.PARAMETER_ID tempID, string parameterName)
    {
        tempInstance = FMODUnity.RuntimeManager.CreateInstance(tempSound);
        FMOD.Studio.EventDescription tempDescription;
        tempInstance.getDescription(out tempDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION tempParameterDescription;
        tempDescription.getParameterDescriptionByName(parameterName, out tempParameterDescription);
        tempID = tempParameterDescription.id;
        return tempID;
    }

    void Update()
    {
        buttonClickDetection();
    }

    public void OnButtonClicked()
    {
        if (this.gameObject.layer == 6)
        {
            audioSourceCheckThenSetParameterPlaySound(0);
            recordButtonInputToManager(0);

        }
        else if (this.gameObject.layer == 7)
        {
            audioSourceCheckThenSetParameterPlaySound(1);
            recordButtonInputToManager(1);
        }
        else if (this.gameObject.layer == 8)
        {
            audioSourceCheckThenSetParameterPlaySound(2);
            recordButtonInputToManager(2);
        }
        else if (this.gameObject.layer == 9)
        {
            audioSourceCheckThenSetParameterPlaySound(3);
            recordButtonInputToManager(3);
        }
        else if (this.gameObject.layer == 10)
        {
            audioSourceCheckThenSetParameterPlaySound(4);
            recordButtonInputToManager(4);
        }
    }
    

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

    void audioSourceCheckThenSetParameterPlaySound( int buttonOrder )
    {
        FMOD.Studio.EventInstance tempInstance;

        tempInstance = instrumentAssign();

        if (manager.buttonAudioSourceList[buttonOrder] == "Gong")
        {
            print(manager.buttonAudioSourceList[0]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 1);
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Shang")
        {
            print(manager.buttonAudioSourceList[1]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 2);
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Jue")
        {
            print(manager.buttonAudioSourceList[2]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 3);
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Zhi")
        {
            print(manager.buttonAudioSourceList[3]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 4);
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Yu")
        {
            print(manager.buttonAudioSourceList[4]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 5);
            playSound(tempInstance);
        }
    }


    FMOD.Studio.PARAMETER_ID findInstrumentAudioSourceID()
    {
        if (manager.instrumentsSourceList[0] == "frenchHornLow")
        {
            return frenchHornInstanceID;
        }
        else if (manager.instrumentsSourceList[0] == "frenchHornHigh")
        {
            return frenchHornHighInstanceID;
        }
        /* else if (manager.instrumentsSourceList[0] == "3")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "4")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "5")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "6")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "7")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "8")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "9")
         {
             return frenchHornHighInstance;
         }
         else if (manager.instrumentsSourceList[0] == "10")
         {
             return frenchHornHighInstance;
         } */
        else { return frenchHornHighInstanceID; }
    }

    FMOD.Studio.EventInstance instrumentAssign()
    {
        if (manager.instrumentsSourceList[0] == "frenchHornLow")
        {
            return frenchHornInstance;
        }
        else if (manager.instrumentsSourceList[0] == "frenchHornHigh")
        {
            return frenchHornHighInstance;
        }
       /* else if (manager.instrumentsSourceList[0] == "3")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "4")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "5")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "6")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "7")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "8")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "9")
        {
            return frenchHornHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "10")
        {
            return frenchHornHighInstance;
        } */
        else { return frenchHornHighInstance; }
    }

    void playSound(FMOD.Studio.EventInstance tempInstance)
    {
        if (tempInstance.isValid())
        {
            FMOD.Studio.PLAYBACK_STATE playbackstate;
            tempInstance.getPlaybackState(out playbackstate);
            if (playbackstate == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
                tempInstance.start();
            }
        }
    }

    void buttonClickDetection()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnButtonClicked();
            }
        }
    }

    void recordButtonInputToManager(int buttonOrder)
    {
        if (manager.buttonAudioSourceList[buttonOrder] == "Gong")
        {
            manager.playerInputList[buttonOrder] = "Gong";
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Shang")
        {
            manager.playerInputList[buttonOrder] = "Shang";
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Jue")
        {
            manager.playerInputList[buttonOrder] = "Jue";
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Zhi")
        {
            manager.playerInputList[buttonOrder] = "Zhi";
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Yu")
        {
            manager.playerInputList[buttonOrder] = "Yu";
        }
    }

}
