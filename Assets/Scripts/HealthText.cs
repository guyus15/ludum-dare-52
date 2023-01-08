using UnityEngine;

public class HealthText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _text;

    private void Awake()
    {
        EventManager.AddListener<PlayerHitEvent>(UpdateTextHit);
        EventManager.AddListener<PlayerGainHealthEvent>(UpdateTextGainHealth);
    }

    void Start()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void UpdateTextHit(PlayerHitEvent evt)
    {
        UpdateText(evt.currentHealth);
    }

    private void UpdateTextGainHealth(PlayerGainHealthEvent evt)
    {
        UpdateText(evt.currentHealth);
    }

    private void UpdateText(int value)
    {
        _text.text = $"Health: {value}";
    }
}
