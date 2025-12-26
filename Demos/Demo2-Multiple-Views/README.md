# Demo 2: Multiple Views du même data

**Timing**: ~7 minutes
**Objectif**: Démontrer la synchronisation automatique entre plusieurs vues des mêmes données

---

## Vue d'ensemble

Cette démo montre comment les mêmes données peuvent être affichées simultanément dans plusieurs contrôles sans code de synchronisation manuel.

- **WinForms**: Events partout pour maintenir la sync entre contrôles
- **Avalonia MVVM**: Une source de vérité, binding automatique

---

## Structure

```
Demo2-Multiple-Views/
├── README.md                    (ce fichier)
├── WinForms-MultipleViews/      (projet WinForms)
│   └── (à créer)
└── Avalonia-MultipleViews/      (projet Avalonia)
    └── (à créer)
```

---

## Concept WinForms (synchronisation manuelle)

**UI à implémenter**:
- ListBox (liste des items)
- TreeView (même items groupés par catégorie)
- Label (compteur: "X items")
- Boutons Add/Remove

**Code nécessaire**:
```csharp
// Event handler pour synchroniser ListBox → TreeView
private void listBox_SelectedIndexChanged(object sender, EventArgs e)
{
    if (listBox.SelectedItem != null)
    {
        // Trouver et sélectionner dans le TreeView
        var item = (Item)listBox.SelectedItem;
        var node = FindNodeInTreeView(item);
        treeView.SelectedNode = node;
    }
}

// Event handler pour synchroniser TreeView → ListBox
private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
{
    if (e.Node.Tag is Item item)
    {
        listBox.SelectedItem = item;
    }
}

// Ajouter un item
private void btnAdd_Click(object sender, EventArgs e)
{
    var item = new Item { Name = "New Item" };
    items.Add(item);

    // Mise à jour manuelle de TOUS les contrôles
    listBox.Items.Add(item);
    AddToTreeView(item); // Trouver la bonne catégorie, ajouter le node
    UpdateCounter();     // lblCount.Text = items.Count.ToString()
}

// Supprimer un item
private void btnRemove_Click(object sender, EventArgs e)
{
    if (listBox.SelectedItem != null)
    {
        var item = (Item)listBox.SelectedItem;
        items.Remove(item);

        // Mise à jour manuelle de TOUS les contrôles
        listBox.Items.Remove(item);
        RemoveFromTreeView(item); // Trouver et supprimer le node
        UpdateCounter();
    }
}
```

**Problèmes**:
- Code de synchronisation dispersé partout
- Facile d'oublier de mettre à jour un contrôle
- Risque de désynchronisation
- Difficile à tester
- Beaucoup de boilerplate

---

## Concept Avalonia MVVM (une source de vérité)

**ViewModel**:
```csharp
public class MainViewModel : ViewModelBase
{
    // UNE SEULE source de vérité!
    public AvaloniaList<ItemViewModel> Items { get; } = new();

    [ObservableProperty]
    private ItemViewModel? selectedItem;

    [RelayCommand]
    private void AddItem()
    {
        var newItem = new ItemViewModel { Name = $"Item {Items.Count + 1}" };
        Items.Add(newItem);
    }

    [RelayCommand]
    private void RemoveItem()
    {
        if (SelectedItem != null)
        {
            Items.Remove(SelectedItem);
        }
    }
}

public class ItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string category = "General";
}
```

**XAML** (ZÉRO code-behind!):
```xaml
<Grid RowDefinitions="*,Auto" ColumnDefinitions="*,*">
    <!-- ListBox -->
    <ListBox Grid.Row="0" Grid.Column="0"
             Items="{Binding Items}"
             SelectedItem="{Binding SelectedItem}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}" />
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>

    <!-- TreeView -->
    <TreeView Grid.Row="0" Grid.Column="1"
              Items="{Binding Items}"
              SelectedItem="{Binding SelectedItem}">
        <!-- Configuration TreeView... -->
    </TreeView>

    <!-- Compteur -->
    <StackPanel Grid.Row="1" Grid.ColumnSpan="2" Orientation="Horizontal">
        <TextBlock Text="Total: " />
        <TextBlock Text="{Binding Items.Count}" FontWeight="Bold" />
        <TextBlock Text=" items" />

        <Button Content="Add" Command="{Binding AddItemCommand}" Margin="10,0,0,0" />
        <Button Content="Remove" Command="{Binding RemoveItemCommand}" Margin="5,0,0,0" />
    </StackPanel>
</Grid>
```

**Avantages**:
- ✅ **ZÉRO code de synchronisation**
- ✅ Impossible d'oublier de mettre à jour une vue
- ✅ Pattern RDM: Binding direct sur `Items.Count` sans fallback null
- ✅ Toutes les modifications propagées automatiquement
- ✅ ViewModel testable sans UI

---

## Scénarios à démontrer en live

1. **Ajouter un item**:
   - Cliquer "Add"
   - Item apparaît dans ListBox ET TreeView
   - Compteur s'incrémente automatiquement

2. **Sélectionner dans ListBox**:
   - Cliquer sur un item dans ListBox
   - Sélection change automatiquement dans TreeView

3. **Sélectionner dans TreeView**:
   - Cliquer sur un item dans TreeView
   - Sélection change automatiquement dans ListBox

4. **Supprimer un item**:
   - Sélectionner un item
   - Cliquer "Remove"
   - Disparaît des deux vues + compteur décrémente

---

## Points clés à souligner

1. **WinForms**: Event handlers partout, synchronisation manuelle fragile
2. **Avalonia**: Une seule collection dans le ViewModel, tout se synchronise automatiquement
3. **Pattern RDM**: `AvaloniaList` avec binding direct sur `Count`
4. **Testabilité**: ViewModel peut être testé unitairement (ajouter item, vérifier Count)
5. **Maintenance**: Ajouter une 3e vue? Juste ajouter le binding, aucun code de sync!

---

## Extension possible (si temps)

Montrer qu'on peut facilement ajouter une **troisième vue** (par exemple, un DataGrid) sans aucun code de synchronisation supplémentaire:

```xaml
<DataGrid Grid.Row="2" Grid.ColumnSpan="2"
          Items="{Binding Items}"
          SelectedItem="{Binding SelectedItem}" />
```

Boom! Automatiquement synchronisé avec les deux autres vues.

---

**Status**: 📋 Planifié - Projets à créer
