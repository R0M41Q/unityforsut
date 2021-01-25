using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //[SerializeField] private Vector3 massCenter;
    protected Rigidbody2D r;




    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(transform.localScale.x * 3f, transform.up.y * 5f);
    }

    void FixedUpdate()
    {
        //r.centerOfMass = massCenter;
        //gameObject.transform.forward = Vector3.Slerp(gameObject.transform.forward, r.velocity.normalized, Time.deltaTime);
        //r.AddForce(new Vector2(r.velocity.x + 1f, r.velocity.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemyHP>().Damage(10f);
        }
        if (other.gameObject.tag != "Player")
        Destroy(gameObject);



    }

        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position + transform.rotation * massCenter, 0.1f);
    }
}
