using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ʸ� �������� Class ����
public class GenericContainer<T>
{
    private T[] items;                 //Ŀ���� �迭  
    private int currentlndex = 0;      //item ���� ��ȣ

    public GenericContainer(int capacity)     //�����ɶ� �迭 ���� ����
    {
        items = new T[capacity];            //�Լ��� ���ؼ� �޾ƿͼ� �迭 ����
    }

    public void Add(T item)
    {
        if(currentlndex < items.Length)
        {
            items[currentlndex] = item;     //���� �������� ��ȣ�� ���ؼ� �迭�� �ִ´�.
            currentlndex++;
        }
    }

    public T[] GetItems()
    {//������ �迭�� Return ��
        return items;
    }
}
