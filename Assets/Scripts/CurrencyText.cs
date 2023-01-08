using UnityEngine;

public class CurrencyText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"${CurrencyManager.instance.CurrentAmount}";
    }
}
