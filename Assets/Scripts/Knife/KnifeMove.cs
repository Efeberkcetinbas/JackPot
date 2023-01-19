using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour
{
    public float speed=50;

    private Rigidbody rb;

    public bool canDamage=true;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        //StartCoroutine(DestroyBullet(15));
    }
    void Update()
    {
        rb.velocity=speed*transform.forward;
    }

    private IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        canDamage=true;
    }
}
