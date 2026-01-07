# CONTEXT - Aide-mémoire technique
**Projet**: Conférence MVVM pour DevoCongres 2026
**Dernière mise à jour**: 26 décembre 2024

---

## 📋 Vue d'ensemble

Ce document sert d'aide-mémoire pour maintenir le contexte des spécificités techniques et décisions architecturales du projet RDM, particulièrement dans le contexte de la préparation de la conférence MVVM.

**Objectif**: Permettre à Claude (et à vous) de se rappeler facilement de tous les détails techniques importants lors des sessions de travail futures.

---

## 🔧 Stack technique RDM

### Framework MVVM
- **Utilisé**: `CommunityToolkit.Mvvm` (Microsoft)
- **PAS utilisé**: ReactiveUI
- **Raison**: Plus simple à apprendre, adoption plus rapide par l'équipe

### Collections observables
- **✅ TOUJOURS UTILISÉ**: `AvaloniaList<T>`
- **❌ JAMAIS UTILISÉ**: `ObservableCollection<T>`
- **Règle RDM**: AvaloniaList doit TOUJOURS être priorisé pour les collections observables
- **Raisons principales**:
  1. **Opérations batch**: `AddRange()`, `RemoveRange()`, `InsertRange()`
  2. **Performance**: Une seule notification `CollectionChanged` au lieu de N notifications
  3. **Efficacité UI**: Un seul layout update pour plusieurs items
  4. ObservableCollection peut être 10-100x plus lent pour opérations multiples
  5. **Standard RDM**: Cohérence à travers toute la codebase

---

## 🎯 Patterns et pratiques RDM

### 1. Pattern de collection mutable auto-initialisée

**Code standard dans RDM**:
```csharp
public AvaloniaList<ItemViewModel> Items { get; } = new();
```

**Caractéristiques**:
- Propriété `{ get; }` (readonly - pas de setter)
- Initialisée inline avec `= new()`
- Jamais null
- Collection mutable (on peut faire `.Add()`, `.Remove()`, etc.)

**Justifications**:
1. **Binding sur Count sans fallback**: Permet de faire `{Binding Items.Count}` sans se soucir d'un cas null
2. **Simplicité**: Pas besoin de vérifier null avant d'ajouter des items
3. **Immutabilité de la référence**: La référence ne change jamais, mais le contenu peut changer
4. **Pattern cohérent**: Toutes les collections suivent la même approche dans RDM
5. **Opérations batch**: Peut utiliser `Items.AddRange()` directement sans vérification null

**Exemple d'utilisation**:
```csharp
public class MainViewModel : ViewModelBase
{
    // Collection auto-initialisée
    public AvaloniaList<PageViewModel> Pages { get; } = new();

    // On peut directement ajouter sans vérifier null
    public void LoadPages()
    {
        Pages.Add(new PageViewModel("Home"));
        Pages.Add(new PageViewModel("Settings"));
    }

    // Opérations batch - UNE SEULE notification CollectionChanged!
    public void LoadManyPages()
    {
        var newPages = new[]
        {
            new PageViewModel("Home"),
            new PageViewModel("Settings"),
            new PageViewModel("About"),
            new PageViewModel("Profile")
        };

        Pages.AddRange(newPages); // ✅ Efficace!
        // vs Pages.Add() 4 fois = 4 notifications + 4 layout updates ❌
    }
}
```

**Dans le XAML**:
```xaml
<!-- Binding direct sur Count, aucun risque de null -->
<TextBlock Text="{Binding Items.Count}" />

<!-- Binding sur la collection -->
<ListBox Items="{Binding Items}" />
```

---

## 📝 CommunityToolkit.Mvvm - Rappels

### Attributs principaux

#### `[ObservableProperty]`
```csharp
[ObservableProperty]
private string name;
// Génère automatiquement:
// public string Name { get; set; } avec INotifyPropertyChanged
```

#### `[RelayCommand]`
```csharp
[RelayCommand]
private void SaveData()
{
    // Logic here
}
// Génère automatiquement:
// public ICommand SaveDataCommand { get; }
```

