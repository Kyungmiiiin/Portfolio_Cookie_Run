using UnityEngine;


public class Jelly : PooledObject
{
    [SerializeField] new SpriteRenderer renderer;
    [SerializeField] JellyData data;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;
     
    private void Awake()
    {   // ��ü ������ ����Ǵ� �Լ�
        //�ش� ������Ʈ���� ��������Ʈ ������ ������Ʈ�� �����´�.
        //���� sprite �Ӽ��� data.icon�� �ִ� ��������Ʈ�� �����Ų��.(�����Ѵ�.)
        //�Ѹ���� �̹����� �����Ѵ�.
        renderer.sprite = data.icon;
    }

                                                                                                                                                                                                                                              
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Release();
    }

    public void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }
}

