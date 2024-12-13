using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicaotr_mask : MonoBehaviour
{
    public instrument_Randomer manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.returnManageIndicators() == 0)
        {
            this.transform.position = new Vector3(transform.position.x, -6.3f, 0);
        }
        if (manager.returnManageIndicators() == 1)
        {
            this.transform.position = new Vector3(transform.position.x, -5.5f, 0);
        }
        if (manager.returnManageIndicators() == 2)
        {
            this.transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
        if (manager.returnManageIndicators() == 3)
        {
            this.transform.position = new Vector3(transform.position.x, -3.6f, 0);
        }
        if (manager.returnManageIndicators() == 4)
        {
            this.transform.position = new Vector3(transform.position.x, -2.8f, 0);
        }
        //if (manager.returnManageIndicators() == 5)
        //{
        //    this.transform.position = new Vector3(transform.position.x, -2f, 0);
        //}
    }
}
