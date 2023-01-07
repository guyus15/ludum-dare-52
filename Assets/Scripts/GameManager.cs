using UnityEngine;

[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(EnemyManager))]
public class GameManager : MonoBehaviour
{
    private void Start()
    {
        UIManager.instance.InitialiseUI();
    }
}