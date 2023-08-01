using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Rotations bug in the limits
// TODO: Collisions w/ Floor (sometimes)

public class GameLogic : MonoBehaviour
{
    public bool leftLimit;
    public bool rightLimit;

    enum Orientation { Up, Right, Down, Left };
    
    GameObject currentShapeObject;
    Transform shapeTransform;
    Rigidbody2D shapeRigidbody2D;
    Collider2D shapeCollider;
    Orientation shapeOrientation;

    int currentShape;
    int stepsDown;
    float downInterval;
    
    [SerializeField]
    GameObject[] prefabs; // i, j, l, o, s, t, z
    
    public void ChooseNextShape(int numShape = 0)
    {
        bool preselected = numShape > 0 && numShape <= prefabs.Length;
        currentShape = preselected ? numShape-1 : Random.Range(0, prefabs.Length);
        
        currentShapeObject = Instantiate(prefabs[currentShape]);
        
        shapeTransform = currentShapeObject.transform;
        shapeRigidbody2D = currentShapeObject.GetComponent<Rigidbody2D>();
        shapeCollider = currentShapeObject.GetComponent<Collider2D>();

        shapeOrientation = Orientation.Up;
        leftLimit = false;
        rightLimit = false;
        stepsDown = 0;
    }
    
    void Start()
    {
        ChooseNextShape();

        downInterval = 2f;

        //InvokeRepeating("MoveShapeToDown", downInterval, downInterval);
    }
    
    void Update()
    {
        GenerateAllHits();

        if(Input.GetKey(KeyCode.S))
        {
            stepsDown++;
            
            if (stepsDown % 20 == 0)
                MoveShape("Down");
        }
        
        if(Input.GetKeyDown(KeyCode.A) && !leftLimit)
            MoveShape("Left");
        
        if(Input.GetKeyDown(KeyCode.D) && !rightLimit)
            MoveShape("Right");
        
        if(Input.GetKeyDown(KeyCode.LeftControl))
            RotateShape(false);
        
        if(Input.GetKeyDown(KeyCode.Space))
            RotateShape();
        
        // ----------- Just for debugging -----------
        
        if(Input.GetKeyDown(KeyCode.Alpha1)) ChooseNextShape(1);
        if(Input.GetKeyDown(KeyCode.Alpha2)) ChooseNextShape(2);
        if(Input.GetKeyDown(KeyCode.Alpha3)) ChooseNextShape(3);
        if(Input.GetKeyDown(KeyCode.Alpha4)) ChooseNextShape(4);
        if(Input.GetKeyDown(KeyCode.Alpha5)) ChooseNextShape(5);
        if(Input.GetKeyDown(KeyCode.Alpha6)) ChooseNextShape(6);
        if(Input.GetKeyDown(KeyCode.Alpha7)) ChooseNextShape(7);

        if(Input.GetKeyDown(KeyCode.Alpha0)) SpeedUp();
    }

    void RotateShape(bool clockwise = true)
    {
        float angle = clockwise ? -90 : 90;
        shapeTransform.Rotate(new Vector3(0, 0, angle));

        Vector2 offset = TranslateByRotation(clockwise);
        shapeTransform.Translate(offset);
    }

