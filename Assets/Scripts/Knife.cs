using System;
using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private bool hasHit;

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
        int hitLayerIndex = collision.contacts[0].collider.gameObject.layer;
        if (hitLayerIndex == LayerMask.NameToLayer("Wheel"))
        {
            transform.SetParent(collision.transform);
            collision.transform.parent.GetComponent<WheelController>().AttachKnife();
            hasHit = true;
            StopAllCoroutines();
        }
        else if (hitLayerIndex == LayerMask.NameToLayer("Knife"))
        {
            transform.SetParent(collision.transform);
            hasHit = true;
            StopAllCoroutines();
            LevelController.Instance.LooseLevel();    
            Destroy(gameObject);
        }
        
        else if (hitLayerIndex == LayerMask.NameToLayer("Bonus"))
        {
            LevelController.Instance.SetBonus();
            Destroy(collision.gameObject);
        }
    }
}
