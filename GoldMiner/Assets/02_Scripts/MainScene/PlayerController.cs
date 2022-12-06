using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum PLAYERSTATE
    {
        IDLE=0,
        WALK,
        DASH,
        ATTACK
    }

    public PLAYERSTATE playerState;

    public CharacterController character;
    public GameManager gameManager;
    public Animator playerAnim;
    public AudioClip playerWalkSound;
    public AudioSource audioSource;

    public GameObject coinSound;
    public GameObject itemPickUp;

    public float playerSpeed;
    public float dashSpeed = 1;

    public float curTime;
    public float coolTime = 0.5f;
    public float attackCurTime;
    public float attackCoolTime = 0.85f;

    public bool attackOn;
    public bool idleOn;
    public bool delay = true;

    public Vector3 playerPositon = new Vector3(0, 0, 0);

    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = playerWalkSound;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * playerSpeed * dashSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * playerSpeed * dashSpeed * Time.deltaTime;

        switch (playerState)
        {
            case PLAYERSTATE.IDLE:

                if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
                {
                    playerState = PLAYERSTATE.WALK;
                    audioSource.clip = playerWalkSound;
                    audioSource.Play();
                }
                if (attackOn)
                {
                    playerState = PLAYERSTATE.ATTACK;
                }

                break;
            case PLAYERSTATE.WALK:
                character.Move(new Vector3(moveX, 0, moveZ));
                IfIdle(moveX, moveZ);

                audioSource.clip = playerWalkSound;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dashSpeed = 1.2f;
                    playerState = PLAYERSTATE.DASH;
                }
                if (attackOn)
                {
                    playerState = PLAYERSTATE.ATTACK;
                }
                if (idleOn)
                {
                    playerState = PLAYERSTATE.IDLE;
                    idleOn = false;
                    audioSource.Stop();
                }
                break;
            case PLAYERSTATE.DASH:
                character.Move(new Vector3(moveX, 0, moveZ));
                IfIdle(moveX, moveZ);

                curTime += Time.deltaTime;
                if (curTime >= coolTime)
                {
                    curTime = 0;
                    dashSpeed = 1f;
                    playerState = PLAYERSTATE.WALK;
                }
                if (attackOn)
                {
                    playerState = PLAYERSTATE.ATTACK;
                }
                if (idleOn)
                {
                    playerState = PLAYERSTATE.IDLE;
                    idleOn = false;
                    audioSource.Stop();
                }
                break;
            case PLAYERSTATE.ATTACK:
                attackCurTime += Time.deltaTime;
                if (attackCurTime >= attackCoolTime)
                {
                    attackOn = false;
                    delay = true;
                    playerState = PLAYERSTATE.IDLE;
                    attackCurTime = 0;
                    audioSource.Stop();
                }
                break;
            default:
                break;
        }
        playerAnim.SetInteger("PLAYERSTATE", (int)playerState);
    }

    public void IfIdle(float nowMoveX, float nowMoveZ)
    {
        if (playerPositon == new Vector3(nowMoveX, 0, nowMoveZ))
        {
            idleOn = true;
        }
        playerPositon = new Vector3(nowMoveX, 0, nowMoveZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.name == "GoldIngot(Clone)")
            {
                gameManager.ingotCount++;
                Instantiate(itemPickUp);
            }
            else if (other.name == "Coin(Clone)")
            {
                gameManager.coinCount += 4;
                Instantiate(coinSound);
            }
            else if (other.name == "Stone(Clone)")
            {
                gameManager.stoneCount++;
                Instantiate(itemPickUp);
            }
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
