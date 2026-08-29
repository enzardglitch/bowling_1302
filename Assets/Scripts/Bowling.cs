using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bowling : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int forcePower;

    public static int rounds = 0;
    public static int scores = 0;

    [SerializeField]
    private GameObject counter;


    private bool fired = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadScore();
        UIManager.instance.UpdateRound(rounds, scores);
        Scanner.instance.PlacePin();
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
            MoveLeft();
            //WalkLeft();
        }
        if (Keyboard.current.dKey.isPressed)
        {
            MoveRight();
            //WalkRight();
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }

    }

    public void ShootBall()
    {
        if (fired)
        { return;  }
        fired = true;
        rb.AddForce(Vector3.forward*forcePower, ForceMode.Impulse);
    }

    private void MoveRight()
    {
        if (fired)
        { return; }
        transform.position += new Vector3(2f, 0f, 0f)*Time.deltaTime;
    }

    private void MoveLeft()
    {
        if (fired)
        { return; }
        transform.position += new Vector3(-2f, 0f, 0f) * Time.deltaTime;
    }

    private void RestartGame()
    {
        fired = false;
        transform.position = new Vector3(0, 1.25f, -9.21f);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        scores += 10-counter.gameObject.GetComponent<Scanner>().currentStanding;
        rounds++;
        SaveScore();
        UIManager.instance.UpdateRound(rounds, scores);
        Scanner.instance.PlacePin();
    }

    private void LoadScore()
    {
        rounds = PlayerPrefs.GetInt("rounds", 0);
        scores = PlayerPrefs.GetInt("scores", 0);
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("rounds", rounds);
        PlayerPrefs.SetInt("scores", scores);
    }
}
