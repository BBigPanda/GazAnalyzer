using UniRx;
using UnityEngine;

public class CraneController : MonoBehaviour
{
   public static CraneController Instance;

   public ReactiveProperty<bool> Up = new ();
   public ReactiveProperty<bool> Down = new ();
   public ReactiveProperty<bool> Left = new ();
   public ReactiveProperty<bool> Right = new ();
   public ReactiveProperty<bool> Forward = new ();
   public ReactiveProperty<bool> Backward = new ();
   public ReactiveProperty<bool> Take = new ();
   public ReactiveProperty<bool> Running = new ();
   public void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
       }
       else
       {
           Destroy(gameObject);
       }
   }
   
   
}
