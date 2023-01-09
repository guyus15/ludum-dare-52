using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RadiusVisualiser : MonoBehaviour
{
    [SerializeField] private float _radius;

    private int _segments = 50;
    private LineRenderer _line;

    void Awake()
    {
        _line = GetComponent<LineRenderer>();

        _line.positionCount = _segments + 1;
        _line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float angle = 20f;

        for (int i = 0; i < (_segments + 1); i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * _radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * _radius;

            _line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / _segments);
        }
    }

    public void SetRadius(float radius)
    {
        _radius = radius;
    }

    public void SetColour(Color colour)
    {
        _line.startColor = colour;
        _line.endColor = colour;
    }
}