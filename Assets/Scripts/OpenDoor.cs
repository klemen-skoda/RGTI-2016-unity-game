using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public float speed = 5;
    public bool openable = false;
    public bool open = false;
    //Vector3 rotate = new Vector3(0, 0, 0);
    Quaternion rotate = Quaternion.identity;

    void Awake()
    {

    }

    void Update()
    {

        if(openable == true && Input.GetKeyDown(KeyCode.F))
        {
            if (open == false)
            {
                rotate = Quaternion.Euler(0, 90, 0);
                open = true;
                
            }
            else
            {
                rotate = Quaternion.Euler(0, 0, 0);
                open = false;
            }
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {

        openable = true;
    }

    void OnTriggerExit(Collider other)
    {

        openable = false;
    }
}
