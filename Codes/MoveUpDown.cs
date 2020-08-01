using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float speed;
    public float length;
    private float counter;
    private float startPosition;

    private float actualPosition;
    private float lastPosition;
    public bool horizontal;
    // Start is called before the first frame update
    void Start()
    {
        if (horizontal)
        {
            startPosition = transform.position.x;
        }
        else
        {
            startPosition = transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    { counter += Time.deltaTime * speed;
        if (horizontal)
        {

        }

        else
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(counter,length) + startPosition);
        }
        
    }
}
