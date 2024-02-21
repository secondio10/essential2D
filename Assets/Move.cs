using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour

{

    Rigidbody2D rb;
    [SerializeField] float fallMultiplier;
    [SerializeField] int jumpPower;
    Vector2 vecGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        //Move the character
        transform.Translate(Input.GetAxis("Horizontal")* 15f *Time.deltaTime,0f,0f);

        //Flip Char:
        Vector3 characterScale = transform.localScale;

        if(Input.GetAxis("Horizontal") < 0){
            characterScale.x = -10;
        }
        if(Input.GetAxis("Horizontal") > 0){
            characterScale.x = 10;
        }
        transform.localScale = characterScale;

        if(Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(rb.velocity.y < 0){
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }
}
