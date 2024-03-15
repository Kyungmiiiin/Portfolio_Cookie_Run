using UnityEngine;


public class Jelly : PooledObject
{
    [SerializeField] new SpriteRenderer renderer;
    [field: SerializeField] public JellyData data { get; private set; }
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;
     
    private void Awake()
    {   // 객체 생성시 실행되는 함수
        //해당 오브젝트에서 스프라이트 렌더러 컴포넌트를 가져온다.
        //이후 sprite 속성에 data.icon에 있는 스프라이트를 적용시킨다.(참조한다.)
        //한마디로 이미지를 변경한다.
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


