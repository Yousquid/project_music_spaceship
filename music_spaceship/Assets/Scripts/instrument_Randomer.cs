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

    // Start is called before the first frame update
    void Start()
    {
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
     /*   instrumentsSourceList.Add("3");
        instrumentsSourceList.Add("4");
        instrumentsSourceList.Add("5");
        instrumentsSourceList.Add("6");
        instrumentsSourceList.Add("7");
        instrumentsSourceList.Add("8");
        instrumentsSourceList.Add("9");
        instrumentsSourceList.Add("10"); */
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
}
