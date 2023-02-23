using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class TransitionLoader : MonoBehaviour
    {
        public Animator transition;
        public float transitionTime = 1f;
        private static readonly int Start = Animator.StringToHash("Start");

        public void StartTransition(string sceneName)
        {
            StartCoroutine(StartAnimation(sceneName));
        }

        private IEnumerator StartAnimation(string sceneName)
        {
            transition.SetTrigger(Start);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}