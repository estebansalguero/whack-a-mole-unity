using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{

    [Header("Graphics")]
    [SerializeField] private Sprite bunny;
    [SerializeField] private Sprite bunny2;
    [SerializeField] private Sprite log;
    [SerializeField] private Sprite bomb;
    [SerializeField] private Sprite mole;
    [SerializeField] private Sprite mole2;
    [SerializeField] private Sprite mole3;
    [SerializeField] private Sprite mole4;
    [SerializeField] private Sprite mole5;
    [SerializeField] private Sprite mole6;
    [SerializeField] private Sprite mole7;
    [SerializeField] private Sprite hit;
    
    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    [Header("Mole")]
    private Vector2 startPositon = new Vector2(0f, -150f);
    private Vector2 endPosition = Vector2.zero;
    private SpriteRenderer spriteRenderer;
    private float showDuration = 1f;
    private float hideDuration = 2f;
    private Sprite[] sprites;

    private bool hittable = true;
    private int moleIndex = 0;
    private bool isMole = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = new Sprite[] { bunny, bunny2, log, bomb, mole, mole2, mole3, mole4, mole5, mole6, mole7 };
    }

    public void setIndex(int index)
    {
        moleIndex = index;
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Move the mole to the start position
        transform.localPosition = start;
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        if (spriteRenderer.sprite.name == "3" || spriteRenderer.sprite.name == "5" || spriteRenderer.sprite.name == "6" || spriteRenderer.sprite.name == "7" || spriteRenderer.sprite.name == "8" || spriteRenderer.sprite.name == "9" || spriteRenderer.sprite.name == "10")
        {
            isMole = true;
        }
        else
        {
            isMole = false;
        }

        // Move the mole to the start position
        transform.localPosition = start;

        // show the mole
        float elapsedTime = 0f;
        while (elapsedTime < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, (elapsedTime / showDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Move at the end
        transform.localPosition = end;

        // Wait for a bit
        yield return new WaitForSeconds(hideDuration);

        // Hide the mole
        elapsedTime = 0f;
        while (elapsedTime < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, (elapsedTime / showDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Move at the start
        transform.localPosition = start;

        if (hittable)
        {
            gameManager.Missed(isMole);
        }
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        // Start the coroutine again
        StartCoroutine(ShowHide(start, end));
    }
    void Start()
    {
        Activate();
    }

    public void Activate()
    {
        CreateNextMole();
        StartCoroutine(ShowHide(startPositon, endPosition));
    }

    private IEnumerator quickHide()
    {
        yield return new WaitForSeconds(0.25f);
        if (!hittable)
        {
            Hide();
        }
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        // Start the coroutine again
        CreateNextMole();
        StartCoroutine(ShowHide(startPositon, endPosition));
    }

    public void Hit()
    {
        spriteRenderer.sprite = hit;
        if (hittable)
        {
            if (isMole)
            {
                gameManager.AddScore(5);
                gameManager.UpdateScore();
            }
            else if (spriteRenderer.sprite.name == "4")
            {
                gameManager.AddScore(-10);
                gameManager.addError();
                gameManager.updateErrors();
                gameManager.UpdateScore();
            }
            else
            {
                gameManager.AddScore(-2);
                gameManager.addError();
                gameManager.updateErrors();
                gameManager.UpdateScore();
            }
            StopAllCoroutines();
            StartCoroutine(quickHide());
            hittable = false;
        }
    }

    public void Hide()
    {
        transform.localPosition = startPositon;
    }

    private void CreateNextMole()
    {
        hittable = true;
    }

    public void Stop()
    {
        StopAllCoroutines();
        Hide();
    }

}
