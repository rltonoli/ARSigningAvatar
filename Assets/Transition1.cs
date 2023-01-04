using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition1 : StateMachineBehaviour
{
    private Text ButtonPressText;
    private Text ButtonPressTextPortuguese;
    private Text ButtonPressText_2ndOpt;
    private Text ButtonPressTextPortuguese_2ndOpt;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get the reference for displaying the text below the buttons (currently disabled) and for the subtitles
        if (ButtonPressText == null)
        {
            ButtonPressText = animator.gameObject.GetComponent<Transition2Text>().ButtonPressText;
            ButtonPressTextPortuguese = animator.gameObject.GetComponent<Transition2Text>().ButtonPressTextPortuguese;
            ButtonPressText_2ndOpt = animator.gameObject.GetComponent<Transition2Text>().ButtonPressText_2ndOpt;
            ButtonPressTextPortuguese_2ndOpt = animator.gameObject.GetComponent<Transition2Text>().ButtonPressTextPortuguese_2ndOpt;
        }
        // Check which state (animation) started playing
        switch (getState(stateInfo)){
            case "IdleStill":
                ButtonPressText.text = "Select an option";
                ButtonPressTextPortuguese.text = "Selecione uma opção";
                break;
            case "Qualcomm":
                ButtonPressText.text = "Q U A L C O M M";
                ButtonPressTextPortuguese.text = "Q U A L C O M M";
                break;
            case "01":
                ButtonPressText.text = "Hello...";
                ButtonPressTextPortuguese.text = "Olá...";
                break;
            case "02":
                ButtonPressText.text = "My name is Talita...";
                ButtonPressTextPortuguese.text = "Meu nome é Talita...";
                break;
            case "03":
                ButtonPressText.text = "This is my sign <Talita>...";
                ButtonPressTextPortuguese.text = "Esse é meu sinal <Talita>...";
                break;
            case "04":
                ButtonPressText.text = "I was designed at Unicamp.";
                ButtonPressTextPortuguese.text = "Fui criada na Unicamp.";
                break;
            case "05":
                ButtonPressText.text = "I am learning to translate textbooks...";
                ButtonPressTextPortuguese.text = "Estou aprendendo a traduzir livros didáticos...";
                break;
            case "06":
                ButtonPressText.text = "I'm happy to be here at the Qualcomm booth...";
                ButtonPressTextPortuguese.text = "Estou feliz por estar aqui no estande da Qualcomm...";
                break;
            case "07":
                ButtonPressText.text = "It was a pleasure to meet you...";
                ButtonPressTextPortuguese.text = "Foi um prazer conhecê-lo...";
                break;
            case "08":
                ButtonPressText.text = "Follow my development on the website www.tas.unicamp.br.";
                ButtonPressTextPortuguese.text = "Acompanhe meu desenvolvimento pelo site www.tas.unicamp.br.";
                break;
            case "09":
                ButtonPressText.text = "A big hug...";
                ButtonPressTextPortuguese.text = "Um forte abraço...";
                break;
            case "10":
                ButtonPressText.text = "Bye.";
                ButtonPressTextPortuguese.text = "Adeus.";
                break;
        }
        // Update the subtitles' text 
        ButtonPressText_2ndOpt.text = ButtonPressText.text;
        ButtonPressTextPortuguese_2ndOpt.text = ButtonPressTextPortuguese.text;

        // When in idle state, set InIdle flag to True
        if (stateInfo.IsName("Idle1") == true)
        {
            animator.SetBool("InIdle", true);
            animator.gameObject.GetComponent<Transition2Text>().WaitingTrigger(true);
        }


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // When exit idle state, set InIdle flah to False
        if (stateInfo.IsName("Idle1") == true)
        {
            animator.SetBool("InIdle", false);
            animator.gameObject.GetComponent<Transition2Text>().WaitingTrigger(false);
        }
            
    }

    // Check which state (animation) started playing
    private string getState(AnimatorStateInfo stateInfo)
    {
        string stateName = "";
        if (stateInfo.IsName("Idle1") == true)
            stateName = "IdleStill";
        else if (stateInfo.IsName("Hello") == true)
            stateName = "01";
        else if (stateInfo.IsName("Qualcomm") == true)
            stateName = "Qualcomm";
        else if (stateInfo.IsName("Talita|d10_q_s01") == true)
            stateName = "01";
        else if (stateInfo.IsName("Talita|d10_q_s02") == true)
            stateName = "02";
        else if (stateInfo.IsName("Talita|d10_q_s03") == true)
            stateName = "03";
        else if (stateInfo.IsName("Talita|d10_q_s04") == true)
            stateName = "04";
        else if (stateInfo.IsName("Talita|d10_q_s05") == true)
            stateName = "05";
        else if (stateInfo.IsName("Talita|d10_q_s06") == true)
            stateName = "06";
        else if (stateInfo.IsName("Talita|d10_q_s07") == true)
            stateName = "07";
        else if (stateInfo.IsName("Talita|d10_q_s08") == true)
            stateName = "08";
        else if (stateInfo.IsName("Talita|d10_q_s09") == true)
            stateName = "09";
        else if (stateInfo.IsName("Talita|d10_q_s10") == true)
            stateName = "10";

        return stateName;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
