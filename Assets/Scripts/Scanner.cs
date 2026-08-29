using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    GameObject pinPosition;
    [SerializeField]
    GameObject pinGroup;
    [SerializeField]
    GameObject prefabPin;

    public static Scanner instance;
    public int currentStanding = 0;
    private int maxStanding = 10;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        transform.position += new Vector3 (0, -1, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        currentStanding++;
        UIManager.instance.UpdateScore(maxStanding - currentStanding);
    }

    private void OnTriggerExit(Collider collision)
    {
        currentStanding--;
        UIManager.instance.UpdateScore(maxStanding - currentStanding);
    }

    public void PlacePin()
    {
        for (int i = pinGroup.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(pinGroup.transform.GetChild(i).gameObject);
        }
        currentStanding = 0;

        foreach (Transform pos in pinPosition.transform)
        {
            GameObject pin = Instantiate(prefabPin, pos.position, Quaternion.identity);
            pin.transform.SetParent(pinGroup.transform);
        }
        
    }
}
