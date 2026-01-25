using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class LavaScript : MonoBehaviour
{


    public GameObject Respawnpoint;
    public Rigidbody Player;
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
            Player = GameObject.Find("Player").GetComponent<Rigidbody>();
        
    }


    void OnTriggerEnter(Collider other)
    {
        print("CollisionDetected");

        if (other.gameObject.tag == "Player")
        {
            print("Lava HIT");
            
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = new Vector3(Respawnpoint.transform.position.x, Respawnpoint.transform.position.y, Respawnpoint.transform.position.z);
            Player.GetComponent<CharacterController>().enabled = true;
        }
    }



}
