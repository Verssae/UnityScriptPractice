using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public float jumpSpeed = 30;
    new Rigidbody2D rigidbody;
    

    private float h = 0f;
    private int space;
    private bool isGround;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            space = 1;
        } else
        {
            space = 0;
        }
    }

    void FixedUpdate()
    {
        // 물리 계산
        
        rigidbody.AddForce(new Vector2(speed * h, jumpSpeed*space));
        
        if (Mathf.Abs(rigidbody.velocity.x) > 7.0f)
        {

            rigidbody.velocity = new Vector2(7.0f * rigidbody.velocity.x / Mathf.Abs(rigidbody.velocity.x), rigidbody.velocity.y);
        }
        Debug.Log(rigidbody.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }


}
