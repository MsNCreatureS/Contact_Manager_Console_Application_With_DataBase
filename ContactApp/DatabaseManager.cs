using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ContactApp
{
    public class DatabaseManager
    {
        // La chaîne de connexion - ADAPTE le nom de ta BDD si nécessaire !
        private string connectionString = "Server=localhost;Database=contact_manager;Uid=root;Pwd=;";

        // Ici on va ajouter nos méthodes
        public void InsertContact(string Nom, string Email, int Telephone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO contacts (Nom, Email, Telephone) VALUES (@Nom, @Email, @Telephone)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@Nom", Nom);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Telephone", Telephone);
                connection.Open();
                cmd.ExecuteNonQuery(); // Execute the insert command
            }
        }

        public void AfficheContact()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string requeteAfficheContact = "SELECT * FROM Contacts"; 

                MySqlCommand commande = new MySqlCommand(requeteAfficheContact, connection);

                connection.Open();
                
                using (MySqlDataReader affichage = commande.ExecuteReader())
                {
                    while (affichage.Read())
                    {
                        Console.WriteLine($"Nom : {affichage["Nom"]}, Email : {affichage["Email"]}, Telephone: {affichage["Telephone"]}");
                    }

                }
            }
        }

        public void RechercheContactNom(string Nom)
        {
            using ( var connection = new MySqlConnection(connectionString))
            {
                string requeteRechercheContatctNom = "SELECT * FROM Contacts WHERE Nom LIKE @Nom";


                MySqlCommand CommmandeRechercheNom = new MySqlCommand(requeteRechercheContatctNom, connection);


                // Add parameters to prevent SQL injection
                CommmandeRechercheNom.Parameters.AddWithValue("@Nom", Nom + "%");
                
                connection.Open();

                using (MySqlDataReader affichageRechercheNom = CommmandeRechercheNom.ExecuteReader())
                {
                    while (affichageRechercheNom.Read())
                    {
                        Console.WriteLine($"Nom : {affichageRechercheNom["Nom"]}, Email : {affichageRechercheNom["Email"]}, Telephone: {affichageRechercheNom["Telephone"]}");
                    }
                }
             
                


            }
        }

        public void RechercheContactEmail(string Email)
        {

            using (var connection = new MySqlConnection(connectionString))
            {

                string requeteRechercheContatctEmail = "SELECT * FROM Contacts WHERE SELECT * FROM contacts WHERE Email LIKE '@Email'";

                MySqlCommand CommandeRechercheEmail = new MySqlCommand(requeteRechercheContatctEmail, connection);

                CommandeRechercheEmail.Parameters.AddWithValue("@Email", Email + "%");
                connection.Open();

                using (MySqlDataReader affichageRechercheEmail = CommandeRechercheEmail.ExecuteReader())
                {
                    while (affichageRechercheEmail.Read())
                    {
                        Console.WriteLine($"Nom : {affichageRechercheEmail["Nom"]}, Email : {affichageRechercheEmail["Email"]}, Telephone: {affichageRechercheEmail["Telephone"]}");
                    }
                }

            }

        }

        public void RechercheContactTelephone(string Telephone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {

                string requeteRechercheContatctTelephone = "SELECT * FROM Contacts WHERE SELECT * FROM contacts WHERE Telephone LIKE '@Telephone'";

                MySqlCommand CommandeRechercheTelephone = new MySqlCommand(requeteRechercheContatctTelephone, connection);

                CommandeRechercheTelephone.Parameters.AddWithValue("@Telephone", Telephone + "%");

                connection.Open();
                using (MySqlDataReader affichageRechercheTelephone = CommandeRechercheTelephone.ExecuteReader())
                {
                    while (affichageRechercheTelephone.Read())
                    {
                        Console.WriteLine($"Nom : {affichageRechercheTelephone["Nom"]}, Email : {affichageRechercheTelephone["Email"]}, Telephone: {affichageRechercheTelephone["Telephone"]}");
                    }
                }

            }

        }


        public void AfficheModifierContact()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string requeteAfficheContactModification = "SELECT * FROM Contacts";

                MySqlCommand CommandeAfficheContactModification = new MySqlCommand(requeteAfficheContactModification, connection);

                connection.Open();
                using (MySqlDataReader AfficheContactModification = CommandeAfficheContactModification.ExecuteReader())
                {
                    while (AfficheContactModification.Read())
                    {
                        Console.WriteLine($"ID : {AfficheContactModification["ID"]} ,Nom : {AfficheContactModification["Nom"]}, Email : {AfficheContactModification["Email"]}, Telephone: {AfficheContactModification["Telephone"]}");
                    }
                }

            }
        }

        public void ModifierContact(string Nom , string Email , string Telephone , string ID)
        {
           using (var connection = new MySqlConnection(connectionString))
            {
                string requeteModifierContact = "UPDATE contacts SET Nom = @Nom , Email = @Email , Telephone = @Telephone WHERE ID = @ID";

                MySqlCommand commandeModifierContact = new MySqlCommand(requeteModifierContact, connection);
                commandeModifierContact.Parameters.AddWithValue("@Nom", Nom);
                commandeModifierContact.Parameters.AddWithValue("@Email", Email);
                commandeModifierContact.Parameters.AddWithValue("@Telephone", Telephone);
                commandeModifierContact.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                commandeModifierContact.ExecuteNonQuery(); // Execute the insert command
                Console.WriteLine("Contact modifier avec succès");
            }
        }

        public void SupprimerContact(string ID)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string requeteSupprimerContact = "DELETE FROM contacts WHERE ID = @ID";
                MySqlCommand commandeSupprimerContact = new MySqlCommand(requeteSupprimerContact, connection);
                commandeSupprimerContact.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                commandeSupprimerContact.ExecuteNonQuery ();
                Console.WriteLine("Contact supprimer avec succès");

            }
        }

    }
}