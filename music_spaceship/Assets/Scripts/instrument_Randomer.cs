using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrument_Randomer : MonoBehaviour
{
    public List<string> buttonAudioSourceList;
    public List<GameObject> buttonGameobjectList;
    public GameObject buttonPositionReference;
    public GameObject buttonPrefab;
    public float buttonInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        initiateButtons();
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
        }
    }
}
