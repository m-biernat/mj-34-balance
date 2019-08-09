using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Camera cam = null;

    [HideInInspector] public List<Crate> crates;
    public int crateCount;

    public static int score;

    [SerializeField] private Spawner spawner = null;

    [SerializeField] private float spawnerDelay = 0f;

    [SerializeField] private float startingSpawnSpeed = 0f;
    public float currentSpawnSpeed = 0f;

    private Controller controller;

    private void Start()
    {
        if (instance == null)
            instance = this;

        crates = new List<Crate>();
        crateCount = 0;

        score = 0;

        currentSpawnSpeed = startingSpawnSpeed;

        controller = GetComponent<Controller>();

        spawner.Spawn(new Vector3(0f, -14f, 0f));
        controller.Setup(crates[0].gameObject);
        StartCoroutine(EnableSpawner());
    }

    private IEnumerator EnableSpawner()
    {
        yield return new WaitForSeconds(spawnerDelay);

        spawner.enabled = true;
    }

    public void OnCrateCreated()
    {
        if (crateCount > 5)
        {
            controller.Setup(crates[1].gameObject);
            Destroy(crates[0].gameObject);
            crates.Remove(crates[0]);
        }
        else if (crateCount == 5)
        {
            StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        Transform camTransfrom = cam.transform;

        for (int i = 0; i < 200; i++)
        {
            Vector3 pos = camTransfrom.position;

            camTransfrom.position = new Vector3(pos.x, pos.y + 0.01f, pos.z);

            yield return new WaitForSeconds(0.005f);
        }
    }

    public IEnumerator CompleteGame()
    {
        yield return new WaitForSeconds(0.25f);

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
