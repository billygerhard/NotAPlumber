using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > 0)
        {
            transform.position = new Vector3(player.transform.position.x,0,transform.position.z);
        }

        if(player.transform.position.x < 0)
        {
            transform.position = spawnPoint;
        }
    }
}
