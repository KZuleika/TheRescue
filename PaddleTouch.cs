using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTouch : MonoBehaviour
{
    float paddleSpeed = 0.01f;
    private Touch touch;
    /*
    private Vector3 TouchPosition;
    private Rigidbody rb;
    private Vector3 direction;
    */

    private void Start()
    {
        //rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * paddleSpeed,
                    transform.position.y, transform.position.z + touch.deltaPosition.y * paddleSpeed);
            }
        }

        /*
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            TouchPosition.z = 0;
            TouchPosition.y = 0;
            direction = (TouchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * paddleSpeed;

            if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
        */
        
        /*
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        var pos = transform.position;
        pos.x = Mathf.Clamp(xPos, -7f, 7f);
        transform.position = pos;
        */
    }

    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider == GetComponent<BoxCollider>())
            {
                float calc = contact.point.x - transform.position.x;

                contact.otherCollider.GetComponent<Rigidbody>().AddForce(450f * calc, 0, 0);
            }
        }
    }
}
