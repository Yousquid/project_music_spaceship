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

    // Start is called before the first frame update
    void Start()
    {
        initialateInputList();
        initiateInstrumentList();
        initiateButtons();
        initiatePitchList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shuffle(buttonAudioSourceList);
            Shuffle(instrumentsSourceList);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            print(playerInputList[0]+ playerInputList[1]+ playerInputList[2]+ playerInputList[3] +playerInputList[4]);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            resetInputList();
        }

    }


    private void initiatePitchList()
    {
        buttonAudioSourceList.Add("Gong");
        buttonAudioSourceList.Add("Shang");
        buttonAudioSourceList.Add("Jue");
        buttonAudioSourceList.Add("Zhi");
        buttonAudioSourceList.Add("Yu");
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

    public void detectIfInputListIsFull()
    {
        if (playerInputList.Count == 5 && playerInputList[4] != "0")
        {
            resetInputList();
        }
    }

}
