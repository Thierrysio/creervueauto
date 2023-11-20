using creervueauto.Modeles;
using System.Collections.ObjectModel;

namespace creervueauto.Vues;

public partial class AccueilPage : ContentPage
{
    Table newTable = null;
    public AccueilPage()
    {
        InitializeComponent();

        // Cr�er et ajouter des typologies
        new Typologie("int");
       new Typologie("string");

        // Assigner la source de donn�es et la propri�t� � afficher
        TypologyPicker.ItemsSource = Typologie.CollClasse;
        TypologyPicker.ItemDisplayBinding = new Binding("Nom");

        // S�lectionner le premier �l�ment par d�faut
        TypologyPicker.SelectedIndex = 0;

    }
    private void CreateTableButton_Clicked(object sender, EventArgs e)
    {
        string tableName = TableNameEntry.Text;
        newTable = new Table(tableName);
        // Vous pouvez ajouter ici plus de logique, comme mettre � jour un �l�ment UI pour afficher la nouvelle table.

    }
    private void AddAttributeButton_Clicked(object sender, EventArgs e)
    {
        if (newTable == null)
        {
            DisplayAlert("Erreur", "Veuillez d'abord cr�er une table.", "OK");
            return;
        }

        string attributeName = AttributeNameEntry.Text;
        string typologySelected = TypologyPicker.SelectedItem.ToString();

        Typologie typologie = new Typologie(typologySelected);
        Attributs newAttribute = new Attributs(attributeName, false, typologie); // false pour clePrimaire, ajustez selon vos besoins
        newTable.LesAttributs.Add(newAttribute);

        // Affichez un message ou mettez � jour l'UI ici si n�cessaire
    }
}
