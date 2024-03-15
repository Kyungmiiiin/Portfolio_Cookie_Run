using UnityEngine;


public class Jelly : PooledObject
{
    [SerializeField] new SpriteRenderer renderer;
    [field: SerializeField] public JellyData data { get; private set; }
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
        IScore player = collision.GetComponent<IScore>();
        player.GetScore(data.point, true);
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


