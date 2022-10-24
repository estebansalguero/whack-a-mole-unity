using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{   
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Sprite hammerSprite;
    [SerializeField] private Sprite hammerSmashSprite;
    RectTransform rectTransform;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private IEnumerator hammerSmash() {
        spriteRenderer.sprite = hammerSmashSprite;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = hammerSprite;
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(-124, -182);
            gameManager.hammerHit(0); 
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(28, -182);
            gameManager.hammerHit(1);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(180, -182);
            gameManager.hammerHit(2);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(-124, -32);
            gameManager.hammerHit(3);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(28, -32);
            gameManager.hammerHit(4);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(180, -32);
            gameManager.hammerHit(5);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad7))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(-124, 118);
            gameManager.hammerHit(6);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(28, 118);
            gameManager.hammerHit(7);
            StartCoroutine(hammerSmash());
        }
        if (Input.GetKey(KeyCode.Keypad9))
        {
            StopAllCoroutines();
            rectTransform.anchoredPosition = new Vector2(180, 118);
            gameManager.hammerHit(8);
            StartCoroutine(hammerSmash());
        }
    }

    public void resetHammer()
    {
        rectTransform.anchoredPosition = new Vector2(-163, 209);
    }
}
