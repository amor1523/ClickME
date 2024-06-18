using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    // TMI: 리스트는 Serialize 가능 / Dictionary는 불가능
    public List<Pool> pools = new List<Pool>();

    // Queue를 이용해 선입선출로 제일 먼저 생성된 오브젝트를 출력해준다.
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // transform을 써주면 ObjectPool.cs 가 들어가있는 GameManager의 자식 오브젝트로 생성된다.
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj); // 일단 Instantiate로 만들어놓기만 하고 SetActive로 비활성화, Queue에 넣는다.
            }

            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            // 존재하지 않는 Dictionary는 생성하지 않음
            return null;
        }

        // Dequeue로 꺼내와서 사용 후 Enqueue로 반납
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);

        return obj;
    }
}
