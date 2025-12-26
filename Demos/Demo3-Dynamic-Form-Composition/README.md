# Demo 3: Composition dynamique de formulaires

**Timing**: ~8 minutes
**Objectif**: Génération d'UI basée sur métadonnées (impossible à faire élégamment en WinForms)

---

## Vue d'ensemble

Cette démo montre la puissance de la génération déclarative d'UI en comparant:
- **WinForms**: Boucle impérative avec calcul manuel de positions et switch pour types
- **Avalonia MVVM**: ItemsControl + DataTemplates = génération automatique et élégante

---

## Structure

```
Demo3-Dynamic-Form-Composition/
├── README.md                    (ce fichier)
├── WinForms-DynamicForm/        (projet WinForms)
│   └── (à créer)
└── Avalonia-DynamicForm/        (projet Avalonia)
    └── (à créer)
```

---

## Concept WinForms (impératif - usine à code)

**Objectif**: Générer un formulaire dynamiquement basé sur des métadonnées

**Métadonnées exemple**:
```csharp
var fields = new[]
{
    new FieldMetadata { Name = "Name", Type = FieldType.Text, Label = "Full Name" },
    new FieldMetadata { Name = "Email", Type = FieldType.Text, Label = "Email Address" },
    new FieldMetadata { Name = "Country", Type = FieldType.Dropdown, Label = "Country",
                        Options = new[] { "Canada", "USA", "UK" } },
    new FieldMetadata { Name = "Subscribe", Type = FieldType.Checkbox, Label = "Subscribe to newsletter" },
    new FieldMetadata { Name = "BirthDate", Type = FieldType.Date, Label = "Date of Birth" }
};
```

**Code WinForms nécessaire**:
```csharp
private void GenerateForm(FieldMetadata[] fields)
{
    panel.Controls.Clear();
    int yPosition = 10;
    const int spacing = 35;

    foreach (var field in fields)
    {
        // Créer le label
        var label = new Label
        {
            Text = field.Label + ":",
            Location = new Point(10, yPosition),
            AutoSize = true,
            Font = new Font("Arial", 10)
        };
        panel.Controls.Add(label);

        // Créer le contrôle approprié selon le type
        Control inputControl;
        switch (field.Type)
        {
            case FieldType.Text:
                inputControl = new TextBox
                {
                    Name = field.Name,
                    Location = new Point(150, yPosition),
                    Width = 250
                };
                // Event pour validation
                ((TextBox)inputControl).TextChanged += (s, e) => ValidateField(field);
                break;

            case FieldType.Dropdown:
                var comboBox = new ComboBox
                {
                    Name = field.Name,
                    Location = new Point(150, yPosition),
                    Width = 250,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                comboBox.Items.AddRange(field.Options);
                comboBox.SelectedIndexChanged += (s, e) => ValidateField(field);
                inputControl = comboBox;
                break;

            case FieldType.Checkbox:
                inputControl = new CheckBox
                {
                    Name = field.Name,
                    Text = field.Label,
                    Location = new Point(150, yPosition),
                    AutoSize = true
                };
                label.Visible = false; // Checkbox a son propre label
                break;

            case FieldType.Date:
                inputControl = new DateTimePicker
                {
                    Name = field.Name,
                    Location = new Point(150, yPosition),
                    Width = 250
                };
                break;

            default:
                throw new NotSupportedException($"Field type {field.Type} not supported");
        }

        panel.Controls.Add(inputControl);
        yPosition += spacing;

        // Stocker référence pour récupération des valeurs plus tard
        _fieldControls[field.Name] = inputControl;
    }
}
```

**Problèmes**:
- ❌ Calcul manuel des positions (x, y, spacing)
- ❌ Switch verbeux pour chaque type de champ
- ❌ Events manuels pour validation
- ❌ Difficile à étendre (nouveau type = modifier le switch)
- ❌ Logique de layout mélangée avec logique métier
- ❌ Difficile à tester
- ❌ Code impératif difficile à maintenir

---

## Concept Avalonia MVVM (déclaratif et élégant)

**ViewModels représentant les champs**:

