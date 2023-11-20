using creervueauto.Modeles;
using System.Collections.ObjectModel;

namespace creervueauto.Vues;

public partial class AccueilPage : ContentPage
{
    Table newTable = null;
    public AccueilPage()
    {
        InitializeComponent();

        // Créer et ajouter des typologies
        new Typologie("int");
       new Typologie("string");

        // Assigner la source de données et la propriété à afficher
        TypologyPicker.ItemsSource = Typologie.CollClasse;
        TypologyPicker.ItemDisplayBinding = new Binding("Nom");

        // Sélectionner le premier élément par défaut
        TypologyPicker.SelectedIndex = 0;

    }
    private void CreateTableButton_Clicked(object sender, EventArgs e)
    {
        string tableName = TableNameEntry.Text;
        newTable = new Table(tableName);
        // Vous pouvez ajouter ici plus de logique, comme mettre à jour un élément UI pour afficher la nouvelle table.

    }
    private void AddAttributeButton_Clicked(object sender, EventArgs e)
    {
        if (newTable == null)
        {
            DisplayAlert("Erreur", "Veuillez d'abord créer une table.", "OK");
            return;
        }

        string attributeName = AttributeNameEntry.Text;
        string typologySelected = TypologyPicker.SelectedItem.ToString();

        Typologie typologie = new Typologie(typologySelected);
        Attributs newAttribute = new Attributs(attributeName, false, typologie); // false pour clePrimaire, ajustez selon vos besoins
        newTable.LesAttributs.Add(newAttribute);

        // Affichez un message ou mettez à jour l'UI ici si nécessaire
    }
}
