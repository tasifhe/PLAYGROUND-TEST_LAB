using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromtUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promtText;

    private void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }
    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;
    public void SetUp(string promtText)
    {
        _uiPanel.SetActive(true);
        _promtText.text = promtText;

        IsDisplayed = true;
    }
    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
