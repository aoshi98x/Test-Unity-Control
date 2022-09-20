using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool es_Celda = false;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="celda")
        {
            es_Celda = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="celda")
        {
            es_Celda = false;
        }
    }

    
}
