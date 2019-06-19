using UnityEngine;
using System.Collections;
using System;
using LeoDeg.Properties;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;
    public float speed = 10f;
    public float damageAmount = 5f;

    public float lifeTime = 3f;
    public float skinWidth = 0.1f;

    private void Start ()
    {
        Destroy (gameObject, lifeTime);

        Collider[] initialCollisions = Physics.OverlapSphere (transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHit (initialCollisions[0], transform.position);
        }
    }

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

        if (Physics.Raycast (ray, out hit, collisionDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHit (hit.collider, hit.point);
        }
    }

    public void OnHit (Collider hitCollider, Vector3 hitPoint)
    {
        IHittable damage = hitCollider.GetComponent<IHittable> (); 

        if (damage != null)
        {
            Debug.Log ("Object name: " + hitCollider.gameObject.name);
            damage.TakeHit (damageAmount, hitPoint, transform.forward);
        }

        Destroy (this.gameObject);
    }
}
