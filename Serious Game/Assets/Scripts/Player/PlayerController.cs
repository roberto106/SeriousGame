using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    CharacterController controller;
    public float speed;
    private Rigidbody rb;
    float horizontalMove;
    float verticalMove;
    bool flip=true;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GameObject.Find("StartPosition") != null)
            transform.localPosition = GameObject.Find("StartPosition").transform.position;
        else
            Debug.Log("no existe");

    }

    public void Update()
    {
        verticalMove = Input.GetAxis("Vertical") * speed;
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        _animator.SetFloat("SpeedUp", Mathf.Abs(verticalMove));

        if (horizontalMove < 0 && flip)
            turnSprite();
        else if (horizontalMove > 0 && !flip)
            turnSprite();
        //Debug.Log("x: "+transform.position.x);
        //Debug.Log("y: " + transform.position.y);
        //Debug.Log("z: " + transform.position.z);

        //Vector3 movement = new Vector3(-moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed);
    }

    private void turnSprite() {
        flip = !flip;
        transform.Rotate(Vector3.up * 180);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(-verticalMove * Time.fixedDeltaTime, 0.0f, horizontalMove * Time.fixedDeltaTime);
        rb.AddForce(movement * speed);
    }
}
