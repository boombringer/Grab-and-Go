using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDebuger : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    void Start()
    {
        offset = transform.position;
    }


    // Update is called once per frame
    void Update()//FixedUpdate()
    {
        Vector3 target = new Vector3(transform.position.x, player.position.y, transform.position.z);
        //transform.position =  new Vector3(player.position.x, transform.position.y, player.position.z + transform.position.z);
        Debug.DrawRay(player.position, target);
    }
}
