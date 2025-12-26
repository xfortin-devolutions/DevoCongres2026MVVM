# Plan de préparation - Conférence MVVM Workshop
**Date de présentation**: 22 janvier 2025
**Durée**: 45 minutes (35 min présentation + 10 min Q&A)
**Format**: Workshop avec PowerPoint + démonstrations pratiques

---

## Objectifs de la présentation
- ✅ Comprendre les avantages de l'architecture MVVM
- ✅ Prendre connaissance de son utilisation dans RDM présentement
- ✅ Faciliter l'entrée au développement d'Avalonia

---

## Spécificités techniques RDM à intégrer

### 🔧 Stack technique
- **Framework MVVM**: CommunityToolkit.Mvvm (PAS ReactiveUI)
- **Collections**: AvaloniaList (PAS ObservableCollection)

### 📋 Patterns et pratiques RDM
**Pattern de collection mutable auto-initialisée**:
```csharp
// Pattern adopté dans RDM
public AvaloniaList<ItemViewModel> Items { get; } = new();
```
**Justification**:
- Propriété readonly (jamais null)
- Permet binding direct sur `Count` sans fallback pour null
- Simplifie la gestion des collections dans les ViewModels

**Points à expliquer dans la présentation**:
- Pourquoi AvaloniaList vs ObservableCollection
- Avantages du pattern auto-initialisé
- Impact sur le binding et la maintenance du code

---

## Phase 1: Structure du projet ✅ COMPLÉTÉ
- [x] Créer dossiers pour présentation, démos et ressources
- [x] Organiser la structure suivante:
```
/Presentation
  - slides/ (PowerPoint ou Markdown)
  - script-presentation.md
/Demos
  /Demo1-Master-Detail
  /Demo2-Multiple-Views
  /Demo3-Dynamic-Form-Composition
/Resources
  - sources.md
  - reference-rapide.md
  - exemples-code-rdm.md
```

---

## Phase 2: Contenu PowerPoint (15-20 diapositives)

### ⚠️ IMPORTANT: Format bilingue requis
- Toutes les diapositives doivent être en **français ET anglais**
- Utiliser `Templates/template-DevoCongres_2026.pptx` comme base
- S'inspirer du format bilingue de `Templates/Exemple-Bilingue.pptx` (PAS du contenu!)

### Introduction (2-3 slides)
- [ ] Slide titre: "Brisez les chaînes de la programmation événementielle" / "Cast off the shackles of event-driven development"
- [ ] Slide contexte: Problèmes avec event-driven pur (FR/EN)
- [ ] Slide objectifs de la session (FR/EN)

### Théorie MVVM (6-8 slides) - BILINGUE
- [ ] Définition des 3 couches (Model, View, ViewModel) - FR/EN
- [ ] Diagramme architecture événementielle vs MVVM - FR/EN
- [ ] Avantages MVVM - FR/EN:
  - Testabilité (ViewModel indépendant de la UI)
  - Séparation des préoccupations
  - Maintenabilité et réutilisabilité
  - Binding bidirectionnel automatique
- [ ] Data Binding et INotifyPropertyChanged expliqués - FR/EN
- [ ] Introduction à CommunityToolkit.Mvvm - FR/EN:
  - `[ObservableProperty]`
  - `[RelayCommand]`
  - Génération de code automatique

### MVVM dans RDM (3-4 slides) - BILINGUE
- [ ] Utilisation actuelle dans votre contexte - FR/EN
- [ ] Pattern de collections (AvaloniaList auto-initialisée) - FR/EN
- [ ] Exemples concrets du projet RDM - FR/EN
- [ ] Bonnes pratiques adoptées par l'équipe - FR/EN

