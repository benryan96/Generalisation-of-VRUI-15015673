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

    private void Awake()
    {
        m_Renderer.material = m_NormalMaterial;
        m_HRenderer.material = m_NormalMaterial;
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
