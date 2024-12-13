using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class instrument_Randomer : MonoBehaviour
{
    public List<string> buttonAudioSourceList;
    public List<GameObject> buttonGameobjectList;
    public List<string> instrumentsSourceList;
    public GameObject buttonPositionReference;
    public GameObject buttonPrefab;
    public float buttonInterval = 1.5f;
    public bool isRecordPlayerInput = false;
    public List<string> playerInputList;
    public bool isCheckingAnswer;
    public Audio_Manager audio_manager;
    public List<string> colorList;
    //For Indicator
    public GameObject indicator;
    public Transform reference;
    public float indicatorInterval;
    public List<GameObject> indicatorList;

    public FMODUnity.EventReference bgm;
    // Start is called before the first frame update
    void Start()
    {
        audio_manager = GetComponent<Audio_Manager>();
        initiateInstrumentList();
     //   initiateButtons();
        initiatePitchList();
     //   ResetAudioSource();
        initialateInputList();
       // InitiateIndicators();
        FMODUnity.RuntimeManager.PlayOneShot(bgm);
        initiateColorList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            print(playerInputList[0]+ playerInputList[1]+ playerInputList[2]+ playerInputList[3] +playerInputList[4]);
        }
        isRecordPlayerInput = true;

        //manageIndicators();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void ResetAudioSource()
    {
        audio_manager.playCorrectSFX();
        Shuffle(buttonAudioSourceList);
        Shuffle(instrumentsSourceList);
        Shuffle(colorList);
    }
    private void initiatePitchList()
    {
        buttonAudioSourceList.Add("Gong");
        buttonAudioSourceList.Add("Shang");
        buttonAudioSourceList.Add("Jue");
        buttonAudioSourceList.Add("Zhi");
        buttonAudioSourceList.Add("Yu");
    }

    private void initiateColorList()
    {
        colorList.Add("red");
        colorList.Add("green");
        colorList.Add("blue");
        colorList.Add("yellow");
        colorList.Add("purple");
    }
    private void initiateInstrumentList()
    {
        instrumentsSourceList.Add("frenchHornLow");
        instrumentsSourceList.Add("frenchHornHigh");
        instrumentsSourceList.Add("bassLow");
        instrumentsSourceList.Add("bassHigh");
        instrumentsSourceList.Add("fluteLow");
        instrumentsSourceList.Add("fluteHigh");
        instrumentsSourceList.Add("guzhengLow");
        instrumentsSourceList.Add("guzhengHigh");
        instrumentsSourceList.Add("violinLow");
        instrumentsSourceList.Add("violinHigh"); 
    }
    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1); 
            T temp = list[i]; 
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void initialateInputList()
    {
        playerInputList.Add("0");
        playerInputList.Add("0");
        playerInputList.Add("0");
        playerInputList.Add("0");
        playerInputList.Add("0");
    }

    void initiateButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject button = Instantiate(buttonPrefab);
            button.transform.position = buttonPositionReference.transform.position;
            button.transform.position += new Vector3(buttonInterval*i,0,0);
            buttonGameobjectList.Add(button);
            button.transform.SetParent(this.transform);
            button.layer = i+6;
        }
    }

    public void recordPlayerInputTrue()
    {
        isRecordPlayerInput = true;
    }

    public void recordPlayerInputFlase()
    {
        isRecordPlayerInput = false;
    }

    public bool playerInputBool()
    {
        return isRecordPlayerInput;
    }

    public void resetInputList()
    {
        playerInputList[0] = "0";
        playerInputList[1] = "0";
        playerInputList[2] = "0";
        playerInputList[3] = "0";
        playerInputList[4] = "0";
    }

    public bool detectIfInputListIsFull()
    {
        if (playerInputList.Count == 5 && playerInputList[4] != "0")
        {
            return true;
        }
        else return false;
    }

    public string CheckAnswer()
    {
      
            if (playerInputList[0] == "Gong" && playerInputList[1] == "Shang" && playerInputList[2] == "Jue" && playerInputList[3] == "Zhi" && playerInputList[4] == "Yu")
            {
                return "forward";
            }
            else if (playerInputList[0] == "Jue" && playerInputList[1] == "Zhi" && playerInputList[2] == "Yu" && playerInputList[3] == "Drum" && playerInputList[4] == "Gong")
            {
                return "left";
            }
            else if (playerInputList[0] == "Yu" && playerInputList[1] == "Zhi" && playerInputList[2] == "Jue" && playerInputList[3] == "Drum" && playerInputList[4] == "Shang")
            {
                return "right";
            }
            else if (playerInputList[0] == "Gong" && playerInputList[1] == "Drum" && playerInputList[2] == "Jue" && playerInputList[3] == "Drum" && playerInputList[4] == "Yu")
            {
                return "shoot";
            }
            else { return "error"; }
        }
     
    

    public bool IsCheckingAnswer()
    {
        return isCheckingAnswer;
    }
    public void SetCheckingAnswerTrue()
    {
        isCheckingAnswer = true;
    }
    public void SetCheckingAnswerFalse()
    {
        isCheckingAnswer = false;
        resetInputList();
    }
    void InitiateIndicators()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp_indicator = Instantiate(indicator);
            temp_indicator.transform.position = reference.position;
            temp_indicator.transform.position += new Vector3(indicatorInterval * i, 0, 0);
            indicatorList.Add(temp_indicator);
            temp_indicator.transform.SetParent(this.transform);
            temp_indicator.layer = i + 6;
        }
    }

    public int returnManageIndicators()
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerInputList[i] != "0")
            {
                continue;

            }
            else if (playerInputList[i] == "0")
            {
                return i;
            }
        }

        return -1;
     }

}