### Transition vers les démos (1 slide) - BILINGUE
- [ ] Présentation des 3 démonstrations côte-à-côte - FR/EN
  - Demo 1: Master-Detail Pattern (LE mind shift)
  - Demo 2: Multiple Views (synchronisation magique)
  - Demo 3: Composition dynamique (génération d'UI)

---

## Phase 3: Projets de démonstration

**Note**: 3 démos sélectionnées pour démontrer les avantages les plus spectaculaires de MVVM
- **Timing total**: ~25 minutes de démos
- **Ordre**: Du fondamental (Master-Detail) vers le plus avancé (Composition dynamique)

---

### Demo 1: Master-Detail Pattern ⭐⭐⭐⭐⭐
**Timing**: ~10 minutes (LA STAR du show)
**Objectif**: LE "mind shift" WinForms → Avalonia/MVVM

**WinForms (Event-driven)**:
- [ ] Créer ListView/TreeView + Panel à droite
- [ ] Charger les items dans ListView
- [ ] Event handler `SelectedIndexChanged`
- [ ] Switch/if pour déterminer quel contrôle afficher
- [ ] Instancier et ajouter manuellement le contrôle dans le panel
- [ ] Gérer la logique de nettoyage du panel

**Avalonia (MVVM)**:
- [ ] Créer ListBox + ContentControl
- [ ] ViewModels qui possèdent leur propre DataTemplate
- [ ] Binding simple:
  ```xaml
  <ListBox Items="{Binding Items}"
           SelectedItem="{Binding SelectedItem}" />
  <ContentControl Content="{Binding SelectedItem}" />
  ```
- [ ] Aucun code-behind nécessaire!

**Points clés à souligner**:
- **C'est LE meilleur exemple du paradigm shift**
- Élimination complète de la logique de switch/if
- DataTemplates auto-appliqués selon le type
- Binding automatique sur SelectedItem
- Code dramatiquement plus simple et maintenable

**Code exemple RDM à montrer**:
```csharp
public class MainViewModel : ViewModelBase
{
    public AvaloniaList<PageViewModelBase> Pages { get; } = new();

    [ObservableProperty]
    private PageViewModelBase? selectedPage;
}
```

---

### Demo 2: Multiple Views du même data ⭐⭐⭐⭐
**Timing**: ~7 minutes
**Objectif**: Synchronisation automatique entre plusieurs vues des mêmes données

**WinForms (Event-driven)**:
- [ ] Créer projet WinForms avec ListBox + TreeView + Label (compteur)
- [ ] Même collection de données affichée dans les deux contrôles
- [ ] Event handlers pour synchroniser:
  - `ListBox.SelectedIndexChanged` → Sélectionner dans TreeView
  - `TreeView.AfterSelect` → Sélectionner dans ListBox
  - Quand on ajoute/supprime → Mettre à jour les deux + le compteur
- [ ] Code de synchronisation partout, facile d'oublier un cas

**Avalonia (MVVM)**:
- [ ] Créer projet Avalonia avec ListBox + TreeView + TextBlock
- [ ] ViewModel avec pattern RDM:
  ```csharp
  public AvaloniaList<ItemViewModel> Items { get; } = new();

  [ObservableProperty]
  private ItemViewModel? selectedItem;

  [RelayCommand]
  private void AddItem() => Items.Add(new ItemViewModel());
  ```
- [ ] Binding dans XAML:
  ```xaml
  <ListBox Items="{Binding Items}"
           SelectedItem="{Binding SelectedItem}" />
  <TreeView Items="{Binding Items}"
            SelectedItem="{Binding SelectedItem}" />
  <TextBlock Text="{Binding Items.Count}" />
  ```
- [ ] ZÉRO code de synchronisation!

**Points clés à souligner**:
- Une seule source de vérité (AvaloniaList dans le ViewModel)
- Modifications automatiquement propagées à toutes les vues
- Pattern RDM: binding direct sur Count sans fallback null
- Impossible d'oublier de synchroniser une vue
- ViewModel testable sans UI

**Exemple concret à montrer**:
- Ajouter un item → Apparaît dans les deux vues + compteur se met à jour
- Sélectionner dans ListBox → Sélection change dans TreeView
- Supprimer → Disparaît partout automatiquement

---

### Demo 3: Composition dynamique de formulaires ⭐⭐⭐⭐⭐
**Timing**: ~8 minutes
**Objectif**: Génération d'UI basée sur métadonnées (impossible à faire élégamment en WinForms)

**WinForms (Event-driven - usine à code)**:
- [ ] Créer projet WinForms avec Panel scrollable
- [ ] Classe `FieldMetadata` (Name, Type, DefaultValue, etc.)
- [ ] Boucle qui génère dynamiquement les contrôles:
  ```csharp
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
      switch (field.Type)
      {
          case FieldType.Text:
              inputControl = new TextBox
              {
                  Location = new Point(150, yPosition),
                  Width = 200
              };
              break;
          case FieldType.Dropdown:
              inputControl = new ComboBox { /* ... */ };
              break;
          // etc.
      }

      // Binding manuel des événements pour validation
      inputControl.TextChanged += (s, e) => ValidateField(field);

      panel.Controls.Add(label);
      panel.Controls.Add(inputControl);
      yPosition += 30; // Calcul manuel de position!
  }
  ```
- [ ] Démontrer la complexité: calcul de positions, switch, events manuels

**Avalonia (MVVM - déclaratif et élégant)**:
- [ ] Créer projet Avalonia
- [ ] ViewModels pour les champs:
  ```csharp
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

  // etc. pour Checkbox, DatePicker, etc.
  ```
- [ ] ViewModel principal:
  ```csharp
  public class FormViewModel : ViewModelBase
  {
      public AvaloniaList<FieldViewModelBase> Fields { get; } = new();

      public FormViewModel()
      {
          // Charger depuis métadonnées
          Fields.Add(new TextFieldViewModel { Label = "Name" });
          Fields.Add(new DropdownFieldViewModel
          {
              Label = "Country",
              Options = { "Canada", "USA", "UK" }
          });
          Fields.Add(new CheckboxFieldViewModel { Label = "Subscribe" });
      }
  }
  ```
- [ ] XAML avec DataTemplates:
  ```xaml
  <ItemsControl Items="{Binding Fields}">
    <ItemsControl.DataTemplates>
      <DataTemplate DataType="vm:TextFieldViewModel">
        <StackPanel Orientation="Horizontal" Margin="5">
          <TextBlock Text="{Binding Label}" Width="150" />
          <TextBox Text="{Binding Value}" Width="200" />
        </StackPanel>
      </DataTemplate>

      <DataTemplate DataType="vm:DropdownFieldViewModel">
        <StackPanel Orientation="Horizontal" Margin="5">
          <TextBlock Text="{Binding Label}" Width="150" />
          <ComboBox Items="{Binding Options}"
                    SelectedItem="{Binding SelectedOption}"
                    Width="200" />
        </StackPanel>
      </DataTemplate>

      <!-- Templates pour Checkbox, DatePicker, etc. -->
    </ItemsControl.DataTemplates>
  </ItemsControl>
  ```
- [ ] Aucun calcul de position! Aucun switch! Layout automatique!

**Points clés à souligner**:
- **WinForms = impératif**: "Créer contrôle, positionner, ajouter, gérer events"
- **Avalonia MVVM = déclaratif**: "Voici mes données, voici comment les afficher"
- Aucun calcul manuel de positions (StackPanel fait le travail)
- Ajouter un nouveau type de champ = ajouter un ViewModel + un DataTemplate
- Validation, binding, tout fonctionne automatiquement
- Pattern RDM: `Fields` auto-initialisée, peut utiliser `AddRange()`
- Extrêmement testable: tester le ViewModel sans UI

**Cas d'utilisation réel**:
- Configuration wizard avec étapes dynamiques
- Formulaires générés depuis une base de données
- Éditeur de propriétés générique
- Formulaires multi-étapes conditionnels

---

## Phase 4: Documentation et sources

### Sources officielles à compiler
- [ ] Avalonia Docs - The MVVM Pattern
- [ ] Microsoft Learn - CommunityToolkit.Mvvm
- [ ] Avalonia Samples Repository (exemples avec CommunityToolkit)
- [ ] Tutoriel DEV.to: "How to use Community Toolkit MVVM in Avalonia"

### Documents à créer
- [ ] **sources.md**: Références complètes avec URLs
- [ ] **reference-rapide.md**: Cheatsheet pour les participants
  - Syntaxe CommunityToolkit.Mvvm
  - Patterns de binding communs
  - Conventions de nommage
- [ ] **exemples-code-rdm.md**: Extraits de code spécifiques RDM
  - Pattern de collection AvaloniaList
  - Exemples de ViewModels utilisés dans RDM

### Script de présentation
- [ ] Écrire script détaillé avec timing:
  - Introduction: 3 min
  - Théorie MVVM: 8 min
  - RDM spécifique: 4 min
  - Demo 1: 4 min
  - Demo 2: 5 min
  - Demo 3: 8 min (emphasis!)
  - Demo 4: 3 min
  - Questions: 10 min
  - **Total: 45 min**

---

## Phase 5: Tests et révisions

### Tests techniques
- [ ] Tester toutes les démos sur machine de présentation
- [ ] Vérifier que les projets compilent et s'exécutent
- [ ] Préparer des solutions de backup si problème technique

### Répétition
- [ ] Chronométrer la présentation complète
- [ ] Ajuster le contenu selon le timing
- [ ] Préparer réponses aux questions fréquentes

### Ajustements finaux
- [ ] Recueillir feedback de collègues RDM
- [ ] Mettre l'emphase sur les concepts les plus pertinents pour l'équipe
- [ ] Ajuster les exemples RDM selon besoins

---

## Notes flexibles et ajustements

### Sections modulables
Cette section permettra d'ajouter des notes au fur et à mesure:

#### Concepts RDM à approfondir (à déterminer)
- [ ] _À remplir selon les discussions_

#### Exemples supplémentaires potentiels
- [ ] _À ajouter si nécessaire_

#### Points d'emphase particuliers
- [ ] _À définir selon contexte_

---

## Checklist finale (avant le 22 janvier)

### Une semaine avant
- [ ] Tous les projets de démo fonctionnels
- [ ] PowerPoint complet
- [ ] Script de présentation finalisé
- [ ] Documents de référence prêts

### La veille
- [ ] Test complet sur ordinateur de présentation
- [ ] Vérification des versions de .NET/Avalonia
- [ ] Impression des documents de référence (si nécessaire)
- [ ] Backup de tous les fichiers

### Le jour J
- [ ] Arriver 15 min en avance
- [ ] Tester projecteur et résolution d'écran
- [ ] Avoir les démos pré-compilées et prêtes à lancer
- [ ] Respirer et être prêt à répondre aux questions! 🎤

---

## Ressources et liens utiles

### Documentation officielle
- Avalonia Docs: https://docs.avaloniaui.net/
- CommunityToolkit.Mvvm: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/
- Avalonia Samples: https://github.com/AvaloniaUI/Avalonia.Samples

### Tutoriels pertinents
- ToDo App avec CommunityToolkit: https://medium.com/@artillustration391/simple-todo-list-in-avalonia-740ac520385f
- Guide DEV.to: https://dev.to/ghostkeeper10/how-to-use-community-toolkit-mvvm-in-avalonia-39af

---

**Dernière mise à jour**: 26 décembre 2024
**Statut**: Plan initial créé - prêt à exécuter les phases
