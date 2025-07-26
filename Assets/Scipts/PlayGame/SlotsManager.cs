using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsManager : MonoBehaviour
{
    private GameObject[] card;
    [SerializeField] Transform[] childElement;

    private void Awake()
    {
        card = Resources.LoadAll<GameObject>(StringInGame.cardStr); // Giả sử StringInGame.cardStr là chuỗi hợp lệ
    }

    void Start()
    {
        childElement = new Transform[transform.childCount];
        int index = 0;
        foreach (Transform child in transform)
        {
            childElement[index] = child;
            index++;
        }

    }

    void Update()
    {
    
    }

    public void Spawning()
    {
        // Debug.Log("hien thi ra ");
        foreach (Transform slot in childElement)
        {
            //// Xóa các object cũ trong slot nếu có
            //foreach (Transform child in slot)
            //{
            //    Destroy(child.gameObject);
            //}

            // if (slot.childCount >6) return;

            if (IsSlotEmpty(slot)) // Use the new method to check the individual slot
            {

                // Tạo danh sách 6 game object
                List<GameObject> objectsToSpawn = new List<GameObject>();

                // Chọn ngẫu nhiên số lượng giống nhau cho set A (2 đến 4)
                int sameCountA = Random.Range(2, 5);
                GameObject prefabA = card[Random.Range(0, card.Length)];

                // Thêm các game object giống nhau cho set A
                for (int i = 0; i < sameCountA; i++)
                {
                    objectsToSpawn.Add(prefabA);
                }

                // Chọn prefab cho set B (phải khác prefabA)
                GameObject prefabB;
                do
                {
                    prefabB = card[Random.Range(0, card.Length)];
                } while (prefabB == prefabA); // Đảm bảo prefabB khác prefabA

                // Thêm các game object giống nhau cho set B
                int remainingCount = 6 - sameCountA;
                for (int i = 0; i < remainingCount; i++)
                {
                    objectsToSpawn.Add(prefabB);
                }

                // Sắp xếp danh sách để các game object giống nhau được nhóm lại
                objectsToSpawn.Sort((a, b) => a.name.CompareTo(b.name));

                float offsetY = 5;
                // Spawn 6 game object với offset Y
                for (int i = 0; i < 6; i++)
                {
                    Vector3 spawnPosition = slot.position + new Vector3(0, i * offsetY, 0);
                    Instantiate(objectsToSpawn[i], spawnPosition, Quaternion.identity, slot);
                }
            }
        }
    }

    // This method will now check if a specific 'slotTransform' is empty
    public bool IsSlotEmpty(Transform slotTransform)
    {
        return slotTransform.childCount == 0;
    }
}