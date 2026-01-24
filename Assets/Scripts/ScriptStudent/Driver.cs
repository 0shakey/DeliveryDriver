using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public bool boostActivated;
    public float remainingTime = 5.0f;    
    public float moveSpeed = 0.0f;
    public float rotateSpeed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Countdown();   
        Steer();
    }

    public void Steer()
    {
        float steerAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);       
    }

    public void Countdown()
    {
        if (boostActivated && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

        }
        else if (boostActivated)
        {
            boostActivated = false;
            moveSpeed = 10.0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger");
        if (collision.gameObject.tag.Equals("Boost"))
        {
            if (!boostActivated)
            {
                moveSpeed = moveSpeed * 2;
            }
            boostActivated = true;
            remainingTime = 5.0f;       
            Debug.Log("Boost Activated");
            collision.gameObject.SetActive(false);
        }
    }

}
