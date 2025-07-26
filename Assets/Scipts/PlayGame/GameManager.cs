using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq; // Thêm thư viện này cho LINQ (OrderByDescending, Distinct)

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Card selectedCard = null; // Card đang được chọn

    private int scoreValue = 10;
    public int ScoreValue => scoreValue;

    private int score = 0;
    public int Score
    {
        get => score; set
        {
            score = value;
            PlayerPrefs.SetInt("Score", score); // Lưu lại mỗi khi thay đổi
            PlayerPrefs.Save();
        }
    }

    private static bool isSelected = false;
    public bool IsSelected { get => isSelected; set => isSelected = value; }


    private static bool isPaused = false;
    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private List<Card> cardList = new List<Card>();

    public List<Card> CardList { get => cardList; }

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       // score = PlayerPrefs.GetInt("Score", 1000); // mặc định là 1000 nếu chưa có
        score = PlayerPrefs.GetInt("Score", 0); // mặc định là 0 nếu chưa có
    }

    public void HandleCardClick(Card clickedCard, PointerEventData eventData)
    {

        ClearAllHighlights();

        selectedCard = clickedCard;
        selectedCard.SetHighlight(true);

        Debug.Log($" card dã chon: {clickedCard.gameObject.name}");

        // --- Logic kiểm tra card bên dưới ---
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);


        // Lấy tất cả các Card object từ kết quả raycast, loại bỏ Card vừa click
        var cardsUnderneath = results
            .Where(result => result.gameObject.GetComponent<Card>() != null && result.gameObject != clickedCard.gameObject)
            .Select(result => result.gameObject.GetComponent<Card>())
            .Distinct() // Đảm bảo chỉ có một instance của mỗi Card
            .ToList();


        Debug.Log($"sô lượng thể trogn card : {cardsUnderneath.Count}");
        cardList.Add(selectedCard);

        foreach (Card card in cardsUnderneath)
        {
            if (clickedCard.gameObject.name == card.gameObject.name)
            {
                Debug.Log("hien thi ra " + card.gameObject.name);

                cardList.Add(card);

                card.SetHighlight(true);

            }
        }

    }

    public void ClearAllHighlights()
    {
        // Tìm tất cả các đối tượng có component Card trong cảnh
        Card[] allCards = FindObjectsOfType<Card>();
        foreach (Card card in allCards)
        {
            // Tắt highlight cho từng thẻ
            card.SetHighlight(false);
        }
        // Đặt lại selectedCard về null sau khi đã xóa highlight
        selectedCard = null;
    }

    public void PauseGame(GameObject pauseGame)
    {
        isPaused = true;
        pauseGame.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumseGame(GameObject pauseGame)
    {
        isPaused = false;
        pauseGame.SetActive(false);
        Time.timeScale = 1;
    }
    public void AddScore(int score)
    {
        this.score += score;
        PlayerPrefs.SetInt("Score", this.score); // Lưu lại
        PlayerPrefs.Save(); // Bắt buộc với WebGL
    }
}