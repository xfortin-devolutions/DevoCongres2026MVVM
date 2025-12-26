# Demo 1: Master-Detail Pattern

**Timing**: ~10 minutes (LA STAR du show)
**Objectif**: Démontrer LE "mind shift" fondamental entre WinForms et MVVM

---

## Vue d'ensemble

Cette démo compare l'implémentation d'un pattern Master-Detail classique:
- **WinForms**: ListView/TreeView avec events + switch/if + manipulation manuelle
- **Avalonia MVVM**: ListBox + ContentControl avec data binding automatique

---

## Structure

```
Demo1-Master-Detail/
├── README.md                    (ce fichier)
├── WinForms-MasterDetail/       (projet WinForms)
│   └── (à créer)
└── Avalonia-MasterDetail/       (projet Avalonia)
    └── (à créer)
```

---

## Concept WinForms (complexe)

**Étapes nécessaires**:
1. Charger les items dans ListView/TreeView
2. S'abonner à l'événement `SelectedIndexChanged`
3. Dans le handler, utiliser switch/if pour déterminer quel contrôle afficher
4. Instancier manuellement le contrôle approprié
5. Vider le panel et ajouter le nouveau contrôle
6. Gérer le nettoyage (dispose, etc.)

**Problèmes**:
- Logique dispersée dans les event handlers
- Code impératif difficile à maintenir
- Switch/if fragile (oublier un cas = bug)
- Couplage fort entre UI et logique

---

## Concept Avalonia MVVM (simple)

**Étapes nécessaires**:
1. ViewModels avec leur propre DataTemplate
2. Binding `SelectedItem` entre ListBox et propriété ViewModel
3. ContentControl avec binding sur `SelectedItem`
4. **C'EST TOUT!**

**Avantages**:
- Zéro code-behind
- DataTemplates appliqués automatiquement selon le type
- Aucun switch/if nécessaire
- Totalement déclaratif

---

## Exemple de données

Les items à afficher (exemples):
- **Page d'accueil** (HomeViewModel) → Vue avec message de bienvenue
- **Paramètres** (SettingsViewModel) → Vue avec options et checkboxes
- **À propos** (AboutViewModel) → Vue avec informations de version
- **Profil utilisateur** (UserProfileViewModel) → Vue avec formulaire

Chaque type de ViewModel a sa propre représentation visuelle définie dans un DataTemplate.

---

## Code clé Avalonia

**ViewModel principal**:
```csharp
public class MainViewModel : ViewModelBase
{
    public AvaloniaList<PageViewModelBase> Pages { get; } = new();

    [ObservableProperty]
    private PageViewModelBase? selectedPage;

    public MainViewModel()
    {
        Pages.AddRange(new PageViewModelBase[]
        {
            new HomeViewModel(),
            new SettingsViewModel(),
            new AboutViewModel(),
            new UserProfileViewModel()
        });
        SelectedPage = Pages[0];
    }
}
```

**XAML**:
```xaml
<Grid ColumnDefinitions="200,*">
    <!-- Liste des pages -->
    <ListBox Grid.Column="0"
             Items="{Binding Pages}"
             SelectedItem="{Binding SelectedPage}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding PageName}" />
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>

    <!-- Contenu de la page sélectionnée -->
    <ContentControl Grid.Column="1"
                    Content="{Binding SelectedPage}" />
</Grid>
```

**DataTemplates pour chaque page** (dans App.axaml):
```xaml
<Application.DataTemplates>
    <DataTemplate DataType="vm:HomeViewModel">
        <StackPanel>
            <TextBlock Text="Bienvenue!" FontSize="24" />
            <TextBlock Text="{Binding WelcomeMessage}" />
        </StackPanel>
    </DataTemplate>

    <DataTemplate DataType="vm:SettingsViewModel">
        <StackPanel>
            <TextBlock Text="Paramètres" FontSize="24" />
            <CheckBox Content="Option 1" IsChecked="{Binding Option1}" />
            <CheckBox Content="Option 2" IsChecked="{Binding Option2}" />
        </StackPanel>
    </DataTemplate>

    <!-- Autres templates... -->
</Application.DataTemplates>
```

---

## Points clés à souligner pendant la démo

1. **WinForms**: Montrer le code verbeux avec le switch et la manipulation manuelle
2. **Avalonia**: Montrer qu'il n'y a AUCUN code-behind
3. **Magic moment**: Changer la sélection → le contenu change automatiquement
4. **Extensibilité**: Ajouter un nouveau type de page = nouveau ViewModel + nouveau DataTemplate (pas de modification du switch!)

---

## Notes pour la présentation

- Commencer par montrer le code WinForms (5 min)
- Expliquer chaque étape et les problèmes
- Passer à Avalonia (5 min)
- Montrer le code simplifié
- **DEMO LIVE**: Cliquer entre les pages, tout fonctionne automatiquement
- Conclure avec la question: "Laquelle des deux approches préférez-vous maintenir?"

---

**Status**: 📋 Planifié - Projets à créer
