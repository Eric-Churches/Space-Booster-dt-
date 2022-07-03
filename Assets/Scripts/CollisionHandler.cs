using UnityEngine;
using Debug = UnityEngine.Debug;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("You are safe in this area");
            break;
            case "Finish":
                Debug.Log("Congrats you have finish Yeah!!");
                break;
            case "Fuel":
                Debug.Log("I need some gas brother");
                break;
            default:
                
                break;
        }
    }
}
