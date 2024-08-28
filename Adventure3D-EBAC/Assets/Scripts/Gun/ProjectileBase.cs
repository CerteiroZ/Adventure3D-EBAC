using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 2f;

    public int damageAmout = 5;
    public float speed = 50f;

    public List<string> tagsToHit;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var projectile = collision.collider.GetComponent<ProjectileBase>();
        if (projectile != null)
        {
            return;
        }

        foreach (var t in tagsToHit)
        {
            if (collision.transform.tag == t)
            {
                ProjectileBase projectileBase = collision.collider.GetComponent<ProjectileBase>();
                if (projectileBase != null)
                {
                    return;
                }

                var damageable = collision.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    dir.y = 0;

                    damageable.Damage(damageAmout, dir);
                }

                break;
            }
        }

        Destroy(gameObject);
    }
}