    Vector2 TranslateByRotation(bool clockwise = true)
    {
        float offsetX;
        float offsetY;

        if (currentShape == 3) // Square has not offset!
        {
            offsetX = offsetY = 0;
        }
        else
        {
            offsetX = offsetY = 0.25f;

            if (clockwise)
            {
                if (shapeOrientation == Orientation.Up)
                {
                    shapeOrientation = Orientation.Right;
                    offsetX = -offsetX;
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    shapeOrientation = Orientation.Down;

                    // Additional offsets for stick shape
                    if (currentShape == 0)
                    {
                        // When it is 1-step left wall
                        if (shapeTransform.position.x == -1.75)
                            offsetX -= 0.5f;
                        else
                        // When left wall
                        if (leftLimit)
                            offsetX -= 1f;
                        else
                        // When right wall
                        if (rightLimit)
                            offsetX += 0.5f;
                    }
                    else
                    // Additional offset when left wall (all shapes except stick)
                    if (leftLimit)
                        offsetX -= 0.5f;
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    shapeOrientation = Orientation.Left;
                    offsetY = -offsetY;
                }
                else // shapeOrientation == Orientation.Left
                {
                    shapeOrientation = Orientation.Up;
                    offsetX = -offsetX;
                    offsetY = -offsetY;

                    if (currentShape == 0)
                    {
                        if (shapeTransform.position.x == -1.75)
                            offsetX += 0.5f;
                        else
                        if (leftLimit)
                            offsetX += 1f;
                        else
                        if (rightLimit)
                            offsetX -= 0.5f;
                    }
                    else
                    if (leftLimit)
                        offsetX += 0.5f;
                }
            }
            else // !clockwise
            {
                if (shapeOrientation == Orientation.Up)
                {
                    shapeOrientation = Orientation.Right;
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    shapeOrientation = Orientation.Down;
                    offsetX = -offsetX;

                    // Additional offsets for stick shape
                    if (currentShape == 0)
                    {
                        // When it is 1-step right wall
                        if (shapeTransform.position.x == 1.75)
                            offsetX += 0.5f;
                        else
                        // When left wall
                        if (leftLimit)
                            offsetX -= 0.5f;
                        else
                        // When right wall
                        if (rightLimit)
                            offsetX += 1;
                    }
                    else
                    // Additional offset when right wall (all shapes except stick)
                    if (rightLimit)
                        offsetX += 0.5f;
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    shapeOrientation = Orientation.Left;
                    offsetX = -offsetX;
                    offsetY = -offsetY;
                }
                else // shapeOrientation == Orientation.Left
                {
                    shapeOrientation = Orientation.Up;
                    offsetY = -offsetY;

                    if (currentShape == 0)
                    {
                        if (shapeTransform.position.x == 1.75)
                            offsetX -= 0.5f;
                        else
                        if (leftLimit)
                            offsetX += 0.5f;
                        else
                        if (rightLimit)
                            offsetX -= 1;
                    }
                    else
                    if (rightLimit)
                        offsetX -= 0.5f;
                }
            }
        }
        
        return new Vector2(offsetX, offsetY);
    }
    
    void MoveShape(string direction)
    {
        if (shapeRigidbody2D != null)
        {
            Vector2 vectorDirection;

            if (direction == "Left")
                vectorDirection = Vector2.left;
            else
            if (direction == "Right")
                vectorDirection = Vector2.right;
            else // "Down"
                vectorDirection = Vector2.down;
        
            shapeRigidbody2D.MovePosition(shapeRigidbody2D.position + vectorDirection * 0.5f);
        }
    }

    void SpeedUp()
    {
        CancelInvoke();

        downInterval -= downInterval > 0.05f ? 0.15f : 0;
        downInterval = Mathf.Round(downInterval * 100.0f) * 0.01f; // Round to two decimals

        InvokeRepeating("MoveShapeToDown", downInterval, downInterval);
    }

    void GenerateAllHits()
    {
        if (GenerateHits("Down"))
            ChooseNextShape();
        
        if (GenerateHits("Left"))
            leftLimit = true;
        else
            leftLimit = false;
        
        if (GenerateHits("Right"))
            rightLimit = true;
        else
            rightLimit = false;
    }

