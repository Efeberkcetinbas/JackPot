using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KnifeMove : MonoBehaviour
{
    public float speed=50;

    private Rigidbody rb;


    public bool canDamage=true;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        //StartCoroutine(DestroyBullet(15));
        JumpXAxis(360);
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

    private void JumpXAxis(float rot)
    {
        //Get Child 0 Rotate Et
        transform.GetChild(0).transform.DORotate(new Vector3(rot,0,0),0.5f, RotateMode.FastBeyond360);
    }
}
