using creervueauto.Modeles;
using System.Collections.ObjectModel;
using System.Text;

namespace creervueauto.Vues;

public partial class AccueilPage : ContentPage
{
    Table newTable = null;
    string viewName = null;
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

        AttributeNameEntry.Text = "";
        TypologyPicker.SelectedIndex = 0;
        // Affichez un message ou mettez � jour l'UI ici si n�cessaire
    }


    private void AddCreatViewTable_Clicked(object sender, EventArgs e)
    {
        if (newTable == null || newTable.LesAttributs.Count == 0)
        {
            DisplayAlert("Erreur", "Veuillez d'abord cr�er une table et ajouter des attributs.", "OK");
            return;
        }

        viewName = "View_" + Guid.NewGuid().ToString("N"); // Nom al�atoire pour la vue
        StringBuilder viewColumns = new StringBuilder();
        StringBuilder selectColumns = new StringBuilder();

        foreach (var attribut in newTable.LesAttributs)
        {
            string decalAttribut = DecalerLettres(attribut.Nom);
            viewColumns.Append($"{decalAttribut}, ");
            selectColumns.Append($"{attribut.Nom}, ");
        }

        // Retirer la derni�re virgule et espace de chaque StringBuilder
        viewColumns.Length -= 2;
        selectColumns.Length -= 2;

        // Combiner les parties pour former la requ�te compl�te
        string createViewQuery = $"CREATE VIEW {viewName} ({viewColumns}) AS SELECT {selectColumns} FROM {newTable.Nom}";

        GeneratedViewEditor.Text = createViewQuery;
    }



    private string DecalerLettres(string input)
    {
        return new string(input.Select(c =>
        {
            if (!char.IsLetter(c)) return c; // Garde les caract�res non alphab�tiques tels quels
            char offset = char.IsUpper(c) ? 'A' : 'a';
            return (char)(((c + 1 - offset) % 26) + offset);
        }).ToArray());
    }

    private void GenerateModifiedQueryButton_Clicked(object sender, EventArgs e)
    {
        if (newTable == null || newTable.LesAttributs.Count == 0 || string.IsNullOrEmpty(viewName))
        {
            DisplayAlert("Erreur", "Veuillez d'abord cr�er la vue de la table.", "OK");
            return;
        }

        StringBuilder selectQuery = new StringBuilder($"SELECT ");

        foreach (var attribut in newTable.LesAttributs)
        {
            string decalAttribut = DecalerLettres(attribut.Nom);
            selectQuery.Append($"{decalAttribut}, ");
        }

        // Retirer la derni�re virgule et espace
        selectQuery.Length -= 2;
        selectQuery.Append($" FROM {viewName}");

        ModifiedQueryEditor.Text = selectQuery.ToString();
    }


}