#### Convention de nommage
- Champ privé: `camelCase` ou `_camelCase`
- Propriété générée: `PascalCase`
- Commande générée: `{MethodName}Command`

---

## 🎤 Contexte de la conférence

### Informations générales
- **Date**: 22 janvier 2025
- **Durée**: 45 minutes (35 min présentation + 10 min Q&A)
- **Format**: Workshop avec PowerPoint + démos pratiques
- **Public cible**: Développeurs RDM qui connaissent WinForms
- **Langue**: **BILINGUE (Français-Anglais)** ⚠️ IMPORTANT

### Titre et description
**Français**: MVVM – Brisez les chaînes de la programmation événementielle
**Anglais**: MVVM - Cast off the shackles of event-driven development

### Objectifs
1. Comprendre les avantages de l'architecture MVVM
2. Prendre connaissance de son utilisation dans RDM présentement
3. Faciliter l'entrée au développement d'Avalonia

### 📊 Templates PowerPoint

**Fichiers disponibles dans `/Templates/`**:

1. **`template-DevoCongres_2026.pptx`**
   - Template officiel à utiliser pour créer les diapositives
   - Contient le design et la mise en page standard DevoCongres

2. **`Exemple-Bilingue.pptx`**
   - Exemple de présentation bilingue (format français-anglais)
   - ⚠️ **NOTE IMPORTANTE**: Le contenu de cet exemple est hors sujet
   - À utiliser UNIQUEMENT comme référence pour le format bilingue
   - Ne PAS s'inspirer du contenu, seulement de la structure bilingue

### Format bilingue requis
Toutes les diapositives doivent présenter:
- Contenu en **français** (côté gauche ou partie supérieure)
- Contenu en **anglais** (côté droit ou partie inférieure)
- Ou utiliser le format de l'exemple bilingue fourni

**Pattern observé dans Exemple-Bilingue.pptx**:
- Français d'abord (taille normale, texte en gras)
- Anglais ensuite (taille légèrement plus petite, texte en italique)
- Séparés par paragraphes dans le même bloc de texte
- Exemple:
  - FR: "PAM – C'est complexe, mais pas trop." (taille 32pt, gras)
  - EN: "A PAM solution is..." (taille 20pt, italique)

---

## 💡 Démonstrations clés

**3 démos sélectionnées** pour maximiser l'impact et le temps (35 min total avec théorie):
1. Master-Detail Pattern (~10 min) - LE mind shift fondamental
2. Multiple Views du même data (~7 min) - Synchronisation automatique
3. Composition dynamique de formulaires (~8 min) - Génération d'UI déclarative

---

### Demo 1: Master-Detail Pattern (LA STAR DU SHOW)

**Pourquoi c'est important**: C'est LE meilleur exemple du "mind shift" entre WinForms et MVVM/Avalonia.

**Concept WinForms (complexe)**:
1. Charger les items dans ListView/TreeView
2. S'abonner à `SelectedIndexChanged` event
3. Utiliser switch/if pour déterminer quel contrôle afficher
4. Instancier et ajouter manuellement le contrôle dans le panel
5. Gérer le nettoyage du panel

**Concept Avalonia MVVM (simple)**:
1. ViewModels avec leur propre DataTemplate
2. Binding sur SelectedItem
3. ContentControl affiche automatiquement le bon template
4. AUCUN code-behind nécessaire

**Code exemple**:
```csharp
public class MainViewModel : ViewModelBase
{
    public AvaloniaList<PageViewModelBase> Pages { get; } = new();

    [ObservableProperty]
    private PageViewModelBase? selectedPage;
}
```

```xaml
<Grid>
    <ListBox Grid.Column="0"
             Items="{Binding Pages}"
             SelectedItem="{Binding SelectedPage}" />

    <ContentControl Grid.Column="1"
                    Content="{Binding SelectedPage}" />
</Grid>
```

---

### Demo 2: Multiple Views du même data

**Pourquoi c'est important**: Démontre la synchronisation automatique, impossible à gérer élégamment en WinForms sans code partout.

