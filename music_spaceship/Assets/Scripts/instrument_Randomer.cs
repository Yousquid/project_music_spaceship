using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrument_Randomer : MonoBehaviour
{
    public List<string> buttonAudioSourceList;
    // Start is called before the first frame update
    void Start()
    {
        initiateList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shuffle(buttonAudioSourceList);
           
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            print(buttonAudioSourceList[1]);
        }
        
    }


    private void initiateList()
    {
        buttonAudioSourceList.Add("Gong");
        buttonAudioSourceList.Add("Shang");
        buttonAudioSourceList.Add("Jue");
        buttonAudioSourceList.Add("Zhi");
        buttonAudioSourceList.Add("Yu");
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
}
