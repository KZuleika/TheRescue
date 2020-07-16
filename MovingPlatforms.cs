using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float speed;
    public float length;
    private float counter;
    private float startPosition;

    private float actualPosition;
    private float lastPosition;
    private float actualScale;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        actualScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.PingPong(counter, length) + startPosition, transform.position.y);
        actualPosition = transform.position.x;
        if (actualPosition < lastPosition)
        {
            transform.localScale = new Vector3(actualScale, actualScale, 1);
        }
        if (actualPosition > lastPosition)
        {
            transform.localScale = new Vector3(actualScale, actualScale, 1);
        }
        lastPosition = transform.position.x;

    }
}
