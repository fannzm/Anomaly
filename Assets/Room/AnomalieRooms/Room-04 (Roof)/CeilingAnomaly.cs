using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingAnomaly : MonoBehaviour
{
    public GameManager gameManager;
    public float sinkSpeed = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -sinkSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.WrongChoice(); 
            }
        }
    }
}
