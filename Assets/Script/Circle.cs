using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private  float speed =5;

    private Vector2 startPos;
    private Vector3 mousePosition;
    public float moveSpeed = 5;
    private Rigidbody2D Rb;
    private void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {

        if (Application.platform == RuntimePlatform.Android)
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                switch (touch.phase)
                {

                    case TouchPhase.Began:
                        startPos = touch.position;
                        startPos = Camera.main.ScreenToWorldPoint(startPos);
                        if (startPos.x >= 0)
                            if (startPos.x <= ScreenUtils.ScreenRight && startPos.x >= ScreenUtils.ScreenLeft)
                                Rb.AddForce(Vector3.right * speed * Time.deltaTime);
                            else
                            {
                                if (startPos.x <= ScreenUtils.ScreenRight && startPos.x >= ScreenUtils.ScreenLeft)
                                    Rb.AddForce(Vector3.left * speed * Time.deltaTime);
                            }

                        break;

                    case TouchPhase.Ended:
                        Rb.velocity = Vector3.zero;

                        break;
                }
            }
        if (Application.platform == RuntimePlatform.WindowsEditor)
            if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.y = ScreenUtils.ScreenBottom + 1;
            if (mousePosition.x <= ScreenUtils.ScreenRight && mousePosition.x >= ScreenUtils.ScreenLeft)
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Object.Instantiate(Resources.Load("GameOver"));
    }

}
