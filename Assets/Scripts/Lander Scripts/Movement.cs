using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Movement : MonoBehaviour
{
    Vector2 move;
    public float speed = 15;
    public Rigidbody2D rb;
    public Text resultText;
    public Fuel fuel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Only allow movement if there is fuel available.
        if(fuel.fuel > 0f)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
        }
        else
        {
            move.x = 0f;
            move.y = 0f;
        }

        //If the game is ended, and the R key is pressed, restart level.
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene("SampleScene");
            //Loading Scene 0, or only scene in the game;
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

    //Fixed update occurs 1/5 of a second
    private void FixedUpdate()
    {
        rb.AddForce(move * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Asteroid")
        {
            //resultText.text = "You Lose!\r\n Press R to restart.";
            resultText.text = "You Lose!";
            Time.timeScale = 0;
            //StartCoroutine("MenuTimeout");

            var timeout = SetTimeout(() => {
                print("Set Timeout Fired");
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            }, 3 * 1000);
        }
        else if (collision.collider.tag == "Win")
        {
            //resultText.text = "You Win!\r\n Press R to restart.";
            resultText.text = "You Win!";
            Time.timeScale = 0;
            //StartCoroutine("MenuTimeout");

            var timeout = SetTimeout(() => {
                print("Set Timeout Fired");
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            }, 3 * 1000);
        }
    }

    public void MenuTimeout()
    {
        //This is based on Time.timeScale, so this is broken
        //yield return new WaitForSeconds(3);

        //This pauses the UI. This will not work either.
        //System.Threading.Thread.Sleep(3 * 1000);

        var timeout = SetTimeout(() => {
            print("Set Timeout Fired");
            SceneManager.LoadScene(1);
        }, 3 * 1000);
        
    }

    public CancellationTokenSource SetTimeout(Action action, int millis)
    {

        var cts = new CancellationTokenSource();
        var ct = cts.Token;
        _ = Task.Run(() => {
            Thread.Sleep(millis);
            if (!ct.IsCancellationRequested)
                action();
        }, ct);

        return cts;
    }

    public void ClearTimeout(CancellationTokenSource cts)
    {
        cts.Cancel();
    }
}
