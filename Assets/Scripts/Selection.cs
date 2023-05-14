using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selection : MonoBehaviour
{
    public GameObject SelectedShape;
    public TextMeshProUGUI Shapetext;
    public BuildingSystem buildingSystem;
    public GameObject EditUi;
    // Start is called before the first frame update
    void Start()
    {
        buildingSystem = GameObject.Find("BuildingSystem").GetComponent<BuildingSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                if (hit.collider.gameObject.CompareTag("Shape"))
                {
                    Select(hit.collider.gameObject);
                }


            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Deselect();
        }

    }

    void Select(GameObject shape)
    {
        if (shape == SelectedShape) return;
        Deselect();
        Outline outline = shape.GetComponent<Outline>();
        if (outline == null) shape.AddComponent<Outline>();
        else outline.enabled = true;
        Shapetext.text = shape.name;
        EditUi.SetActive(true);
        SelectedShape = shape;

    }
    void Deselect()
    {
        if (SelectedShape == null) return;
        Outline outline = SelectedShape.GetComponent<Outline>();
        if (outline != null) outline.enabled = false;
        EditUi.SetActive(false);
        SelectedShape = null;


    }

    public void Delete()
    {
        if (SelectedShape == null) return;
        EditUi.SetActive(false);
        Destroy(SelectedShape);
        SelectedShape = null;
    }

    public void Move()
    {
        if (SelectedShape == null) return;
        buildingSystem.TempShape = SelectedShape.transform.parent.gameObject;
        SelectedShape = null;
    }

    public void Rotate()
    {
        if (SelectedShape == null) return;
        SelectedShape.transform.parent.Rotate(0, 45, 0);
    }

    public void ScaleUp()
    {
        if (SelectedShape == null) return;
        SelectedShape.transform.parent.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void ScaleDown()
    {
        if (SelectedShape == null) return;
        SelectedShape.transform.parent.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }
    public void ChangeColor()
    {
        if (SelectedShape == null) return;
        SelectedShape.transform.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
