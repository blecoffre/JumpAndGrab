using UnityEngine;

public class Item : MonoBehaviour
{
    public bool IsRotating = false;
    public bool IsFloating = false;

    public float RotatingSpeed = 3.0f;
    public float FloatingSpeed = 3.0f;

    public float DistanceFromGround = 2.0f;
    public float FloatingAmplitude = 0.5f;
    public float FloatingFrequency = 1.0f;

    Vector3 startPos;

    private void Awake()
    {
        CheckDistanceFromGround();
        startPos = transform.position;
    }

    void Start()
    {

    }

    void Update()
    {
        Rotate();
        Float();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * RotatingSpeed * Time.deltaTime);
    }

    Vector3 tempPos;
    private void Float()
    {
        // Float up/down with a Sin()
        tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * FloatingFrequency) * FloatingAmplitude;

        transform.position = tempPos;
    }

    private void CheckDistanceFromGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 100.0f)) 
        {
            if (hit.transform.tag == "Ground" && Vector3.Distance(transform.position, hit.transform.position) != DistanceFromGround)
            {
                float distance = hit.normal.y * DistanceFromGround;
                transform.position = new Vector3(transform.position.x, hit.transform.position.y + distance, transform.position.z);
            }
        }
    }
}
