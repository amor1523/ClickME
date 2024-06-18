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

    // TMI: ����Ʈ�� Serialize ���� / Dictionary�� �Ұ���
    public List<Pool> pools = new List<Pool>();

    // Queue�� �̿��� ���Լ���� ���� ���� ������ ������Ʈ�� ������ش�.
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // transform�� ���ָ� ObjectPool.cs �� ���ִ� GameManager�� �ڽ� ������Ʈ�� �����ȴ�.
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj); // �ϴ� Instantiate�� �������⸸ �ϰ� SetActive�� ��Ȱ��ȭ, Queue�� �ִ´�.
            }

            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            // �������� �ʴ� Dictionary�� �������� ����
            return null;
        }

        // Dequeue�� �����ͼ� ��� �� Enqueue�� �ݳ�
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);

        return obj;
    }
}
