using Items;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    private Item[] _rewards;

    public void Awake()
    {
        _rewards = GetComponentsInChildren<Item>();
    }

    private void Start()
    {
        HideRewards();
    }

    public void ShowRewards()
    {
        foreach (var reward in _rewards) reward.gameObject.SetActive(true);
    }
    
    public void HideRewards()
    {
        foreach (var reward in _rewards) reward.gameObject.SetActive(false);
    }
}
