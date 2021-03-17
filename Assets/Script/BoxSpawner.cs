using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject boxPrefab;

    private float boxColliderHalfWidth ;
    private float boxColliderHalfHeight ;

    private int duration = 1;

    private bool retrySpawn = false;

    private Timer timer;
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        GameObject tempBox = Instantiate<GameObject>(boxPrefab);
        BoxCollider2D collider = tempBox.GetComponent<BoxCollider2D>();
         boxColliderHalfWidth = collider.size.x / 2;
         boxColliderHalfHeight = collider.size.y / 2;
      
        Destroy(tempBox);
        Instantiate(boxPrefab);
        timer.Duration = duration;
        timer.Run();
     


    }
    private void Update()
    {

        if (retrySpawn || timer.Finished)
        {
            Spawner();
        }
    }
    private void Spawner()
    {
       
        Vector3 vector = new Vector3(Random.Range(ScreenUtils.ScreenRight, -ScreenUtils.ScreenRight),ScreenUtils.ScreenTop,0) ;
        Debug.Log(vector);
        if (Physics2D.OverlapArea(new Vector2(vector.x- boxColliderHalfWidth, vector.y - boxColliderHalfHeight),new Vector2(vector.x + boxColliderHalfWidth, vector.y + boxColliderHalfHeight)) == null)
        {
            retrySpawn = false;
            Instantiate(boxPrefab, vector, Quaternion.identity);
            timer.Duration = duration;
            timer.Run();
        }
        else
        {
            retrySpawn = true;
        }
       
    }
}
