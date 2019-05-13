using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;
    public float speed = 10f;

    private void Update ()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions (moveDistance);
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
    }

    public void SetSpeed (float velocity)
    {
        speed = velocity;
    }

    public void CheckCollisions (float collisionDistance)
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, collisionDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHit (hit);
        }
    }

    public void OnHit (RaycastHit hit)
    {

        Destroy (this.gameObject);
    }
}
