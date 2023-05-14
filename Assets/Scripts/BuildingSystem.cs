using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{

    public GameObject[] Shape;
    private Vector3 mousePos;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    public GameObject TempShape;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TempShape != null)
        {
            TempShape.transform.position = mousePos;

            if (Input.GetMouseButtonDown(0))
            {
                placeShape();
            }
        }

    }
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, layerMask))
        {
            mousePos = hit.point;
        }

    }


    public void SpawnShape(int index)
    {
        TempShape = Instantiate(Shape[index], mousePos, Quaternion.identity);

    }

    public void placeShape()
    {
        TempShape = null;
    }


}
