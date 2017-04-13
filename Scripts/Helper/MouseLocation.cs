using UnityEngine;

public class MouseLocation : MonoBehaviour {

	public static MouseLocation Instance; //permite que seja instanciado em outras classes.  (Singleton) [Singleton é DontDestroyOnLoad]

	[HideInInspector]public Vector3 mousePosition;		 //Localização do cursos no espaço 3D.
	[HideInInspector]public bool isValid;  				 //A localização do mouse na tela é valida?

	[SerializeField] LayerMask isGround;

	Ray mouseRay;
	RaycastHit hit;
	Vector2 screenPosition;		//posição do mouse na tela.
	bool isTouchingAiming;     //usado se estiver rodando em mobile.

	void Awake () {

		//Garante que exista apenas o Instance, caso seja nulo recebe a si mesmo, caso seja outro código se destroy.
		if (Instance == null) {
			Instance = this;
		}else if(Instance != this){
			Destroy (this);
		}
	}

	void Update () {
		isValid = false;

		#if UNITY_ANDROID || UNNITY_IOS || UNITY_WP8
			if (!isTouchingAiming) {
			return;
			}
		#else 
		screenPosition = Input.mousePosition;
		#endif

		mouseRay = Camera.main.ScreenPointToRay (screenPosition);
		if (Physics.Raycast(mouseRay, out hit, 100f)) { // toda as variações de raycast retornam uma booleana.
			isValid = true;
			mousePosition = hit.point;
		}
	}
}