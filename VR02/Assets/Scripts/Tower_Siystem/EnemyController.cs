using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float speedMod = 1.0f;
    public float timeSinceStart = 0.0f;



    private MonsterPath thePath;           //�н� ���� ��
    private int currentPoint;              //�н� ��ġ Ŀ�� ��
    private bool reachedEnd;              //���� �Ϸ� �˻� bool ��

    private bool modEnd = true;

    void Start()
    {
        if (thePath == null)                            //�����Ҷ� Path �� ������
        {
            thePath = FindObjectOfType<MonsterPath>();   //Scene���� ã�´�.
        }
    }

    void Update()
    {
        if(modEnd == false)
        {
            timeSinceStart -= Time.deltaTime;

            if(timeSinceStart <= 0.0f)
            {
                speedMod = 1.0f;
                modEnd = true;
            }
        }
        if(reachedEnd == false)         //���� �Ϸᰡ �ƴ� ���
        {
            transform.LookAt(thePath.points[currentPoint]);  //���� ��ġ Ŀ������ ���ؼ� ����.

            transform.position = Vector3.MoveTowards(transform.position
                , thePath.points[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

            //���� �н� ����Ʈ ��ġ�� �Ÿ��� ����ؼ� 0.01 �����ϰ�� ����
            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1;  //���� ��ġ Ŀ���� �ű��

                if(currentPoint >= thePath.points.Length)  //�� �������� ����
                {
                    reachedEnd = true;
                }
            }
        }
    }

    public void SetMode(float value)
    {
        modEnd = false;
        speedMod = value;
        timeSinceStart = 2.0f;
    }
}
