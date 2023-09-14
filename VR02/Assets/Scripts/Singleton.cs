using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }          //�ν��Ͻ��� ������ ����

    private void Awake()
    {
        if(Instance == null)                                        //Instance �� NULL�϶�
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);                           //���� ������Ʈ�� Scene�� ��ȯ�ǰ� �ı����� ����
        }
        else
        {
            Destroy(gameObject);                                    //1���� ������Ű�� ���� ������ ��ü�� �ı��Ѵ�.
        }
    }

    public int playerScore = 0;

    public void InscreaseScore(int amount)                           //�Լ��� ���ؼ� ���ھ ������Ų��.
    {
        playerScore += amount;
    }
}
