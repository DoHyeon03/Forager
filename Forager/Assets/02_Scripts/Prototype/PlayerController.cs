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
        ATTACK,
        HIT
    }

    public PLAYERSTATE playerState;

    public CharacterController character;
    public GameManager gameManager;
    public float playerSpeed;
    public float dashSpeed = 1;
    public float curTime;
    public float coolTime = 0.5f;

    public Text ingotCount;

    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal") * playerSpeed * dashSpeed * Time.deltaTime;
        float MoveY = Input.GetAxis("Vertical") * playerSpeed * dashSpeed * Time.deltaTime;

        character.Move(new Vector3(MoveX, 0, MoveY));

        switch (playerState)
        {
            case PLAYERSTATE.IDLE:
                if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
                {
                    playerState = PLAYERSTATE.WALK;
                }
                break;
            case PLAYERSTATE.WALK:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dashSpeed = 2f;
                    playerState = PLAYERSTATE.DASH;
                }
                break;
            case PLAYERSTATE.DASH:
                curTime += Time.deltaTime;
                if (curTime >= coolTime)
                {
                    curTime = 0;
                    dashSpeed = 1f;
                    playerState = PLAYERSTATE.WALK;
                }
                break;
            case PLAYERSTATE.ATTACK:
                break;
            case PLAYERSTATE.HIT:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            gameManager.ingotCount++;
            ingotCount.text = $"IngotCount : {gameManager.ingotCount}";
            other.gameObject.SetActive(false);
            Destroy(other);
        }

        if (other.CompareTag("Water"))
        {
            //character.transform.position
        }
    }
}
