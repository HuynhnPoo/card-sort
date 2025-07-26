using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandle : MonoBehaviour, IPointerDownHandler
{
    public TypeSlot type = TypeSlot.NORMAL;

    private static bool isEmpyty = true;
    private  bool isBought= false;

    public enum TypeSlot
    {
        NORMAL,
        RESULT
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.Instance.IsSelected)
        {
            if (!isEmpyty && transform.childCount > 0)
            {
                Card firstSelectCard = GameManager.Instance.CardList.FirstOrDefault() as Card;
                // So sánh tên của thẻ con đầu tiên trong slot với thẻ đầu tiên được chọn
                if (transform.GetChild(0).name != firstSelectCard.gameObject.name )
                {
                    Debug.Log("Tên thẻ trong slot khác với tên thẻ đang chọn. Đã hủy thao tác.");
                    // Nếu tên khác nhau, xóa danh sách thẻ đã chọn và thoát
                    GameManager.Instance.CardList.Clear();
                    GameManager.Instance.IsSelected = false;
                    GameManager.Instance.ClearAllHighlights(); // Xóa highlight nếu cần
                    return; // Rất quan trọng: thoát khỏi phương thức để không thêm thẻ
                }

            }

            foreach (var card in GameManager.Instance.CardList)
            {

                card.transform.SetParent(this.gameObject.transform);
                card.transform.position = this.transform.position;
            }
            GameManager.Instance.CardList.Clear();
            GameManager.Instance.IsSelected = false;
            isEmpyty=false;
            GameManager.Instance.ClearAllHighlights();

        }


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (type == TypeSlot.RESULT && transform.childCount>5)
        {
            isEmpyty = (transform.childCount == 0);
            Debug.Log("thuc hien xoa va add diem");

            GameManager.Instance.AddScore(GameManager.Instance.ScoreValue);

            List<GameObject> cardsDestroy = new List<GameObject>();
            foreach (Transform card in transform)
            {
                cardsDestroy.Add(card.gameObject);   
            }

            foreach (GameObject card in cardsDestroy)
            {
                  Destroy(card);
            }
            isEmpyty = false;
        }
    }

    
}
