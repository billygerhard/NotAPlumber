using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData.timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GameData.timer -= Time.fixedDeltaTime;
    }
}
