using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using MySql.Data.MySqlClient;

namespace ContactApp
{
internal class Program
{
    static void Main(string[] args)
    {
            List<Contact> contacts = new List<Contact>();

            int compteurContact = 0;


            DatabaseManager databaseManager = new DatabaseManager();


            while (true)
            {

                Console.WriteLine("Bienvenue sur l'application de gestion de contact par Erwan le goat");


                Console.WriteLine("****** Menu *******");

                Console.WriteLine("1. Ajouter contact");
                Console.WriteLine("2. Afficher contacts");
                Console.WriteLine("3. Recherche un contact");
                Console.WriteLine("4. Modifier un contact");
                Console.WriteLine("5. Supprimer contact");
                Console.WriteLine("6. Quitter");

                string menuReponseUti = Console.ReadLine();


                


                switch (menuReponseUti)

                {
                    case "1":

                        Console.Write("Veuillez entrer un nom :");
                        string reponseUtiAjouterNom = Console.ReadLine();

                        Console.Write("Veuillez entrer un email :");
                        string reponseUtiAjouterEmail = Console.ReadLine();


                        Console.Write("Veuillez entrer un Telephone :");
                        int reponseUtiAjouterTelephone = Convert.ToInt32(Console.ReadLine());

                        databaseManager.InsertContact(reponseUtiAjouterNom, reponseUtiAjouterEmail, reponseUtiAjouterTelephone);

                        compteurContact++;

                        if (contacts.Count > 0 )
                        {
                            Console.WriteLine("Utilisateur crée");
                        }

                        
                        break;

                    case "2":
                        Console.WriteLine("On va afficher les contact si dessous : ");

                        databaseManager.AfficheContact();

                        Console.Write("Voulez vous revenir au menu principal ?");
                        string reponseUtiRetourAuMenu = Console.ReadLine();

                        if (reponseUtiRetourAuMenu == "Oui")
                        {
                            continue;
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine("Recherche de contact ( attention a la Case");
                        while (true)
                        {
                            Console.Write("A l'aide de quoi voulez vous trouver un contact ? \n 1. Nom \n 2. Email \n 3. Telephone \n");
                            string reponseUtiTypeRecherche = Console.ReadLine();

                            switch (reponseUtiTypeRecherche)
                            {
                                case "1":
                                    Console.Write("Taper le nom de la personne recherchée : ");
                                    string reponseUtiTypeRechercheNom = Console.ReadLine();

                                    databaseManager.RechercheContactNom(reponseUtiTypeRechercheNom);
                                    break;
                                
                                case "2":
                                    Console.WriteLine("Taper l'email de la personne rechercher");
                                    string reponseUtiTypeRechercheEmail = Console.ReadLine();

                                    databaseManager.RechercheContactNom(reponseUtiTypeRechercheEmail);

                                    break;

                                case "3":
                                    Console.WriteLine("Taper le telephone la personne rechercher");
                                    string reponseUtiTypeRechercheTelephone = Console.ReadLine();

                                    databaseManager.RechercheContactNom(reponseUtiTypeRechercheTelephone);


                                    break;

                            }

                            Console.Write("Voulez vous refaire une recherche ?");
                            string reponseUtiNouvelleRecherche = Console.ReadLine();

                        if (reponseUtiNouvelleRecherche == "Non")
                        {
                            break;
                        }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Modification de contact");

                        while (true)
                        {


                            databaseManager.AfficheModifierContact();

                            Console.Write("Taper l'ID du contact que vous souhaitez modifier : ");
                            string reponseUtiModifContact = Console.ReadLine();



                            
                            Console.Write("Entrez le nouveau nom : ");
                            string reponseUtiModifContactNom = Console.ReadLine();

                            Console.Write("Entrez le nouveau email : ");
                            string reponseUtiModifContactEmail = Console.ReadLine();

                            Console.Write("Entrez le nouveau telephone : ");
                            string reponseUtiModifContactTelephone = Console.ReadLine();

                            int reponseUtiModifContactTelephoneConvert = Convert.ToInt32( reponseUtiModifContactTelephone );

                            databaseManager.ModifierContact(reponseUtiModifContactNom, reponseUtiModifContactEmail, reponseUtiModifContactTelephone, reponseUtiModifContact);

                            Console.Write("Voulez vous revenir au menu principal ?");
                            string reponseUtiRetourAuMenuModif = Console.ReadLine();

                            if (reponseUtiRetourAuMenuModif == "Oui")
                            {
                                break;
                            }



                            break;
                        }

                        break;
                    case "5":
                        Console.WriteLine("Supprimer un contact");
                        while (true)
                        {

                            databaseManager.AfficheModifierContact();

                            Console.Write("Taper le numero du contact que vous souhaitez supprimer : ");
                            string reponseUtiSuppContact = Console.ReadLine();



                            databaseManager.SupprimerContact(reponseUtiSuppContact);


                            Console.Write("Voulez vous revenir au menu principal ?");
                            string reponseUtiRetourAuMenuModif = Console.ReadLine();

                            if (reponseUtiRetourAuMenuModif == "Oui")
                            {
                                break;
                            }








                        }
                        break;
                }


                if (menuReponseUti == "6")
                {
                    return;
                }

            }


            
    }
}
}
