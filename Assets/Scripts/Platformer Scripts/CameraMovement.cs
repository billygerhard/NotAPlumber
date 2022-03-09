using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 spawnPoint;
    private Vector3 playerSpawnPoint;
    private bool isTrackingY = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(0, 0);//transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, spawnPoint.x, player.transform.position.x);
        float y = Mathf.Clamp(player.transform.position.y, spawnPoint.y, player.transform.position.y);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
