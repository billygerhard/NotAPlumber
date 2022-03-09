using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{
    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public]
    private GameObject meteor1;
    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public]
    private GameObject meteor2;
    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public]
    private GameObject meteor3;

    private GameObject[] meteors;

    float spawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        meteors = new GameObject[] { meteor1, meteor2, meteor3 };
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            //This will be left most to right most, and above the screen.
            var pos = new Vector3(Random.Range(-6.0f, 6.0f),7);
            int rand = Random.Range(0, meteors.Length);
            var go = Instantiate(meteors[rand], pos, Quaternion.identity);
            float scale = Random.Range(.5f, 3f);
            go.transform.localScale = new Vector3(scale, scale, scale);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(.1f, 1f);
            spawnTime = Random.Range(0, 2);
        }
    }
}
