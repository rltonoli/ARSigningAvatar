using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;

public class Transition2Text : MonoBehaviour
{

    public Text ButtonPressText;
    public Text ButtonPressTextPortuguese;
    public Text ButtonPressText_2ndOpt;
    public Text ButtonPressTextPortuguese_2ndOpt;
    //public Rig Rig;
    private Animator controller;
    public int Impatience;
    private bool isWaiting = false;
    private float timer = 0.0f;
    private MultiAimConstraint Aim;


    [SerializeField] public GameObject Rig; // this needs to be the object that you added the TwoBoneIKConstraint to, not the object that you are trying to constrain (the bones)

    // Start is called before the first frame update
    void Start()
    {
        //Rig.GetComponentInChildren<Multi>
        controller = GetComponent<Animator>();
        Aim = Rig.GetComponentInChildren<MultiAimConstraint>();
    }
    
    // Update is called once per frame
    void Update()
    {

        // Wait Impatience seconds to trigger a random idle/waiting animation
        if (isWaiting == true)
        {
            timer += Time.deltaTime;
            int seconds = (int) (timer % 60);
            if (seconds > Impatience) // Enter here when idle for more than Impatience seconds
            {
                timer = 0.0f;
                StartCoroutine(DecreaseLookAtWeigth()); // Smoothly decrease the avatar's gaze towards the camera
                TriggerIdle(Random.Range(1, 5)); // Trigger a random idle/waiting animation
                //WaitingTrigger(false);
            }
        }
            


    }

    public void WaitingTrigger(bool wait)
    {
        isWaiting = wait;
        if (isWaiting==true)
        {
            timer = 0.0f;
            StartCoroutine(IncreaseLookAtWeigth());
        }

    }


    // Smoothly increase the avatar's gaze towards the camera
    IEnumerator IncreaseLookAtWeigth()
    {
        Debug.Log("Increaseing weight!");
        float auxTimer = 0.0f;
        int auxStop = 10;
        while ((int)(auxTimer % 60) < auxStop)
        {
            auxTimer += Time.deltaTime;
            Aim.weight += Time.deltaTime;
            yield return null;
        }

    }

    // Smoothly decrease the avatar's gaze towards the camera
    IEnumerator DecreaseLookAtWeigth()
    {
        Debug.Log("Decreasing weight!");
        float auxTimer = 0.0f;
        int auxStop = 10;
        while ((int)(auxTimer % 60) < auxStop)
        {
            auxTimer += Time.deltaTime;
            Aim.weight -= Time.deltaTime;
            yield return null;
        }
    }

    // Trigger a random idle/waiting animation
    private void TriggerIdle(int idleid)
    {
        string trigger = "Idle" + idleid.ToString();
        controller.SetTrigger(trigger);

    }

    // Quit application
    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    // QualcommOnButtonPress called em Qualcomm button is pressed
    public void QualcommOnButtonPress()
    {
        controller.SetTrigger("ReturnIdleStill"); // Force return to idle animation
        StartCoroutine(IncreaseLookAtWeigth()); // Increase the avatar's gaze towards the camera
        controller.SetTrigger("Qualcomm"); // Calls the respective animation
    }

    // GreetingsOnButtonPress called em Greetings button is pressed
    public void GreetingsOnButtonPress()
    {
        controller.SetTrigger("ReturnIdleStill"); // Force return to idle animation
        StartCoroutine(IncreaseLookAtWeigth()); // Increase the avatar's gaze towards the camera
        controller.SetTrigger("Hi"); // Calls the respective animation
    }

    // AboutMeOnButtonPress called em About Me button is pressed
    public void AboutMeOnButtonPress()
    {
        controller.SetTrigger("ReturnIdleStill"); // Force return to idle animation
        StartCoroutine(IncreaseLookAtWeigth()); // Increase the avatar's gaze towards the camera
        controller.SetTrigger("AboutMe"); // Calls the respective animation
    }

    // GoodbyeOnButtonPress called em Goodbye button is pressed
    public void GoodbyeOnButtonPress()
    {
        controller.SetTrigger("ReturnIdleStill"); // Force return to idle animation
        StartCoroutine(IncreaseLookAtWeigth()); // Increase the avatar's gaze towards the camera
        controller.SetTrigger("Goodbye"); // Calls the respective animation
    }




    //void OnAnimatorIK()
    //{
    //Debug.Log("Hi");
    //Vector3 position = LookAtLock.transform.position;
    //GetComponent<Animator>().SetLookAtWeight(1);
    //GetComponent<Animator>().SetLookAtPosition(position);
    //}
}
