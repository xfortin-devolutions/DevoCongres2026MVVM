# Contenu des diapositives - Présentation MVVM

**Date**: 22 janvier 2025
**Format**: Bilingue (Français + Anglais)
**Template**: `Templates/template-DevoCongres_2026.pptx`

---

## Instructions

Ce document contient le **contenu textuel** de toutes les diapositives de la présentation.

**Format bilingue à respecter**:
- Français: Taille normale, **gras**
- Anglais: Taille plus petite, *italique*

**Utilisation**:
1. Ouvrir `Templates/template-DevoCongres_2026.pptx`
2. Créer une nouvelle diapositive
3. Copier-coller le contenu de chaque slide ci-dessous
4. Appliquer le formatage bilingue selon le pattern observé dans `Templates/Exemple-Bilingue.pptx`

---

## Slide 1: Titre

**FR (36pt, gras)**:
MVVM – Brisez les chaînes de la programmation événementielle

**EN (28pt, italique)**:
MVVM - Cast off the shackles of event-driven development

---

## Slide 2: Contexte - Problèmes avec event-driven

**Titre FR (32pt, gras)**: Les défis de la programmation événementielle
**Titre EN (20pt, italique)**: The challenges of event-driven programming

**Contenu FR (24pt)**:
- **Couplage fort entre l'interface et la logique métier**
- Synchronisation manuelle entre contrôles
- Code-behind volumineux et difficile à maintenir
- Tests unitaires complexes (nécessite des contrôles UI)

**Contenu EN (20pt, italique)**:
- **Tight coupling between interface and business logic**
- Manual synchronization between controls
- Large code-behind files, difficult to maintain
- Complex unit testing (requires UI controls)

---

## Slide 3: Objectifs de la session

**Titre FR (32pt, gras)**: Objectifs
**Titre EN (20pt, italique)**: Objectives

**Contenu FR (24pt)**:
1. Comprendre les avantages de l'architecture MVVM
2. Découvrir son utilisation dans RDM actuellement
3. Faciliter votre entrée au développement Avalonia

**Contenu EN (20pt, italique)**:
1. Understand the advantages of MVVM architecture
2. Learn about its current usage in RDM
3. Facilitate your entry into Avalonia development

---

## Slide 4: Sous-titre - Architecture MVVM

**Titre FR (36pt, gras)**: Architecture MVVM
**Titre EN (28pt, italique)**: MVVM Architecture

**Sous-titre FR (28pt)**: Les 3 couches
**Sous-titre EN (24pt, italique)**: The 3 layers

---

## Slide 5: Couche Model

**Titre FR (32pt, gras)**: Model
**Titre EN (20pt, italique)**: Model

**Contenu FR (24pt)**:
- Représente les données et la logique métier
- Indépendant de l'interface utilisateur

**Contenu EN (20pt, italique)**:
- Represents data and business logic
- Independent of user interface

---

## Slide 6: Couche View

**Titre FR (32pt, gras)**: View
**Titre EN (20pt, italique)**: View

**Contenu FR (24pt)**:
- Interface utilisateur (XAML)
- Affiche les données, capture les interactions utilisateur
- Ne contient PAS de logique métier
- Communique avec le ViewModel via Data Binding

**Contenu EN (20pt, italique)**:
- User interface (XAML)
- Displays data, captures user interactions
- Contains NO business logic
- Communicates with ViewModel via Data Binding

---

## Slide 7: Couche ViewModel

**Titre FR (32pt, gras)**: ViewModel
**Titre EN (20pt, italique)**: ViewModel

**Contenu FR (24pt)**:
- Pont entre Model et View
- Expose les données et commandes pour la View
- Implémente INotifyPropertyChanged pour la réactivité

**Contenu EN (20pt, italique)**:
- Bridge between Model and View
- Exposes data and commands for the View
- Implements INotifyPropertyChanged for reactivity

---

## Slide 8: Diagramme - Event-driven vs MVVM

**Titre FR (32pt, gras)**: Comparaison architecturale
**Titre EN (20pt, italique)**: Architectural comparison

**[DIAGRAMME À CRÉER]**

