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
        input = Input.GetAxisRaw("Horizontal");
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
