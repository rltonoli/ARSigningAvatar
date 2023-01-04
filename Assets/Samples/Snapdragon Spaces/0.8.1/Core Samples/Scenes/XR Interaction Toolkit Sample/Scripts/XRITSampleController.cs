/******************************************************************************
 * File: XRITSampleController.cs
 * Copyright (c) 2021-2022 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Qualcomm.Snapdragon.Spaces.Samples
{
    public class XRITSampleController : SampleController
    {
        public Text ButtonPressText;
        public Text ButtonPressTextPortuguese;

        public Text ScrollbarText;
        public Text TouchpadXText;
        public Text TouchpadYText;
        public InputActionReference TouchpadInputAction;
        public RectTransform TouchpadPositionIndicator;
        public GameObject Avatar;

        public void OnButtonPress(string buttonName)
        {
            ButtonPressText.text = buttonName;
        }

        public void OnQuitButtonPress()
        {
            Application.Quit();
        }


        public void QualcommOnButtonPress()
        {
            Animator controller = Avatar.GetComponent<Animator>();
            controller.SetTrigger("Qualcomm");
        }

        public void HiOnButtonPress()
        {
            Animator controller = Avatar.GetComponent<Animator>();
            controller.SetTrigger("Hi");
        }

        public void AboutMeOnButtonPress()
        {
            Animator controller = Avatar.GetComponent<Animator>();
            controller.SetTrigger("AboutMe");
        }
        
        public void GoodbyeOnButtonPress()
        {
            Animator controller = Avatar.GetComponent<Animator>();
            controller.SetTrigger("Goodbye");
        }

        public void OnScrollValueChanged(float value) {
            ScrollbarText.text = value.ToString("#0.00");
        }

        public override void Update() {
            base.Update();
            var touchpadValue = TouchpadInputAction.action.ReadValue<Vector2>();
            TouchpadXText.text = touchpadValue.x.ToString("#0.00");
            TouchpadYText.text = touchpadValue.y.ToString("#0.00");
            TouchpadPositionIndicator.anchoredPosition = touchpadValue;
        }
    }
}