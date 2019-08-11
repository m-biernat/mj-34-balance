using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnable = null;

    [SerializeField]
    private GameObject trigger = null;

    public static float hue;
    public static float range;

    private void OnEnable()
    {
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {
        Spawn(GeneratePosition());

        MoveTrigger();

        if (GameManager.instance.crateCount > 2)
            GameManager.score++;
        Debug.Log(GameManager.score);

        yield return new WaitForSeconds(GameManager.instance.currentSpawnSpeed);

        StartCoroutine(SpawnSequence());
    }

    public void Spawn(Vector3 position)
    {
        GameObject go = Instantiate(spawnable, transform);

        Renderer rend = go.GetComponent<Renderer>();
        rend.material.SetColor("_BaseColor", Color.HSVToRGB(hue, 0.8f, 0.7f));
        IncrementColor();

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

    private void IncrementColor()
    {
        hue += 0.01f;

        if (hue >= 1f)
            hue = 0f;
    }

    private Vector3 GeneratePosition()
    {
        float position = Random.Range(-range, range);

        if (range < 2.3f && GameManager.instance.crateCount % 10 == 0)
        {
            range += 0.2f;
        }

        return new Vector3(position, 0f, 0f);
    }
}