**WinForms (Event-driven)**:
```
UI Controls → Event Handlers → Business Logic
     ↑              ↓
     └──────────────┘
   (Couplage fort / Tight coupling)
```

**Avalonia (MVVM)**:
```
View (XAML) ←──Data Binding──→ ViewModel ←→ Model
                                    ↓
                            INotifyPropertyChanged
                            Commands (ICommand)
```

**Note FR**: Séparation claire des responsabilités
**Note EN**: Clear separation of concerns

---

## Slide 9: Data Binding

**Titre FR (32pt, gras)**: Le cœur de MVVM: Data Binding
**Titre EN (20pt, italique)**: The heart of MVVM: Data Binding

**Contenu FR (24pt)**:

**Data Binding** permet la synchronisation automatique:
- ViewModel → View (affichage)
- View → ViewModel (saisie utilisateur)
- **Bidirectionnel** avec `Mode=TwoWay`

**INotifyPropertyChanged**:
- Interface qui notifie la View des changements
- Déclenche la mise à jour automatique de l'UI
- Essentiel pour la réactivité de l'interface

**Contenu EN (20pt, italique)**:

**Data Binding** enables automatic synchronization:
- ViewModel → View (display)
- View → ViewModel (user input)
- **Bidirectional** with `Mode=TwoWay`

**INotifyPropertyChanged**:
- Interface that notifies the View of changes
- Triggers automatic UI updates
- Essential for interface reactivity

---

## Slide 10: Exemple - INotifyPropertyChanged manuel

**Titre FR (32pt, gras)**: Implémentation manuelle
**Titre EN (20pt, italique)**: Manual implementation

**Exemple de code** (non bilingue):
```csharp
public class PersonViewModel : INotifyPropertyChanged
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
    }
}
```

**Note FR (20pt)**: Beaucoup de code répétitif (boilerplate)
**Note EN (18pt, italique)**: Lots of repetitive code (boilerplate)

---

## Slide 11: Exemple - Avec [ObservableProperty]

**Titre FR (32pt, gras)**: Simplifié avec CommunityToolkit.Mvvm
**Titre EN (20pt, italique)**: Simplified with CommunityToolkit.Mvvm

**Note FR (18pt)**: *(RDM utilise Devolutions.MvvmToolkit)*
**Note EN (16pt, italique)**: *(RDM uses Devolutions.MvvmToolkit)*

**Exemple de code** (non bilingue):
```csharp
public partial class PersonViewModel : ObservableObject
{
    [ObservableProperty]
    private string name;
}

// Le code ci-dessus génère automatiquement:
// - La propriété publique Name
// - L'implémentation de INotifyPropertyChanged
// - La logique de comparaison et notification
```

**Note FR (20pt)**: Simple, concis et sans erreur!
**Note EN (18pt, italique)**: Simple, concise and error-free!

---

## Slide 12: CommunityToolkit.Mvvm - Source Generators

**Titre FR (32pt, gras)**: CommunityToolkit.Mvvm
**Titre EN (20pt, italique)**: CommunityToolkit.Mvvm

**Note FR (18pt)**: *(RDM utilise notre propre implémentation: Devolutions.MvvmToolkit)*
**Note EN (16pt, italique)**: *(RDM uses our own implementation: Devolutions.MvvmToolkit)*

**Contenu FR (24pt)**:

**Source Generators** pour simplifier le code MVVM:

📝 **[ObservableProperty]**
- Génère propriété avec INotifyPropertyChanged
- Réduit le boilerplate code

⚡ **[RelayCommand]**
- Génère ICommand automatiquement
- Support async avec AsyncRelayCommand
- CanExecute intégré

**Convention de nommage**:
- Champ privé: `camelCase` ou `_camelCase`
- Propriété générée: `PascalCase`
- Commande générée: `{MethodName}Command`

**Contenu EN (20pt, italique)**:

**Source Generators** to simplify MVVM code:

📝 **[ObservableProperty]**
- Generates property with INotifyPropertyChanged
- Reduces boilerplate code

⚡ **[RelayCommand]**
- Generates ICommand automatically
- Async support with AsyncRelayCommand
- Built-in CanExecute

