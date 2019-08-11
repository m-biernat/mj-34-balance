using UnityEngine;

public class Controller : MonoBehaviour
{
    [HideInInspector]
    public GameObject controlledObject;

    [SerializeField] private float speed = 0f;

    private Rigidbody rb;

    private float input;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            input = -1f;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            input = 1f;
        }
        else
        {
            input = 0f;
        }

        float pos = controlledObject.transform.localPosition.x;

        if ((input > 0f && pos >= 2.25f) || (input < 0f && pos <= -2.25f))
            input = 0;
    }

    private void FixedUpdate()
    {
        MovePosition(new Vector3(input, 0f, 0f));
    }

    private void MovePosition(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    private void SetRigidbody()
    {
        rb = controlledObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                         RigidbodyConstraints.FreezeRotation;
    }

    public void Setup(GameObject go)
    {
        controlledObject = go;
        SetRigidbody();
    }
}
