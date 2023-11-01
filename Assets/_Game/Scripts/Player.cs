using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Direct { Forward,Back,Right,Left,None}
public class Player : MonoBehaviour
{
    
    public LayerMask layerBrick;
    public float speed = 5;
    public Transform playerBrickPrefab;
    public Transform brickHolder;
    public Transform playerSkin;
    public List<Transform> playerBricks = new List<Transform>();

    private bool isMoving;
    private Vector3 targetPoint;
 //   private Vector3 stopPoint;
    private Vector3 mouseDown, mouseUp;
   
   

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
       
    }

    // Update is called once per frame
    void Update()

    {
        if (!isMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseUp = Input.mousePosition;
                Direct direct= GetDirect(mouseDown, mouseUp);
                if (direct !=Direct.None)
                {
                    targetPoint = GetNextPoint(direct);
                    isMoving = true;
                }
               
            }
        }
        else
        {
            if (Vector3.Distance(transform.position,targetPoint)<0.1f)
            {
                isMoving = false;
            }
            transform.position = Vector3.MoveTowards(transform.position,targetPoint,Time.deltaTime*speed);
        }
        
    }
    public void OnInit()
    {
        isMoving=false;
    }
    private Direct GetDirect(Vector3 mouseDown,Vector3 mouseUp)
    {
        Direct direct =Direct.None;
         
        float deltaX = mouseUp.x - mouseDown.x;
        float deltaY = mouseUp.y - mouseDown.y;

        if (Vector3.Distance(mouseDown, mouseUp)<100)
        {
            direct=Direct.None;
        }
        else
        {
            if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
            {
                if (deltaY>0)
                {
                    direct = Direct.Forward;
                }
                else
                {
                    direct = Direct.Back;
                }
            }
            else
            {
                if (deltaX>0)
                {
                    direct = Direct.Right;
                }
                else
                {
                    direct = Direct.Left;
                }
            }
        }
        return direct;
    }

    private Vector3 GetNextPoint(Direct direct)
    {
        RaycastHit hit;
        Vector3 nextPoint = transform.position;
        Vector3 dir=Vector3.zero;
        switch (direct)
        {
            case Direct.Forward:
                dir = Vector3.forward;
                break;
            case Direct.Back:
                dir = Vector3.back;
                break;
            case Direct.Right:
                dir = Vector3.right;
                break;
            case Direct.Left:
                dir = Vector3.left;
                break;
            case Direct.None:
                break;
            default:
                break;

        }
        for (int i = 1; i < 100; i++)
        {
            //Debug.LogError(transform.position + dir * i );
            //Debug.DrawRay(transform.position,dir*10f,Color.red,200f);
            if (Physics.Raycast(transform.position + dir *i + Vector3.up * 2f, Vector3.down,out hit, 20f, layerBrick))
            {
               nextPoint= hit.collider.transform.position;
            }
            else
            {
                break;
            }
        }
        return nextPoint;
       
    }
    public void AddBrick() 
    {
        int index = playerBricks.Count;

        Transform playerBrick=Instantiate(playerBrickPrefab,brickHolder);
        playerBrick.localPosition = Vector3.down + index * 0.25f * Vector3.up ;

        playerBricks.Add(playerBrick);
        

    

      //  playerSkin.localPosition = playerSkin.localPosition + Vector3.up * 0.25f;
    }
    public void RemoveBrick() 
    {
        int index = playerBricks.Count - 1;
        Transform playerBrick = playerBricks[index];
        if (index >= 0)
        {
            playerBricks.Remove(playerBrick);
            Destroy(playerBrick.gameObject);
        }
        

    }
    public void ClearBrick()
    {

    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstranName.FinishBlock))
        {
            UIManager.Instance.VictoryUI();
        }
        if (other.CompareTag(ConstranName.Unbrick) && playerBricks.Count <=0)
        {
            UnBrick unbrik = other.GetComponent<UnBrick>();
            if (!unbrik.isCollect)
            {
             
                targetPoint=other.transform.position - Vector3.forward;
                //coment
            }
        }
        

    }
}
