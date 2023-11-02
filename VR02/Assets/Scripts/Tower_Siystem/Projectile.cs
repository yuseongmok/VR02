using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;                   //���ο��� ����� rb

    public float moveSpeed;                 //�̵��ӵ�
    public float damagedAmount;             //������ ��
    private bool hasDamaged;                //flag����

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;                //rb�� ���� �������� �Ѿ� �̵� �ӵ��� �Է�
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage((int)damagedAmount);   //������ ��� �߰�
            hasDamaged = true;
        }

        Destroy(gameObject);                                        //Trigger �浹�� �Ͼ�� �ı�
    }
}
