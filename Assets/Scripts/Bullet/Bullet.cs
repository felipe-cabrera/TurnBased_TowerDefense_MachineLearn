using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float moveSpeed = 7f; // Move speed of this bullet
    Rigidbody2D rb; // Our RigidBody2D property
    GameObject target; // Our target
    Vector2 moveDirection; // The direction to shot
    public TowerController tower; // The main tower (we will get it's Type and Target)

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        target = tower.target.gameObject; // Set the target to be the same as tower target

        // Check if it's null
        //  if it's: We will destroy this bullet (no target available)
        //  if it's not: We will shot o the target
        if (target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(gameObject, 3f);
        }
        else
        {

            Destroy(this);
        }
    }

    // When we enter on a trigger "Touch some object"
    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
            if ((int)this.GetComponent<BulletTypes>().BulletType == (int)col.GetComponent<EnemyTypes>().RealEnemyType)
                col.GetComponent<EnemyController>().DamageTheEnemy(true);
            else
                col.GetComponent<EnemyController>().DamageTheEnemy(false);
        }
    }
}
