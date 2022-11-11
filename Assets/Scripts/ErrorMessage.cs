using TMPro;

public class ErrorMessage : NetworkErrorHandler
{
    private TextMeshProUGUI _text;
    
    private void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        _text.text = "";
    }

    public override void HandleError(string error)
    {
        _text.text = error;
    }
}