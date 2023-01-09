using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    float distanceFromTarget;
    CircleCollider2D collider;
    int _damagePerBullet = 25;
    float _currentTime = 0.0f;
    float _currentShootPeriod = 0.5f;
    private float _bulletVisibilityDuration = 0.3f;
    private LineRenderer _lineRenderers;
    void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
        _lineRenderers = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            target = collision.gameObject;
            
            distanceFromTarget = Vector3.Distance(target.transform.position, gameObject.transform.position);
            if (distanceFromTarget > collider.radius) //If the current target exits range of collider
            {
                target = null; //Reset target to null
                _lineRenderers.enabled = false; //Remove line renderers
            }
            else
            {
                if (_currentTime >= _currentShootPeriod)
                {
                    _currentTime = 0.0f; //Reset timer
                    handleShoot(); //Shoot
                    _lineRenderers.SetPosition(0, gameObject.transform.position);
                    _lineRenderers.SetPosition(1, target.transform.position);
                    _lineRenderers.enabled = true;
                }
                else
                {
                    _currentTime += Time.deltaTime;
                }
            }
            target = null;
        }
    }

    private void handleShoot()
    {
        Vector2 shotDirection = (target.transform.position - gameObject.transform.position).normalized;

        // Checks to see if the hit object is a physics object (i.e. has a Rigidbody2D component).
        RaycastHit2D hitInfo = Physics2D.Raycast(gameObject.transform.position, shotDirection);

        if (hitInfo)
        {
            Rigidbody2D objectRigidbody = hitInfo.collider.GetComponent<Rigidbody2D>() ?? null;

            if (objectRigidbody != null)
                objectRigidbody.AddForce(shotDirection.normalized * 1, ForceMode2D.Impulse);

            IDamagable objectDamagable = target.GetComponent<IDamagable>();

            // Removes health to any IDamagable object we might hit.
            objectDamagable?.RemoveHealth(_damagePerBullet);
        }
        
    }

    public void ClearAllLineRenderers()
    {
        // Disables all line renderers
        if (_lineRenderers == null) return;
        
        _lineRenderers.enabled = false;
        
    }
}
