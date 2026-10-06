using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [Header("Scene to load when the player steps here (empty = quit game)")]
    public string nextScene = "Enemies";

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (string.IsNullOrEmpty(nextScene))
        {
            Debug.Log("Game over");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
