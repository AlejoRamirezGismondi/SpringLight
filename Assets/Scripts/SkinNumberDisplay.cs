using TMPro;
using UnityEngine;

public class SkinNumberDisplay : MonoBehaviour
{
    [SerializeField] private SkinManager _skinManager;
    private TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{_skinManager.GetCurrentSkinNumber() + 1} / {_skinManager.GetTotalSkins()}";
    }
}
