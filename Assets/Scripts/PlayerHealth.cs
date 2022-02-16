using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public
    private int maxHealth = 5;
    [SerializeField]
    private int defaultHealth = 3;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = defaultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int value = 1)
    {
        if(currentHealth - value >= 0)
        {
            currentHealth-= value;
        }
        else
        {
            currentHealth = 0;
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void ResetHealth()
    {
        currentHealth = defaultHealth;
    }
}
