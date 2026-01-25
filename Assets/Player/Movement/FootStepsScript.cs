using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStepsScript : MonoBehaviour
{
    public AudioClip walkingsound;
    public AudioSource audioSource;
    
    public bool isPLaying;

   
    
    void Start()
    {
        audioSource.Stop();
        isPLaying = false;
    }

    private void Awake()
    {
        audioSource.Stop();
        isPLaying = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       

        if (Input.GetAxis("Horizontal")>0 | Input.GetAxis("Vertical") > 0)
        {
            if (!isPLaying)
            {
                audioSource.Play();
                isPLaying = true;
            }
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            if (isPLaying)
            {
                audioSource.Stop();
                isPLaying = false;
            }          
            
        }       



    }

    



}
