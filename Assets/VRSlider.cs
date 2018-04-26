using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
using UnityEngine.UI;
using UnityEngine;

public class VRSlider : MonoBehaviour {

    [SerializeField] private Material m_NormalMaterial;
    [SerializeField] private Material m_OverMaterial;
    [SerializeField] private Material m_ClickedMaterial;
    [SerializeField] private Material m_DoubleClickedMaterial;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private Renderer m_Renderer;
    [SerializeField] private Renderer m_HRenderer;

    public Slider mySlider;
    private float lastKnownPos;
    private Transform Track;

    public Transform handlePos;
    private Vector3 targetPos;
    private Vector3 neutralPos;

    public bool clicked = false;

    private float sliderPercent;
    private float sliderLength;

    

    private void Awake()
    {
        m_Renderer.material = m_NormalMaterial;
        m_HRenderer.material = m_NormalMaterial;
    }

    private void Start()
    {
        targetPos = handlePos.position;
        sliderLength = GetComponent<BoxCollider>().size.x;
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }


    //Handle the Over event
    private void HandleOver()
    {
        Debug.Log("Show over state");
        //attempted to use the difference in current position and last know position to adjust the value of the slider
        //if(clicked == true)
        //{
        //    var pos = GameObject.Find("Tracking").transform.position.x;
        //    //attempted to find the position or rotation of the controller
        //    float rot = pos;
        //    // my slider value equals change in wand x value
        //    mySlider.value = pos - lastKnownPos;
        //}
        //lastKnownPos = GameObject.Find("Tracking").transform.position.x;
        m_HRenderer.material = m_OverMaterial;
    }


    //Handle the Out event
    private void HandleOut()
    {
        Debug.Log("Show out state");
        m_HRenderer.material = m_NormalMaterial;
    }


    //Handle the Click event
    private void HandleClick()
    {
        Debug.Log("Show click state");
        // to change bool from tru to false, once clicked
        //clicked = !clicked;
        // Moves the slider handle to the target position
        //targetPos = new Vector3(neutralPos.x, neutralPos.y, targetPos.z);
        //handlePos.position = Vector3.Lerp(handlePos.position, targetPos, Time.deltaTime * 7);
        
        mySlider.value++;

        m_HRenderer.material = m_ClickedMaterial;
    }


    //Handle the DoubleClick event
    private void HandleDoubleClick()
    {
        Debug.Log("Show double click");

        mySlider.value--;

        m_Renderer.material = m_DoubleClickedMaterial;
    }
}