    bool GenerateHits(string direction)
    {
        RaycastHit2D[] hits = new RaycastHit2D[4]; // Max 4 collisions

        Vector2 origin = shapeRigidbody2D.position;
        Vector2 offsetX;
        Vector2 offsetY;
        bool thereIsHit = false;

        if (direction == "Left")
        {
            if (currentShape == 0) // i
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(-1.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(-0.3f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY * 3, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                    hits[3] = Physics2D.Raycast(origin + offsetX - offsetY * 3, Vector2.left, 0.05f);
                }
            }
            else
            if (currentShape == 1) // j
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(-0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(-0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(0.2f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.left, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(-0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                }
            }
            else
            if (currentShape == 2) // l
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(-0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(0.2f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(-0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(-0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.left, 0.05f);
                }
            }
            else
            if (currentShape == 3) // o
            {
                offsetX = new Vector2(-0.55f, 0);
                offsetY = new Vector2(0, 0.25f);

                hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
            }
            else
            if (currentShape == 4) // s
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(-0.3f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(-0.8f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.left, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(-0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.left, 0.05f);
                }
            }
            else
            if (currentShape == 5) // t
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(-0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(-0.3f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(-0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(-0.3f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.left, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(-0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.left, 0.05f);
                }
            }
            else
            if (currentShape == 6) // z
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(-0.3f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(-0.8f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(-0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(-0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.left, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.left, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.left, 0.05f);
                }
            }
        }
        else
        if (direction == "Right")
        {
            if (currentShape == 0) // i
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(1.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(0.3f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY * 3, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                    hits[3] = Physics2D.Raycast(origin + offsetX - offsetY * 3, Vector2.right, 0.05f);
                }
            }
            else
            if (currentShape == 1) // j
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(-0.2f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.right, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
            }
            else
            if (currentShape == 2) // l
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(-0.2f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.right, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
            }
            else
            if (currentShape == 3) // o
            {
                offsetX = new Vector2(0.55f, 0);
                offsetY = new Vector2(0, 0.25f);

                hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
            }
            else
            if (currentShape == 4) // s
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.3f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(0.8f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
            }
            else
            if (currentShape == 5) // t
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(0.3f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX2 + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.right, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.8f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(0.3f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.right, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX - offsetY, Vector2.right, 0.05f);
                }
            }
            else
            if (currentShape == 6) // z
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.3f, 0);
                    offsetY = new Vector2(0, 0.25f);

                    Vector2 offsetX2 = new Vector2(0.8f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.right, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(0.55f, 0);
                    offsetY = new Vector2(0, 0.5f);

                    Vector2 offsetX2 = new Vector2(0.05f, 0);

                    hits[0] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.right, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX, Vector2.right, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX2 - offsetY, Vector2.right, 0.05f);
                }
            }
        }
        else // direction == "Down"
        {
            if (currentShape == 0) // i
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.3f);

                    hits[0] = Physics2D.Raycast(origin - offsetX * 3 + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                    hits[3] = Physics2D.Raycast(origin + offsetX * 3 + offsetY, Vector2.down, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetY = new Vector2(0, -1.05f);

                    hits[0] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                }
            }
            else
            if (currentShape == 1) // j
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.8f);

                    Vector2 offsetY2 = new Vector2(0, 0.2f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY2, Vector2.down, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    Vector2 offsetY2 = new Vector2(0, -0.05f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY2, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY2, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.8f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
            }
            else
            if (currentShape == 2) // l
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.8f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    Vector2 offsetY2 = new Vector2(0, -0.05f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY2, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY2, Vector2.down, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.8f);

                    Vector2 offsetY2 = new Vector2(0, 0.2f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY2, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
            }
            else
            if (currentShape == 3) // o
            {
                offsetX = new Vector2(0.25f, 0);
                offsetY = new Vector2(0, -0.55f);

                hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
            }
            else
            if (currentShape == 4) // s
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    Vector2 offsetY2 = new Vector2(0, -0.05f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY2, Vector2.down, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.3f);

                    Vector2 offsetY2 = new Vector2(0, -0.8f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY2, Vector2.down, 0.05f);
                }
            }
            else
            if (currentShape == 5) // t
            {
                if (shapeOrientation == Orientation.Up)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Right)
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.8f);

                    Vector2 offsetY2 = new Vector2(0, -0.3f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY2, Vector2.down, 0.05f);
                }
                else
                if (shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    Vector2 offsetY2 = new Vector2(0, -0.05f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY2, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY2, Vector2.down, 0.05f);
                }
                else // Orientation.Left
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.8f);

                    Vector2 offsetY2 = new Vector2(0, -0.3f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY2, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
            }
            else
            if (currentShape == 6) // z
            {
                if (shapeOrientation == Orientation.Up || shapeOrientation == Orientation.Down)
                {
                    offsetX = new Vector2(0.5f, 0);
                    offsetY = new Vector2(0, -0.55f);

                    Vector2 offsetY2 = new Vector2(0, -0.05f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY2, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetY, Vector2.down, 0.05f);
                    hits[2] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
                else // Orientation.Left || Orientation.Right
                {
                    offsetX = new Vector2(0.25f, 0);
                    offsetY = new Vector2(0, -0.3f);

                    Vector2 offsetY2 = new Vector2(0, -0.8f);

                    hits[0] = Physics2D.Raycast(origin - offsetX + offsetY2, Vector2.down, 0.05f);
                    hits[1] = Physics2D.Raycast(origin + offsetX + offsetY, Vector2.down, 0.05f);
                }
            }
        }

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider)
            {
                thereIsHit = true;
                break;
            }
        }
        
        return thereIsHit;
    }
}