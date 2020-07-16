using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;

    void Update()
    {
        // transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        var pos = transform.position;
        pos.x = Mathf.Clamp(xPos, -7f, 7f);
        transform.position = pos;
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
