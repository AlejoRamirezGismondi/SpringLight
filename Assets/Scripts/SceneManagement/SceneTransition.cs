using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneTransition : MonoBehaviour
    {
        public interface ISceneObserver
        {
            void OnSceneAboutToChange();
        }

        [Header("Connected To:")] [SerializeField] private string sceneName;
        [SerializeField] private GameObject startingPosition;
        private readonly List<ISceneObserver> _observers = new();
        private PlayerController _player;
        private TransitionLoader _transitionLoader;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _transitionLoader = FindObjectOfType<TransitionLoader>();
            if (LastSceneSaver.LastSceneName == sceneName)
                StartCoroutine(Teleporter.Teleport(_player, startingPosition.transform.position));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            foreach (var observer in _observers)
                observer.OnSceneAboutToChange();
            LastSceneSaver.LastSceneName = SceneManager.GetActiveScene().name;
            _transitionLoader.StartTransition(sceneName);
        }

        public void AddObserver(ISceneObserver observer)
        {
            _observers.Add(observer);
        }
    }
}