**Concept WinForms (synchronisation manuelle)**:
1. ListBox ET TreeView montrant les mêmes données
2. Event handlers partout pour maintenir la sync:
   - `ListBox.SelectedIndexChanged` → update TreeView
   - `TreeView.AfterSelect` → update ListBox
   - Add/Remove → update les deux + le compteur
3. Facile d'oublier un cas et perdre la synchronisation
4. Code de synchronisation dispersé

**Concept Avalonia MVVM (une source de vérité)**:
1. Une seule `AvaloniaList<T>` dans le ViewModel
2. Plusieurs contrôles bindés à la même collection
3. Modifications automatiquement propagées partout
4. ZÉRO code de synchronisation

**Code exemple**:
```csharp
public class MainViewModel : ViewModelBase
{
    public AvaloniaList<ItemViewModel> Items { get; } = new();

    [ObservableProperty]
    private ItemViewModel? selectedItem;

    [RelayCommand]
    private void AddItem() => Items.Add(new ItemViewModel());
}
```

```xaml
<!-- Toutes ces vues sont automatiquement synchronisées! -->
<ListBox Items="{Binding Items}"
         SelectedItem="{Binding SelectedItem}" />

<TreeView Items="{Binding Items}"
          SelectedItem="{Binding SelectedItem}" />

<TextBlock Text="{Binding Items.Count}" />
```

**Démonstration**:
- Ajouter un item → apparaît dans ListBox ET TreeView, compteur s'incrémente
- Sélectionner dans ListBox → sélection change dans TreeView
- Supprimer → disparaît de partout automatiquement

---

### Demo 3: Composition dynamique de formulaires

**Pourquoi c'est important**: Montre un avantage **impossible** à répliquer élégamment en WinForms. Génération d'UI basée sur métadonnées.

**Concept WinForms (impératif - usine à code)**:
```csharp
// Boucle qui crée manuellement chaque contrôle
int yPosition = 10;
foreach (var field in fields)
{
    var label = new Label
    {
        Text = field.Name,
        Location = new Point(10, yPosition),
        AutoSize = true
    };

    Control inputControl;
    switch (field.Type) // Switch pour choisir le type
    {
        case FieldType.Text:
            inputControl = new TextBox { Location = new Point(150, yPosition) };
            break;
        case FieldType.Dropdown:
            inputControl = new ComboBox { /* ... */ };
            break;
    }

    panel.Controls.Add(label);
    panel.Controls.Add(inputControl);
    yPosition += 30; // Calcul manuel de position!
}
```

Problèmes:
- Calcul manuel de positions (x, y)
- Switch/if pour chaque type de champ
- Events manuels pour validation
- Difficile à maintenir et étendre

**Concept Avalonia MVVM (déclaratif)**:
```csharp
// ViewModels représentent les types de champs
public abstract class FieldViewModelBase : ViewModelBase
{
    [ObservableProperty]
    private string label = string.Empty;
}

public class TextFieldViewModel : FieldViewModelBase
{
    [ObservableProperty]
    private string value = string.Empty;
}

public class DropdownFieldViewModel : FieldViewModelBase
{
    public AvaloniaList<string> Options { get; } = new();

    [ObservableProperty]
    private string? selectedOption;
}

// ViewModel principal
public class FormViewModel : ViewModelBase
{
    public AvaloniaList<FieldViewModelBase> Fields { get; } = new();

    public FormViewModel()
    {
        // Charger depuis métadonnées ou DB
        Fields.AddRange(new FieldViewModelBase[]
        {
            new TextFieldViewModel { Label = "Name" },
            new DropdownFieldViewModel
            {
                Label = "Country",
                Options = { "Canada", "USA", "UK" }
            },
            new CheckboxFieldViewModel { Label = "Subscribe" }
        });
    }
}
```

