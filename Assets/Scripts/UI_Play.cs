using UnityEngine;

public class UI_Play : MonoBehaviour
{
    [SerializeField]
    private LevelChanger levelChanger = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || 
            Input.GetKeyDown(KeyCode.J))
        {
            AudioHandler.instance.PlayAudioClip(2);
            levelChanger.FadeToLevel(1);
            enabled = false;
        }
    }
}
