using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private BoxCollider2D standingCollider = null;
    //[SerializeField] private BoxCollider2D sittingCollider = null;
    [SerializeField] private float sprintSpeed = 5;
    [SerializeField] private float runSpeed = 5;
    [SerializeField] private float crouchSpeed = 5;
    [SerializeField] private float jumpPower = 100;
    [SerializeField] private float knockPower = 100;
    [SerializeField] private Transform _groundCheck = null;
    [SerializeField] private Transform _ceilingCheck = null;
    [SerializeField] private float _radius = 1;
    [SerializeField] private playerHP playerHealth;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject reverseBulletPrefab;
    [SerializeField] private LayerMask whatIsGround;

    public Animator anim;

    private float _move;
    private bool _crouching = false;
    private bool _canStand = true;
    private bool _jumping = false;
    private bool _grounded;
    private bool _needToStand = false;
    private bool _faceRight = true;
    private float _speed = 5;
    private bool _fallingHard = false;
    private bool _hitted = false;
    //for LandControl
    private bool _firstTime = true;
    private bool _falling = false;
    private float _previousY;
    private float _highestY;
    
    


    private void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        

        anim.SetFloat("move", Mathf.Abs(_move));


        if (Input.GetButtonUp("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Crouch();
        }

        if (!_grounded && _crouching && rb.velocity.y < 0) _fallingHard = true;
            else _fallingHard = false;

        if (_hitted)
        {
            if (Mathf.Abs(rb.velocity.x) < 1f) _hitted = !_hitted;
        }
    }

    private void FixedUpdate()
    {
        if (!_hitted) rb.velocity = new Vector2(_speed * _move, rb.velocity.y);

        if (_move > 0 && !_faceRight) Flip(); else if (_move < 0 && _faceRight) Flip();

        SpeedControl();

        UpDownCheck();

        if (_jumping)
        {
            if (_grounded) rb.AddForce(new Vector2(rb.velocity.x, jumpPower));

            Stand();
            
            _jumping = false;
        }

        if (_needToStand && _canStand)
        {
            Stand();
            _needToStand = false;
        }

        if (_grounded && _falling)
        {
            if (_highestY - transform.position.y > 3f && _crouching && playerHealth.getHP() > 50f) Shoot();
            _falling = false;
            _firstTime = true;
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            BoxCollider2D otherCollider = other.gameObject.GetComponent<BoxCollider2D>();
            //Vector2 otherCenter = new Vector2 (otherCollider.offset.x + other.transform.position.x, otherCollider.offset.y + other.transform.position.y);
            // 0.2 is approximate size for Player edges.
            if (_fallingHard)
            {
                other.gameObject.GetComponent<enemyHP>().Damage(10f);
                rb.velocity = new Vector2(Random.Range(-knockPower, knockPower) / 2, knockPower / 2);
                playerHealth.Heal(10f);

            }
            else if (transform.position.x + 0.2 + otherCollider.size.x < other.transform.position.x)
            {
                //pushed an enemy from left
                rb.velocity = new Vector2(-knockPower, rb.velocity.y);
                _hitted = true;
                playerHealth.Damage(10f);
            }
            else if (transform.position.x - 0.2 - otherCollider.size.x > other.transform.position.x)
            {
                //pushed from right
                rb.velocity = new Vector2(knockPower, rb.velocity.y);
                _hitted = true;
                playerHealth.Damage(10f);
            }
            else if (transform.position.y - 0.2 - otherCollider.size.y > other.transform.position.y)
            {
                rb.velocity = new Vector2(Random.Range(-knockPower, knockPower), knockPower);
                _hitted = true;
                playerHealth.Damage(10f);
            }
            
        }
    }
    
    private void Shoot()
    {
            if (playerHealth.getHP() <= 60f)
            {
                playerHealth.Damage(playerHealth.getHP() - 50f);
            }
            else playerHealth.Damage(10f);

        Instantiate(bulletPrefab, _ceilingCheck.position, _ceilingCheck.rotation);
        Instantiate(reverseBulletPrefab, _ceilingCheck.position, _ceilingCheck.rotation);

    }

    private void UpDownCheck()
    {
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, _radius, whatIsGround);
        if (!_grounded) LandControl();
        Collider2D[] ceilingColliders = Physics2D.OverlapCircleAll(_ceilingCheck.position, _radius);
        if (ceilingColliders.Length > 1)
        {
            _canStand = false;
        }
        else
        {
            _canStand = true;
        }


    }

    private void Crouch()
    {
        _crouching = true;
        anim.SetBool("crouch", true);
        standingCollider.size = new Vector2(0.55f, 0.15f);
        _groundCheck.localPosition = new Vector3(0, -0.05f);
    }

    private void Stand()
    {
        _crouching = false;
        anim.SetBool("crouch", false);
        standingCollider.size = new Vector2(0.33f, 0.33f);
        _groundCheck.localPosition = new Vector3(0, -0.13f);
    }

    private void Jump()
    {
        if (_grounded && _canStand) _jumping = true; else if (!_canStand) _needToStand = true; else if (!_grounded && _canStand) Stand();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_ceilingCheck.position, _radius);
    }

    private void SpeedControl()
    {
        if (_crouching && _grounded) _speed = crouchSpeed; else if (playerHealth.getHP() == 100f) _speed = sprintSpeed; else _speed = runSpeed;
    }

    private void LandControl()
    {
        if (transform.position.y < _previousY && _firstTime)
        {
            _firstTime = false;
            _falling = true;
            _highestY = _previousY;
        }
        _previousY = transform.position.y;

    }

    private void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }
}
