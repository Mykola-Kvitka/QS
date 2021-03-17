using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private float speedUpFactor = 0.0005f;
    private int speedUpDuraction = 1;
    private Rigidbody2D boxRb;
    private Timer speedUpTimer;

    private bool finish = false;

    void Start()
    {
        speedUpTimer = gameObject.AddComponent<Timer>();
        boxRb = gameObject.GetComponent<Rigidbody2D>();
        Runs(speedUpDuraction, speedUpDuraction);
        boxRb.AddForce(Vector3.down * speedUpFactor);
    }

   
    void FixedUpdate()
    {
        DestroyTheBox();
        Movement();
    }
    private void Movement()
    {
        if (finish)
        {
            boxRb.AddForce(Vector3.down * speedUpFactor);
            Runs(speedUpDuraction, speedUpDuraction);
        }
    }
    private void Runs(int speedUpDuration, float speedUpFactor)
    {
        finish = false;
        speedUpTimer.Duration = speedUpDuration;
        if (!speedUpTimer.Finished)
            speedUpTimer.Run();
        finish = speedUpTimer.Finished;
    }
    private void DestroyTheBox()
    {
        if (transform.position.y < (ScreenUtils.ScreenBottom - 4 ))
        {

            Destroy(gameObject);
        }
    }

}
