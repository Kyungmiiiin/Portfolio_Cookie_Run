using UnityEngine;


public class Jelly : MonoBehaviour
{
    [SerializeField] JellyData data;

    private void Awake()
    {   // ��ü ������ ����Ǵ� �Լ�
        //�ش� ������Ʈ���� ��������Ʈ ������ ������Ʈ�� �����´�.
        //���� sprite �Ӽ��� data.icon�� �ִ� ��������Ʈ�� �����Ų��.(�����Ѵ�.)
        //�Ѹ���� �̹����� �����Ѵ�.
        GetComponent<SpriteRenderer>().sprite = data.icon;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(data.point);
        Destroy(gameObject);
    }
}