```csharp
// Classe de base pour tous les champs
public abstract class FieldViewModelBase : ViewModelBase
{
    [ObservableProperty]
    private string label = string.Empty;

    [ObservableProperty]
    private bool isValid = true;

    [ObservableProperty]
    private string? validationMessage;

    public abstract void Validate();
}

// Champ texte
public class TextFieldViewModel : FieldViewModelBase
{
    [ObservableProperty]
    private string value = string.Empty;

    [ObservableProperty]
    private bool isRequired;

    public override void Validate()
    {
        if (IsRequired && string.IsNullOrWhiteSpace(Value))
        {
            IsValid = false;
            ValidationMessage = "This field is required";
        }
        else
        {
            IsValid = true;
            ValidationMessage = null;
        }
    }
}

// Dropdown/ComboBox
public class DropdownFieldViewModel : FieldViewModelBase
{
    public AvaloniaList<string> Options { get; } = new();

    [ObservableProperty]
    private string? selectedOption;

    public override void Validate()
    {
        IsValid = SelectedOption != null;
        ValidationMessage = IsValid ? null : "Please select an option";
    }
}

// Checkbox
public class CheckboxFieldViewModel : FieldViewModelBase
{
    [ObservableProperty]
    private bool isChecked;

    public override void Validate()
    {
        IsValid = true; // Checkbox toujours valide
    }
}

// Date picker
public class DateFieldViewModel : FieldViewModelBase
{
    [ObservableProperty]
    private DateTime selectedDate = DateTime.Today;

    [ObservableProperty]
    private DateTime? minDate;

    [ObservableProperty]
    private DateTime? maxDate;

    public override void Validate()
    {
        IsValid = true;
        if (MinDate.HasValue && SelectedDate < MinDate.Value)
        {
            IsValid = false;
            ValidationMessage = $"Date must be after {MinDate.Value:yyyy-MM-dd}";
        }
        else if (MaxDate.HasValue && SelectedDate > MaxDate.Value)
        {
            IsValid = false;
            ValidationMessage = $"Date must be before {MaxDate.Value:yyyy-MM-dd}";
        }
    }
}
```

**ViewModel principal du formulaire**:

```csharp
public class DynamicFormViewModel : ViewModelBase
{
    public AvaloniaList<FieldViewModelBase> Fields { get; } = new();

    [ObservableProperty]
    private bool isFormValid;

    public DynamicFormViewModel()
    {
        LoadFields();
    }

    private void LoadFields()
    {
        // Charger depuis métadonnées, config, ou base de données
        Fields.AddRange(new FieldViewModelBase[]
        {
            new TextFieldViewModel
            {
                Label = "Full Name",
                IsRequired = true
            },
            new TextFieldViewModel
            {
                Label = "Email Address",
                IsRequired = true
            },
            new DropdownFieldViewModel
            {
                Label = "Country",
                Options = { "Canada", "USA", "UK", "France", "Germany" }
            },
            new CheckboxFieldViewModel
            {
                Label = "Subscribe to newsletter"
            },
            new DateFieldViewModel
            {
                Label = "Date of Birth",
                MinDate = new DateTime(1900, 1, 1),
                MaxDate = DateTime.Today
            }
        });
    }

    [RelayCommand]
    private void ValidateForm()
    {
        foreach (var field in Fields)
        {
            field.Validate();
        }
        IsFormValid = Fields.All(f => f.IsValid);
    }

    [RelayCommand(CanExecute = nameof(IsFormValid))]
    private void Submit()
    {
        // Soumettre le formulaire
    }
}
```

**XAML avec DataTemplates**:

