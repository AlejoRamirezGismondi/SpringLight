using System.Collections;
using UnityEngine;

public class AnimationTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private static readonly int Start = Animator.StringToHash("Start");

    private void Awake()
    {
        transition = GetComponentInChildren<Animator>();
    }

    public void StartAnimationTransition()
    {
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        transition.SetTrigger(Start);
        yield return new WaitForSeconds(transitionTime);
    }
}
