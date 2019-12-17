using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum type
    {
        Single,
        AOE,
        Freeze,
        Slow
    }

    public type current;

    public LayerMask collisionLayer;

    public float myBulletTimer;
    public float bulletForce;

    public int singleDam;
    public int AOEDam;
    public int AOERadius;
    public int damage;

    Rigidbody bulletRb;

    Transform target;

    Vector3 direction;

    private IEnumerator Start()
    {
        bulletRb = GetComponent<Rigidbody>();

        direction = (target.position - transform.position);

        bulletRb.AddForce(bulletForce * direction);

        yield return new WaitForSeconds(myBulletTimer);

        Destroy(gameObject);
    }

    void Update()
    {
        
    }

    void Target(Transform target)
    {
        this.target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            switch (current)
            {
                case type.Single:
                    {
                        damage = singleDam;
                        target.SendMessage("Damage", damage);
                    }
                        break;

                case type.AOE:
                    {
                        damage = AOEDam;

                        var cols = Physics.OverlapSphere(transform.position, AOERadius, collisionLayer);

                        for (int i = 0; i < cols.Length; i++)
                        {
                            if (cols[i].gameObject.GetComponentInParent<Enemy>())
                            {
                                cols[i].SendMessage("Damage", damage);
                            }
                        }
                    }
                    break;

                case type.Freeze:
                    {
                        damage = singleDam / 2;
                        target.SendMessage("Freeze", damage);
                    }
                    break;

                case type.Slow:
                    {
                        damage = AOEDam / 2;

                        var cols = Physics.OverlapSphere(transform.position, AOERadius, collisionLayer);

                        for (int i = 0; i < cols.Length; i++)
                        {
                            if (cols[i].gameObject.GetComponentInParent<Enemy>())
                            {
                                cols[i].SendMessage("Slow", damage);
                            }
                        }
                    }
                    break;
            }

            Destroy(gameObject);
        }
    }
}