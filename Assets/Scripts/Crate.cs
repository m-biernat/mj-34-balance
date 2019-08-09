using UnityEngine;

public class Crate : MonoBehaviour
{
    private int id;

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().drag = 2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.crateCount != 1 && 
            GameManager.instance.crateCount == id + 1)
        {
            Debug.Log(name);
            StartCoroutine(GameManager.instance.CompleteGame());
        }
    }

    public void Setup()
    {
        GameManager gameManager = GameManager.instance;

        id = gameManager.crateCount++;
        transform.name = id.ToString();

        gameManager.crates.Add(this);

        gameManager.OnCrateCreated();
    }
}
