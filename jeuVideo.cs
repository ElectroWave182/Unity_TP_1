using System;


public class Tests
{
	static void Main (string[] args)
	{
		// Instanciation des combattants
		Personnage monPerso = new Personnage ();
		Allie allie1 = new Allie ();
		Ennemi ennemi1 = new Ennemi ();
		
		// Variables
		string entree;
		int soin;
		int degats;
		int nbTours = 10;
		Random alea = new Random ();
		
		// Boucle des tours
		while (true)
		{
			// Initialisation
			monPerso. marche ();
			entree = Console. ReadLine ();
			switch (entree)
			{
				
				// Soin pour le personnage
				case "h":
					soin = monPerso. getVie () / 20;
					Console. WriteLine ("Le personnage se soigne : " + soin);
					monPerso. setVie (monPerso. getVie () + soin);
					break;
				
				// Soin pour l'allie
				case "z":
					soin = allie1. vie / 20;
					Console. WriteLine ("Le personnage soigne son allie : " + soin);
					allie1. vie += soin;
					break;
				
				// Protection pour le personnage
				case "d":
					if (allie1. vie > 0)
					{
						soin = monPerso. getVie () / 20;
						degats = ennemi1. pointsAttaque * ((int) (10 * alea. NextDouble ()) + 95) / 1000;
						Console. WriteLine ("L'allie protege le personnage.");
						Console. WriteLine ("Le personnage se soigne : " + soin);
						monPerso. setVie (monPerso. getVie () + soin + degats);
						allie1. vie -= degats;
					}
					break;
				
				// Attaque du personnage
				case "a":
					if (alea. NextDouble () >= ennemi1. vitesse / 100)
					{
						degats = allie1. pointsAttaque * ((int) (10 * alea. NextDouble ()) + 95) / 1000;
						Console. WriteLine ("L'allie attaque : " + degats);
						ennemi1. vie -= degats;
					}
					else
					{
						Console. WriteLine ("Le personnage attaque, mais l'ennemi esquive !");
					}
					break;
					
			}
			
			// Attaque de l'ennemi
			if (alea. NextDouble () >= monPerso. vitesse / 100)
			{
				degats = ennemi1. pointsAttaque * ((int) (10 * alea. NextDouble ()) + 95) / 1000;
				Console. WriteLine ("L’ennemi attaque : " + degats);
				monPerso. setVie (monPerso. getVie () - degats);
			}
			else
			{
				Console. WriteLine ("L’ennemi attaque, mais le personnage esquive !");
			}
			
			// Résultats du tour
			ennemi1. incrementerPointAttaque ();
			Console. WriteLine (monPerso);
			Console. WriteLine (allie1);
			Console. WriteLine (ennemi1);
			Console. WriteLine ();
			nbTours --;
			
			// Fin de la partie ?
			if (monPerso. getVie () <= 0)
			{
				Console. WriteLine ("Perdu, votre personnage est mort...");
				break;
			}
			else if (ennemi1. vie <= 0)
			{
				Console. WriteLine ("Gagné, l'ennemi a ete vaincu !");
				break;
			}
			else if (nbTours == 0)
			{
				Console. WriteLine ("Gagné, les renforts sont arrives !");
				break;
			}
		}
		Console.WriteLine ("C'est fini. Game Over!");
	}
}


public class Personnage
{
	private int vie; // attribut
	public double vitesse {get; set;} // attribut
	public int id; // attribut

	public Personnage ()
	{ // constructeur
		vie = 100;
		vitesse = 10;
	}

	public void marche ()
	{ // méthode
		Console.WriteLine ("Je marche");
	}

	public void arrete ()
	{ // méthode
		Console.WriteLine ("Je m’arrete");
	}

	public int getVie ()
	{ // méthode de type « get »
		return vie;
	}

	public void setVie (int nouvelleValeur)
	{ // méthode de type « set »
		vie = nouvelleValeur;
	}
	
	// Bilan des statistiques du personnage
	public override string ToString ()
	{
		return
			"Personnage : "
			+ vie
			+ " PV, 0 ATQ"
		;
	}
}


public class Allie
{
	// Attributs
	public int pointsAttaque {get; set;}
	private int id;
	public int vie {get; set;}
	
	// Constructeur
	public Allie ()
	{
		vie = 100;
		pointsAttaque = 200;
	}

	public void attaque ()
	{ // méthode
		Console.WriteLine ("J’attaque : -" + pointsAttaque);
	}

	public void defendPersonnage ()
	{ // méthode
		Console.WriteLine ("Je défends le personnage.");
	}
	
	// Bilan des statistiques de l'allié
	public override string ToString ()
	{
		return
			"Allie :      "
			+ vie
			+ " PV, "
			+ pointsAttaque
			+ " ATQ"
		;
	}
}


public class Ennemi
{
	// Attributs
	public int pointsAttaque {get; set;}
	public double vitesse {get; set;}
	private int id;
	public int vie {get; set;}
	
	// Constructeur
	public Ennemi ()
	{
		vie = 100;
		vitesse = 5;
		pointsAttaque = 200;
	}

	public void attaque ()
	{ // méthode
		Console.WriteLine ("J’attaque : -" + pointsAttaque);
	}

	private void defend ()
	{ // méthode
		Console.WriteLine ("Je me défend");
	}

	public void incrementerPointAttaque ()
	{ // méthode
		Console.WriteLine("Je prépare mon attaque !");
		pointsAttaque ++;
	}
	
	// Bilan des statistiques de l'ennemi
	public override string ToString ()
	{
		return
			"Ennemi :     "
			+ vie
			+ " PV, "
			+ pointsAttaque
			+ " ATQ"
		;
	}
}
