using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _frontCheck;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _radius = 0.1f;
    //[SerializeField] private LayerMask _Player;
    //[SerializeField] private GameObject popupPrefab;



    private bool _right = true;
    private bool _need = false;
    private float _speedBuf;

    private void Start()
    {
        _speedBuf = _speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_speed, rb.velocity.y);
        CheckFront();
        if (_right)
        {
            _speed = _speedBuf;
        }
        else
        {
            _speed = -_speedBuf;
        }
        if (_need) Flip();
        

    }

    void Flip()
    {
        _need = false;
        _right = !_right;
        transform.Rotate(0, 180, 0);
        rb.velocity = -rb.velocity;
        
    }

    void CheckFront()
    {
        //    _need = Physics2D.OverlapCircle(_rightCheck.position, _radius, _Player);
        Collider2D[] frontColliders = Physics2D.OverlapCircleAll(_frontCheck.position, _radius);
        if (frontColliders.Length == 1)
        {
            _need = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _need = true;
        //Instantiate(popupPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .45f), popupPrefab.transform.rotation);
    }

}
