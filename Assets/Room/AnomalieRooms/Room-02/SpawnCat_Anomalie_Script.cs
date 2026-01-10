using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Anomaly : MonoBehaviour
{

    public GameObject Player;
    

    public GameObject catAnomaly;







    void Start()
    {
        catAnomaly.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            catAnomaly.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            catAnomaly.SetActive(false);
        }
    }




}
