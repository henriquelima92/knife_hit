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
            collision.transform.parent.GetComponent<WheelController>().AttachKnife();
        }
        else if(hitLayerIndex == LayerMask.NameToLayer("Knife"))
        {
            LevelController.Instance.LooseLevel();
        }
        else if (hitLayerIndex == LayerMask.NameToLayer("Bonus"))
        {
            //bonus collected event
        }
    }
}
