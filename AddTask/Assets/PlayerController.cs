using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpPower = 100;
    [SerializeField] private float speed = 100;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radius = 1;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private DieMenu die;

    private bool _grounded = false;

    
    void Awake()
    {
        Sleep(2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded) rb.AddForce(new Vector2(rb.velocity.x, jumpPower));
        }
    }

    private void FixedUpdate()
    {
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, _radius, whatIsGround);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (rb.velocity.y < -25f) die.Show();
    }

    IEnumerator Sleep(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _radius);
    }

}