```xaml
<StackPanel>
    <!-- Génération automatique des champs! -->
    <ItemsControl Items="{Binding Fields}">
        <ItemsControl.DataTemplates>
            <!-- Template pour TextBox -->
            <DataTemplate DataType="vm:TextFieldViewModel">
                <StackPanel Margin="5">
                    <TextBlock Text="{Binding Label}" FontWeight="Bold" />
                    <TextBox Text="{Binding Value}"
                             Watermark="Enter text..." />
                    <TextBlock Text="{Binding ValidationMessage}"
                               Foreground="Red"
                               IsVisible="{Binding !IsValid}" />
                </StackPanel>
            </DataTemplate>

            <!-- Template pour Dropdown -->
            <DataTemplate DataType="vm:DropdownFieldViewModel">
                <StackPanel Margin="5">
                    <TextBlock Text="{Binding Label}" FontWeight="Bold" />
                    <ComboBox Items="{Binding Options}"
                              SelectedItem="{Binding SelectedOption}"
                              PlaceholderText="Select an option..." />
                    <TextBlock Text="{Binding ValidationMessage}"
                               Foreground="Red"
                               IsVisible="{Binding !IsValid}" />
                </StackPanel>
            </DataTemplate>

            <!-- Template pour Checkbox -->
            <DataTemplate DataType="vm:CheckboxFieldViewModel">
                <CheckBox Content="{Binding Label}"
                          IsChecked="{Binding IsChecked}"
                          Margin="5" />
            </DataTemplate>

            <!-- Template pour DatePicker -->
            <DataTemplate DataType="vm:DateFieldViewModel">
                <StackPanel Margin="5">
                    <TextBlock Text="{Binding Label}" FontWeight="Bold" />
                    <DatePicker SelectedDate="{Binding SelectedDate}" />
                    <TextBlock Text="{Binding ValidationMessage}"
                               Foreground="Red"
                               IsVisible="{Binding !IsValid}" />
                </StackPanel>
            </DataTemplate>
        </ItemsControl.DataTemplates>
    </ItemsControl>

    <!-- Boutons -->
    <StackPanel Orientation="Horizontal" Margin="5">
        <Button Content="Validate" Command="{Binding ValidateFormCommand}" />
        <Button Content="Submit"
                Command="{Binding SubmitCommand}"
                Margin="10,0,0,0" />
    </StackPanel>
</StackPanel>
```

**Avantages**:
- ✅ **Aucun calcul de position**: StackPanel gère tout
- ✅ **Aucun switch**: DataTemplates appliqués automatiquement selon le type
- ✅ **Extensible**: Nouveau type = nouveau ViewModel + nouveau DataTemplate (aucune modification du code existant!)
- ✅ **Déclaratif**: "Voici mes données, voici comment les afficher"
- ✅ **Testable**: ViewModel complètement séparé de l'UI
- ✅ **Pattern RDM**: `Fields.AddRange()` pour batch operations
- ✅ **Validation intégrée**: Chaque field gère sa propre validation

---

## Points clés à souligner pendant la démo

1. **WinForms**:
   - Montrer la boucle avec calcul de positions (yPosition += 35)
   - Montrer le switch verbeux
   - Souligner: "Et si on veut ajouter un nouveau type de champ?"

2. **Avalonia**:
   - Montrer qu'il n'y a AUCUNE boucle
   - Montrer qu'il n'y a AUCUN calcul de position
   - Montrer qu'il n'y a AUCUN switch
   - **Extensibilité**: Ajouter `SliderFieldViewModel` + DataTemplate = nouveau type supporté sans toucher au code existant

3. **Pattern RDM**: `Fields` auto-initialisée, utilisation de `AddRange()`

4. **Cas d'utilisation réels**:
   - Configuration wizard
   - Formulaires générés depuis DB
   - Éditeur de propriétés générique

---

## Extension possible (si temps)

Montrer qu'on peut facilement ajouter un **nouveau type de champ** (ex: Slider) sans modifier le code existant:

```csharp
// Nouveau ViewModel
public class SliderFieldViewModel : FieldViewModelBase
{
    [ObservableProperty]
    private double value = 50;

    [ObservableProperty]
    private double minimum = 0;

    [ObservableProperty]
    private double maximum = 100;
}
```

```xaml
<!-- Nouveau DataTemplate -->
<DataTemplate DataType="vm:SliderFieldViewModel">
    <StackPanel Margin="5">
        <TextBlock Text="{Binding Label}" FontWeight="Bold" />
        <Slider Value="{Binding Value}"
                Minimum="{Binding Minimum}"
                Maximum="{Binding Maximum}" />
        <TextBlock Text="{Binding Value, StringFormat={}{0:F0}}" HorizontalAlignment="Center" />
    </StackPanel>
</DataTemplate>
```

Ajouter à la collection:
```csharp
Fields.Add(new SliderFieldViewModel
{
    Label = "Volume",
    Minimum = 0,
    Maximum = 100,
    Value = 75
});
```

**Boom!** Nouveau type de champ supporté sans toucher au code existant. En WinForms? Modifier le switch, ajouter un nouveau case, recalculer les positions...

---

**Status**: 📋 Planifié - Projets à créer
