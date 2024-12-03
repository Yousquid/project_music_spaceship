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

    public FMODUnity.EventReference bassLowSound;
    FMOD.Studio.EventInstance bassLowInstance;
    FMOD.Studio.PARAMETER_ID bassLowInstanceID;

    public FMODUnity.EventReference bassHighSound;
    FMOD.Studio.EventInstance bassHighInstance;
    FMOD.Studio.PARAMETER_ID bassHighInstanceID;

    public FMODUnity.EventReference fluteLowSound;
    FMOD.Studio.EventInstance fluteLowInstance;
    FMOD.Studio.PARAMETER_ID fluteLowInstanceID;

    public FMODUnity.EventReference fluteHighSound;
    FMOD.Studio.EventInstance fluteHighInstance;
    FMOD.Studio.PARAMETER_ID fluteHighInstanceID;

    public FMODUnity.EventReference guzhengLowSound;
    FMOD.Studio.EventInstance guzhengLowInstance;
    FMOD.Studio.PARAMETER_ID guzhengLowInstanceID;

    public FMODUnity.EventReference guzhengHighSound;
    FMOD.Studio.EventInstance guzhengHighInstance;
    FMOD.Studio.PARAMETER_ID guzhengHighInstanceID;

    public FMODUnity.EventReference violinLowSound;
    FMOD.Studio.EventInstance violinLowInstance;
    FMOD.Studio.PARAMETER_ID violinLowInstanceID;

    public FMODUnity.EventReference violinHighSound;
    FMOD.Studio.EventInstance violinHighInstance;
    FMOD.Studio.PARAMETER_ID violinHighInstanceID;

    public FMODUnity.EventReference drumSound;

    public FMOD.Studio.EventInstance currentMusicInstance;

    public Sprite sprite;

    bool hasStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindNearestWithTag("manager").GetComponent<instrument_Randomer>();
        // frenchHornLowFMOD();
        frenchHornInstance = initiateInstance(frenchHornSound, frenchHornInstance, frenchHornInstanceID,"french_horn");
        frenchHornInstanceID = initiateInstanceID(frenchHornSound, frenchHornInstance, frenchHornInstanceID, "french_horn");

        frenchHornHighInstance = initiateInstance(frenchHornHighSound, frenchHornHighInstance, frenchHornHighInstanceID,"french_horn_high");
        frenchHornHighInstanceID = initiateInstanceID(frenchHornHighSound, frenchHornHighInstance, frenchHornHighInstanceID, "french_horn_high");

        fluteLowInstance = initiateInstance(fluteLowSound, fluteLowInstance, fluteLowInstanceID,"flute_low");
        fluteLowInstanceID = initiateInstanceID(fluteLowSound, fluteLowInstance, fluteLowInstanceID, "flute_low");

        fluteHighInstance = initiateInstance(fluteHighSound, fluteHighInstance, fluteHighInstanceID, "flute_high");
        fluteHighInstanceID = initiateInstanceID(fluteHighSound, fluteHighInstance, fluteHighInstanceID, "flute_high");

        guzhengLowInstance = initiateInstance(guzhengLowSound, guzhengLowInstance, guzhengLowInstanceID, "guzheng_low");
        guzhengLowInstanceID = initiateInstanceID(guzhengLowSound, guzhengLowInstance, guzhengLowInstanceID, "guzheng_low");

        guzhengHighInstance = initiateInstance(guzhengHighSound, guzhengHighInstance, guzhengHighInstanceID, "guzheng_high");
        guzhengHighInstanceID = initiateInstanceID(guzhengHighSound, guzhengHighInstance, guzhengHighInstanceID, "guzheng_high");

        violinLowInstance = initiateInstance(violinLowSound, violinLowInstance, violinLowInstanceID,"violin_low");
        violinLowInstanceID = initiateInstanceID(violinLowSound, violinLowInstance, violinLowInstanceID, "violin_low");

        violinHighInstance = initiateInstance(violinHighSound, violinHighInstance, violinHighInstanceID, "violin_high");
        violinHighInstanceID = initiateInstanceID(violinHighSound, violinHighInstance, violinHighInstanceID, "violin_high");

        bassLowInstance = initiateInstance(bassLowSound, bassLowInstance, bassLowInstanceID,"bass_low");
        bassLowInstanceID = initiateInstanceID(bassLowSound, bassLowInstance, bassLowInstanceID, "bass_low");

        bassHighInstance = initiateInstance(bassHighSound, bassHighInstance, bassHighInstanceID, "bass_high");
        bassHighInstanceID = initiateInstanceID(bassHighSound, bassHighInstance, bassHighInstanceID, "bass_high");
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

        manager.detectIfInputListIsFull();

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
        else if (this.gameObject.layer == 0)
        {
            print("Drum");
            FMODUnity.RuntimeManager.PlayOneShot(drumSound);
            recordButtonInputToManager(1);
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
            print(manager.instrumentsSourceList[0]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 1);
            currentMusicInstance = tempInstance;
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Shang")
        {
            print(manager.buttonAudioSourceList[1]);
            print(manager.instrumentsSourceList[0]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 2);
            currentMusicInstance = tempInstance;
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Jue")
        {
            print(manager.buttonAudioSourceList[2]);
            print(manager.instrumentsSourceList[0]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 3);
            currentMusicInstance = tempInstance;
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Zhi")
        {
            print(manager.buttonAudioSourceList[3]);
            print(manager.instrumentsSourceList[0]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 4);
            currentMusicInstance = tempInstance;
            playSound(tempInstance);
        }
        if (manager.buttonAudioSourceList[buttonOrder] == "Yu")
        {
            print(manager.buttonAudioSourceList[4]);
            print(manager.instrumentsSourceList[0]);
            tempInstance.setParameterByID(findInstrumentAudioSourceID(), 5);
            currentMusicInstance = tempInstance;
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
        else if (manager.instrumentsSourceList[0] == "bassLow")
         {
             return bassLowInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "bassHigh")
         {
             return bassHighInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "fluteLow")
         {
             return fluteLowInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "fluteHigh")
         {
             return fluteHighInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "guzhengLow")
         {
             return guzhengLowInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "guzhengHigh")
         {
             return guzhengHighInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "violinLow")
         {
             return violinLowInstanceID;
         }
         else if (manager.instrumentsSourceList[0] == "violinHigh")
         {
             return violinHighInstanceID;
         } 
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
        else if (manager.instrumentsSourceList[0] == "bassLow")
        {
            return bassLowInstance;
        }
        else if (manager.instrumentsSourceList[0] == "bassHigh")
        {
            return bassHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "fluteLow")
        {
            return fluteLowInstance;
        }
        else if (manager.instrumentsSourceList[0] == "fluteHigh")
        {
            return fluteHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "guzhengLow")
        {
            return guzhengLowInstance;
        }
        else if (manager.instrumentsSourceList[0] == "guzhengHigh")
        {
            return guzhengHighInstance;
        }
        else if (manager.instrumentsSourceList[0] == "violinLow")
        {
            return violinLowInstance;
        }
        else if (manager.instrumentsSourceList[0] == "violinHigh")
        {
            return violinHighInstance;
        }
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
        if (manager.playerInputBool())
        {

            if (this.gameObject.layer == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (manager.playerInputList[i] != "0")
                    {
                        continue;
                    }
                    else if (manager.playerInputList[i] == "0")
                    {
                        manager.playerInputList[i] = "Drum";
                        return;
                    }
                }
            }
            else if (manager.buttonAudioSourceList[buttonOrder] == "Gong")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (manager.playerInputList[i] != "0")
                    {
                        continue;
                    }
                    else if (manager.playerInputList[i] == "0")
                    {
                        manager.playerInputList[i] = "Gong";
                        break;
                    }
                }
            }
            else if (manager.buttonAudioSourceList[buttonOrder] == "Shang")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (manager.playerInputList[i] != "0")
                    {
                        continue;
                    }
                    else if (manager.playerInputList[i] == "0")
                    {
                        manager.playerInputList[i] = "Shang";
                        break;
                    }
                }
            }
            else if (manager.buttonAudioSourceList[buttonOrder] == "Jue")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (manager.playerInputList[i] != "0")
                    {
                        continue;
                    }
                    else if (manager.playerInputList[i] == "0")
                    {
                        manager.playerInputList[i] = "Jue";
                        break;
                    }
                }
            }
            else if (manager.buttonAudioSourceList[buttonOrder] == "Zhi")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (manager.playerInputList[i] != "0")
                    {
                        continue;
                    }
                    else if (manager.playerInputList[i] == "0")
                    {
                        manager.playerInputList[i] = "Zhi";
                        break;
                    }
                }
            }
            else if (manager.buttonAudioSourceList[buttonOrder] == "Yu")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (manager.playerInputList[i] != "0")
                    {
                        continue;
                    }
                    else if (manager.playerInputList[i] == "0")
                    {
                        manager.playerInputList[i] = "Yu";
                        break;
                    }
                }
            }
            
        }
    }

}