```xaml
<ItemsControl Items="{Binding Fields}">
  <ItemsControl.DataTemplates>
    <!-- Template pour TextBox -->
    <DataTemplate DataType="vm:TextFieldViewModel">
      <StackPanel Orientation="Horizontal" Margin="5">
        <TextBlock Text="{Binding Label}" Width="150" />
        <TextBox Text="{Binding Value}" Width="200" />
      </StackPanel>
    </DataTemplate>

    <!-- Template pour Dropdown -->
    <DataTemplate DataType="vm:DropdownFieldViewModel">
      <StackPanel Orientation="Horizontal" Margin="5">
        <TextBlock Text="{Binding Label}" Width="150" />
        <ComboBox Items="{Binding Options}"
                  SelectedItem="{Binding SelectedOption}"
                  Width="200" />
      </StackPanel>
    </DataTemplate>

    <!-- Autres templates... -->
  </ItemsControl.DataTemplates>
</ItemsControl>
```

**Avantages**:
- **Aucun calcul de position**: StackPanel gère le layout
- **Aucun switch**: DataTemplates automatiquement appliqués selon le type
- **Extensible**: Nouveau type de champ = nouveau ViewModel + nouveau DataTemplate
- **Testable**: ViewModel complètement séparé de l'UI
- **Pattern RDM**: `Fields.AddRange()` pour batch operations

**Cas d'utilisation réels**:
- Configuration wizard avec étapes dynamiques
- Formulaires générés depuis base de données
- Éditeur de propriétés générique
- Formulaires conditionnels multi-étapes

---

## 📚 Notes additionnelles

### Section pour ajouts futurs

#### [26 décembre 2024] - Décisions prises lors de la session initiale

**Démos finales sélectionnées**:
- ✅ Master-Detail Pattern (LA STAR - mind shift fondamental)
- ✅ Multiple Views du même data (synchronisation automatique)
- ✅ Composition dynamique de formulaires (génération d'UI déclarative)

**Démos rejetées** (et pourquoi):
- ❌ Counter Simple - Trop basique, pas assez impressionnant
- ❌ Form Validation - Bon mais pas assez spectaculaire
- ❌ État d'interface en cascade - RDM a déjà SetControlStates() qui atténue le problème
- ❌ Validation croisée - Aussi atténué par SetControlStates()

**Raison du choix final**:
Les 3 démos choisies montrent des avantages **impossibles ou très difficiles** à reproduire en WinForms, plutôt que des avantages qui sont "juste plus élégants".

**Timing validé**:
- PowerPoint théorie: ~10 min
- Demo 1: ~10 min
- Demo 2: ~7 min
- Demo 3: ~8 min
- **Total: 35 min + 10 min Q&A = 45 min parfait**

**Points à ne pas oublier**:
1. Toujours mentionner que MVVM a été créé par Microsoft **pour** simplifier event-driven UI
2. Insister sur le fait que MVVM n'élimine pas les events, mais les organise mieux
3. Pattern RDM d'AvaloniaList auto-initialisée est utilisé PARTOUT dans RDM
4. CommunityToolkit.Mvvm réduit drastiquement le boilerplate (montrer avant/après)

---

## 🔗 Liens importants

### Documentation
- [Avalonia Docs - MVVM Pattern](https://docs.avaloniaui.net/docs/concepts/the-mvvm-pattern)
- [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- [Avalonia Samples](https://github.com/AvaloniaUI/Avalonia.Samples)

### Tutoriels utilisés
- [ToDo App avec CommunityToolkit](https://medium.com/@artillustration391/simple-todo-list-in-avalonia-740ac520385f)
- [Guide DEV.to](https://dev.to/ghostkeeper10/how-to-use-community-toolkit-mvvm-in-avalonia-39af)

---

## ✅ Checklist de rappel rapide

Quand vous (ou Claude) revenez travailler sur ce projet:

- [ ] Lire CLAUDE.md pour la vue d'ensemble
- [ ] Consulter PLAN.md pour voir la progression
- [ ] Relire ce document (CONTEXT.md) pour les spécificités techniques
- [ ] Vérifier la section "Notes additionnelles" pour les derniers ajouts

---

**Note**: Ce document doit être mis à jour régulièrement avec toute nouvelle information importante ou décision technique prise pendant le développement du matériel de conférence.
