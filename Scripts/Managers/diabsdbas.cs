using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Blablabla
{
	public string nome;
	public int idade;
	public bool ativo;
}

public class diabsdbas : MonoBehaviour {

	public Blablabla[] teste = {
		new Blablabla {
			nome = "Samuca",
			idade = 3,
			ativo = true
		}, 
		new Blablabla {
			nome = "Felipe",
			idade = 5,
			ativo = false
		},
		new Blablabla {
			nome = "May",
			idade = 9,
			ativo = true
		}
	};

	void Start(){
		//bool sdasdadgha = teste.FirstOrDefault (t => t.ativo == true);
		Blablabla[] names = teste.Where(fff => fff.ativo == true).ToArray();
		//string name = teste.Any (abc => abc.nome == "Felipe").ToString ();
		print(names.Length);
	}

}
