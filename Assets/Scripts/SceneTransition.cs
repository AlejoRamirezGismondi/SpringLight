using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}