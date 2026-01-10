using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{

    public Vector3 position;

    void Start()
    {
        position = new Vector3(860f, 780f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Input.mousePosition - position;



    }
}
