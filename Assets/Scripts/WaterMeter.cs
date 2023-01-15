using Items.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class WaterMeter : MonoBehaviour
{
    [SerializeField] private WaterCanToolObject waterCanToolObject;
    [SerializeField] private float water = 0;
    private Image _waterMeter;


    // Start is called before the first frame update
    void Start()
    {
        _waterMeter = GetComponent<Image>();
        UpdateWater(0, 1);
        waterCanToolObject.AddWaterMeter(this);
    }

    public void UpdateWater(int amount, int maxWater)
    {
        water = amount;
        _waterMeter.fillAmount = water / maxWater;   
    }
}
