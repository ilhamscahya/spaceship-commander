using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour 
{
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	KeywordRecognizer keywordRecognizer;

    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text healthtxt, scoretxt, commandtxt;
    public int health, score;
    public Transform gb;
    public GameObject shot;
    public GameObject bigShot;
    public Transform shotSpawn;
    
    string word;
    float speed;
    float firstY;
    

    // Use this for initialization
    void Start () 
	{
        health = 5;
        score = 0;
        gb = GetComponent<Transform>();
        Dictionary();
        speed = 3f;
        firstY = gb.position.y;

        if(keywords != null)
        {
            keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray(), confidence);
            keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognized;
            keywordRecognizer.Start();
        }
	}

    // Update is called once per frame
    void Update()
    {
        healthtxt.text = "Health: " + health;
        scoretxt.text = "Score: " + score;

        if(health <= 0)
        {
            SceneManager.LoadScene(0);
            keywordRecognizer.Stop();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void KeywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            health--;
        }
    }

    public int AddScore(int score)
    {
        return this.score += score;
    }

	void Up(){
        if(gb.position.y != firstY + 3)
        {
            gb.Translate(Vector2.up * speed);
            commandtxt.text = "Command: Up";
            print("Up");
        } else
        {
            print("Limit");
        }
	}

	void Down(){
        if(gb.position.y != firstY - 3)
        {
            gb.Translate(Vector2.down * speed);
            commandtxt.text = "Command: Down";
            print("Down");
        } else
        {
            print("Limit");
        }

    }

	void Fire(){
        commandtxt.text = "Command: Fire";
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    void FuckingFire(){
        Instantiate(bigShot, shotSpawn.position, shotSpawn.rotation);
    }

    void Jump()
    {
        if (gb.position.y != firstY)
        {
            if(gb.position.y == firstY + 3)
            {
                commandtxt.text = "Command: Jump";
                gb.Translate(Vector2.down * speed * 2);
                print("Jump Down");
            } else if (gb.position.y == firstY - 3)
            {
                gb.Translate(Vector2.up * speed * 2);
                print("Jump Up");
            }

        }
        else 
        {
            print("Cannot jump here!");
        }
    }

    void Dictionary()
    {
        keywords.Add("spaceship, up", Up);
        keywords.Add("spaceship, down", Down);
        keywords.Add("spaceship, fire", Fire);
        keywords.Add("spaceship, big boy", FuckingFire);
        keywords.Add("spaceship, jump", Jump);
    }

    private void OnApplicationQuit()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.OnPhraseRecognized -= KeywordRecognizerOnPhraseRecognized;
            keywordRecognizer.Stop();
        }
    }
}
