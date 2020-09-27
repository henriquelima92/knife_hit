using System;
using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Action OnHit;

    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private bool hasHit;
    [SerializeField]
    private BoxCollider2D boxCollider;

    public void KnifeSetup()
    {
        hasHit = false;
        boxCollider.enabled = true;
    }
    public bool GetHasHit()
    {
        return hasHit;
    }
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
        StopAllCoroutines();
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
