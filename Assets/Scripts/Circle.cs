using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Circle : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D coll;
    AudioSource myAudio;

    SpriteRenderer mySprite;
    //public GameObject selectedSkin;
    public List<Sprite> skins = new List<Sprite>();
    private Sprite playerSprite;

    public static bool controlIsOff = true;
    public float timeRemaining = 30f;
    bool timerIsRunning = false;
    public TMP_Text timeText;

    public GameObject panel;
    //[HideInInspector]
    public bool objIsMovable;

    TrailRenderer myTailRenderer;
    public GameObject bounceParticle;

    float delay = 3f;
    float threshold = .01f;
    public GameObject overlayCanvas;
    bool audioHasPlayed = false;

    RetryCount counter;
    public SceneFader fader;

    void Start()
    {
        timerIsRunning = true;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        myAudio = GetComponent<AudioSource>();

        mySprite = GetComponent<SpriteRenderer>();
        //playerSprite = selectedSkin.GetComponent<SpriteRenderer>().sprite;
        playerSprite = skins[PlayerPrefs.GetInt("ChoosenSkin")];
        mySprite.sprite = playerSprite;

        coll.enabled = false;

        myTailRenderer = GetComponent<TrailRenderer>();
        if (mySprite.sprite.name == "default")
        {
            myTailRenderer.startColor = new Color(0.5019608f, 0.7960785f, 0.9960785f);
            myTailRenderer.endColor = Color.white;
        }
        else if (mySprite.sprite.name == "smile")
        {
            myTailRenderer.startColor = Color.yellow;
            myTailRenderer.endColor = Color.black;
        }
        else if (mySprite.sprite.name == "Keeg")
        {
            myTailRenderer.startColor = new Color(0 / 255f, 128 / 255f, 0 / 255f);
            myTailRenderer.endColor = new Color(0 / 255f, 220 / 255f, 197 / 255f);
        }
        else if (mySprite.sprite.name == "rez")
        {
            myTailRenderer.startColor = new Color(35 / 255f, 35 / 255f, 35 / 255f);
            myTailRenderer.endColor = new Color(0 / 255f, 220 / 255f, 197 / 255f);
        }
        else if (mySprite.sprite.name == "fox")
        {
            myTailRenderer.startColor = new Color(233/255f, 117/255f, 22/255f);
            myTailRenderer.endColor = new Color(35/255f, 35 / 255f, 35 / 255f);
        }
        else if (mySprite.sprite.name == "neon")
        {
            myTailRenderer.startColor = Color.black;
            myTailRenderer.endColor = new Color(0 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (mySprite.sprite.name == "yinyang")
        {
            myTailRenderer.startColor = Color.black;
            myTailRenderer.endColor = Color.white;
        }
        else if (mySprite.sprite.name == "Luxxal_logo (1)")
        {
            myTailRenderer.startColor = Color.black;
            myTailRenderer.endColor = new Color(0 / 255f, 128 / 255f, 0 / 255f);
        }
        else if (mySprite.sprite.name == "earth")
        {
            myTailRenderer.startColor = new Color(0 / 255f, 163 / 255f, 97 / 255f);
            myTailRenderer.endColor = new Color(142 / 255f, 238 / 255f, 255 / 255f);
        }
        else if (mySprite.sprite.name == "8ball")
        {
            myTailRenderer.startColor = Color.white;
            myTailRenderer.endColor = Color.black;
        }
        else if (mySprite.sprite.name == "burger")
        {
            myTailRenderer.startColor = new Color(224 / 255f, 114 / 255f, 52 / 255f);
            myTailRenderer.endColor = new Color(150 / 255f, 182 / 255f, 52 / 255f);
        }
        else if (mySprite.sprite.name == "cult")
        {
            myTailRenderer.startColor = new Color(212 / 255f, 0 / 255f, 0 / 255f);
            myTailRenderer.endColor = Color.black;
        }
        else if (mySprite.sprite.name == "chicken")
        {
            myTailRenderer.startColor = Color.black;
            myTailRenderer.endColor = Color.white;
        }

        counter = GameObject.Find("RetryCounter").GetComponent<RetryCount>();
        counter.UI = GameObject.Find("RetryNum");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(rb.gravityScale == 0)
            {
                coll.enabled = true;
                rb.gravityScale = 1;
                myAudio.Play();
                timeText.enabled = false;
                panel.SetActive(false);
                objIsMovable = false;
                audioHasPlayed = true;
            }
        }
        if(timerIsRunning && controlIsOff)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                if (!audioHasPlayed)
                {
                    if (coll != null)
                    {
                        coll.enabled = true;
                    }
                    rb.gravityScale = 1;
                    timeRemaining = 0;
                    myAudio.Play();
                    panel.SetActive(false);
                    objIsMovable = false;
                    timerIsRunning = false;
                }
            }
        }

        if (rb.velocity.magnitude < threshold * threshold && rb.gravityScale == 1)
        {
            StartCoroutine(hasStopped());
        }

    }

    IEnumerator hasStopped()
    {
        float elapsed = 0f;

        while (GetComponent<Rigidbody2D>().velocity.magnitude < threshold * threshold)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= delay)
            {
                Debug.Log("Retry lvl");
                //overlayCanvas.GetComponent<LoseMenu>().Retry();
                counter.addRetry();
                counter.previousLvl();
                fader.FadeTo(SceneManager.GetActiveScene().name);
                yield break;
            }
            yield return null;
        }
        yield break;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hit" + collision);
        if (collision.gameObject.tag == "Bounce")
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                //Instantiate your particle system here.
                GameObject par = Instantiate(bounceParticle, contact.point, Quaternion.identity);
                par.GetComponent<ParticleSystem>().Play();
                Destroy(par, 3.5f);
            }
        }
    }

    public void drop()
    {
        if (rb.gravityScale == 0)
        {
            coll.enabled = true;
            rb.gravityScale = 1;
            myAudio.Play();
            timeText.enabled = false;
            panel.SetActive(false);
            objIsMovable = false;
            audioHasPlayed = true;
        }
    }
}
