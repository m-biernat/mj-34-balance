using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnable = null;

    [SerializeField]
    private GameObject trigger = null;

    private void OnEnable()
    {
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {
        Spawn(Vector3.zero);

        MoveTrigger();

        yield return new WaitForSeconds(GameManager.instance.currentSpawnSpeed);

        StartCoroutine(SpawnSequence());
    }

    public void Spawn(Vector3 position)
    {
        GameObject go = Instantiate(spawnable, transform);

        go.GetComponent<Crate>().Setup();
        go.transform.localPosition = position;
    }

    private void MoveTrigger()
    {
        GameManager gameManager = GameManager.instance;

        if (gameManager.crateCount < 6 && gameManager.crateCount > 1)
        {
            Vector3 pos = trigger.transform.position;

            trigger.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);
        }
    }
}
