using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider2D))]
public class Detector : MonoBehaviour
{
    public UnityEvent<Collider2D, GameObject> onTriggerEnter;
    public UnityEvent<Collider2D, GameObject> onTriggerStay;
    public UnityEvent<Collider2D, GameObject> onTriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter?.Invoke(other, other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        onTriggerStay?.Invoke(other, other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit?.Invoke(other, other.gameObject);
    }
}