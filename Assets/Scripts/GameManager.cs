using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
