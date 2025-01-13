using UnityEngine;

public class Level : MonoBehaviour
{
    public float Speed = -10f;
    public float deadZone = -20f;
    Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }
    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0f);

        if(transform.position.x < deadZone)
        {
            transform.position = initPosition;
        }
    }
}
