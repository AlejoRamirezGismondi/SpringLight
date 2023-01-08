using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public interface ISceneObserver
    {
        void OnSceneAboutToChange();
    }

    [SerializeField] private int sceneBuildIndex;
    private readonly List<ISceneObserver> _observers = new();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        foreach (var observer in _observers)
            observer.OnSceneAboutToChange();
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void AddObserver(ISceneObserver observer)
    {
        _observers.Add(observer);
    }
}