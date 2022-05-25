using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 __startPosition;
    Rigidbody2D _Rigidbody2D;
    SpriteRenderer _SpriteRenderer;
    [SerializeField] float _launchSpeed = 500;
    [SerializeField] float maxDistance = 5;
    void Start()
    {
        __startPosition = _Rigidbody2D.position;
        _Rigidbody2D.isKinematic = true;
        _SpriteRenderer = GetComponent<SpriteRenderer>();


    }
    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnMouseDown()
    {
        _SpriteRenderer.color = Color.red;
    }
     void OnMouseUp()
    {
       
        
        Vector2 currentPosition = _Rigidbody2D.position;
        Vector2 direction = __startPosition - currentPosition;
        direction.Normalize();
        _Rigidbody2D.isKinematic = false;
        _Rigidbody2D.AddForce(direction * _launchSpeed);
        _SpriteRenderer.color = Color.white;
    }
     void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;
       
        float distance = Vector2.Distance(desiredPosition, __startPosition);
        if (distance > maxDistance)
        {
            Vector2 direction = desiredPosition - __startPosition;
            direction.Normalize();
            desiredPosition = __startPosition + (direction * maxDistance);
        }
        if (desiredPosition.x > __startPosition.x)
            desiredPosition.x = __startPosition.x;

        _Rigidbody2D.position = desiredPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
        
    }
    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _Rigidbody2D.position = __startPosition;
        _Rigidbody2D.isKinematic = true;
        _Rigidbody2D.velocity = Vector2.zero;
    }
}
