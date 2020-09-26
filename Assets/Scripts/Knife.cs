using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private bool hasHit = false;
    public IEnumerator Throw()
    {
        while(hasHit == false)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        StopCoroutine(Throw());
        int hitLayerIndex = collision.gameObject.layer;

        if (hitLayerIndex == LayerMask.NameToLayer("Wheel"))
        {
            transform.SetParent(collision.transform);
            //attached knife event
        }
        else if(hitLayerIndex == LayerMask.NameToLayer("Knife"))
        {
            //loose level event
        }
        else if (hitLayerIndex == LayerMask.NameToLayer("Bonus"))
        {
            //bonus collected event
        }
    }
}