**Naming convention**:
- Private field: `camelCase` or `_camelCase`
- Generated property: `PascalCase`
- Generated command: `{MethodName}Command`

**Exemple de code** (non bilingue):
```csharp
public class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string userName;

    [ObservableProperty]
    private bool isLoading;

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        IsLoading = true;
        await SaveToDatabase();
        IsLoading = false;
    }

    private bool CanSave() => !string.IsNullOrEmpty(UserName);
}
```

---

## Slide 13-15: MVVM dans RDM (3-4 slides)

**[À REMPLIR AVEC EXEMPLES SPÉCIFIQUES RDM]**

Ces slides devront être personnalisées avec:
- Exemples concrets de code RDM
- Captures d'écran de l'application RDM
- Patterns spécifiques adoptés par l'équipe

---

## Slide 16: Pattern RDM - AvaloniaList

**Titre FR (32pt, gras)**: Collections dans RDM
**Titre EN (20pt, italique)**: Collections in RDM

**Contenu FR (24pt)**:

**Pourquoi AvaloniaList au lieu de ObservableCollection?**

✅ **Opérations batch**:
- `AddRange()`, `RemoveRange()`, `InsertRange()`
- Une seule notification au lieu de N notifications
- Performance 10-100x meilleure

✅ **Pattern auto-initialisé**:
```csharp
public AvaloniaList<ItemViewModel> Items { get; } = new();
```
- Propriété readonly (jamais null)
- Binding direct sur Count sans fallback
- Simplification du code

**Contenu EN (20pt, italique)**:

**Why AvaloniaList instead of ObservableCollection?**

✅ **Batch operations**:
- `AddRange()`, `RemoveRange()`, `InsertRange()`
- Single notification instead of N notifications
- 10-100x better performance

✅ **Auto-initialized pattern**:
```csharp
public AvaloniaList<ItemViewModel> Items { get; } = new();
```
- Readonly property (never null)
- Direct Count binding without fallback
- Code simplification

---

## Slide 17: Transition vers les démos

**Titre FR (32pt, gras)**: Démonstrations pratiques
**Titre EN (20pt, italique)**: Practical demonstrations

**Contenu FR (24pt)**:

Nous allons voir 3 exemples concrets comparant WinForms et Avalonia:

1️⃣ **Master-Detail Pattern**
   - Le "mind shift" fondamental

2️⃣ **Multiple Views du même data**
   - Synchronisation automatique magique

3️⃣ **Composition dynamique de formulaires**
   - Génération d'UI déclarative

**Contenu EN (20pt, italique)**:

We will see 3 concrete examples comparing WinForms and Avalonia:

1️⃣ **Master-Detail Pattern**
   - The fundamental mind shift

2️⃣ **Multiple Views of the same data**
   - Magical automatic synchronization

3️⃣ **Dynamic form composition**
   - Declarative UI generation

---

## Notes pour les démonstrations

Après cette slide, passer aux **démonstrations live** en alternant entre:
1. Projet WinForms (montrer la complexité)
2. Projet Avalonia (montrer la simplicité)

**Timing**:
- Demo 1: ~10 minutes
- Demo 2: ~7 minutes
- Demo 3: ~8 minutes

---

## Slide finale: Questions et ressources

**Titre FR (32pt, gras)**: Questions?
**Titre EN (20pt, italique)**: Questions?

**Ressources FR (20pt)**:
- Documentation Avalonia: docs.avaloniaui.net
- CommunityToolkit.Mvvm: learn.microsoft.com/dotnet/communitytoolkit/mvvm
- Exemples Avalonia: github.com/AvaloniaUI/Avalonia.Samples

**Ressources EN (18pt, italique)**:
- Avalonia Documentation: docs.avaloniaui.net
- CommunityToolkit.Mvvm: learn.microsoft.com/dotnet/communitytoolkit/mvvm
- Avalonia Samples: github.com/AvaloniaUI/Avalonia.Samples

---

**Note**: Ce document sera mis à jour au fur et à mesure que le contenu des slides RDM-spécifiques sera finalisé.
