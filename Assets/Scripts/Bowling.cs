using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bowling : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int forcePower;



    private bool fired = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBall();
        }
        if (Keyboard.current.aKey.isPressed)
        {
            //MoveLeft();
            WalkLeft();
        }
        if (Keyboard.current.dKey.isPressed)
        {
            //MoveRight();
            WalkRight();
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            ResetPos();
        }
        if (Keyboard.current.wKey.isPressed)
        {
            WalkForward();
        }
        if (Keyboard.current.sKey.isPressed)
        {
            WalkBackward();
        }

    }

    private void ShootBall()
    {
        rb.AddForce(Vector3.forward*forcePower, ForceMode.Impulse);
    }

    private void MoveRight()
    {
       transform.position += new Vector3(1f, 0f, 0f)*Time.deltaTime;
    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime;
    }

    private void ResetPos()
    {
        transform.position = new Vector3(0, 1.25f, -9.21f);
    }

    private void WalkLeft()
    {
        rb.AddForce(-Vector3.right*0.5f, ForceMode.Impulse);
    }
    private void WalkRight()
    {
        rb.AddForce(Vector3.right*0.5f, ForceMode.Impulse);
    }
    private void WalkForward()
    {
        rb.AddForce(Vector3.forward * 0.5f, ForceMode.Impulse);
    }
    private void WalkBackward()
    {
        rb.AddForce(-Vector3.forward * 0.5f, ForceMode.Impulse);
    }
}
