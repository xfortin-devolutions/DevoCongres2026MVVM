# Sources et références - Conférence MVVM

**Date de compilation**: 26 décembre 2024

---

## =Ú Documentation officielle

### Avalonia
- **Documentation principale**: https://docs.avaloniaui.net/
- **The MVVM Pattern**: https://docs.avaloniaui.net/docs/concepts/the-mvvm-pattern
- **Avalonia UI and MVVM**: https://docs.avaloniaui.net/docs/concepts/the-mvvm-pattern/avalonia-ui-and-mvvm
- **Data Binding**: https://docs.avaloniaui.net/docs/basics/data/data-binding/
- **Data Templates**: https://docs.avaloniaui.net/docs/basics/data/data-templates/
- **ContentControl**: https://docs.avaloniaui.net/docs/reference/controls/contentcontrol

### CommunityToolkit.Mvvm
- **Documentation principale**: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/
- **Introduction to the MVVM Toolkit**: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/
- **ObservableProperty**: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty
- **RelayCommand**: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/relaycommand
- **MVVM Toolkit Features**: https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm-community-toolkit-features

### AvaloniaList API
- **API Reference**: https://api-docs.avaloniaui.net/docs/T_Avalonia_Collections_AvaloniaList_1
- **AddRange Method**: https://reference.avaloniaui.net/api/Avalonia.Collections/AvaloniaList_1/3E0AEAB3
- **InsertRange Method**: https://reference.avaloniaui.net/api/Avalonia.Collections/AvaloniaList_1/C56A02EC

---

## =Ö Tutoriels et guides utilisés

### Avalonia avec CommunityToolkit.Mvvm
- **How to use Community Toolkit MVVM in Avalonia** (DEV.to): https://dev.to/ghostkeeper10/how-to-use-community-toolkit-mvvm-in-avalonia-39af
- **Simple ToDo-List in Avalonia** (Medium): https://medium.com/@artillustration391/simple-todo-list-in-avalonia-740ac520385f
- **Avalonia and ReactiveUI  MVVM, DI & Clean Architecture** (Medium): https://medium.com/c-sharp-programming/avalonia-and-reactiveui-mvvm-di-clean-architecture-67fe4777d463
  - Note: Bien que cet article parle de ReactiveUI, les concepts MVVM s'appliquent

### MVVM Pattern général
- **Patterns - WPF Apps With The Model-View-ViewModel Design Pattern** (Microsoft): https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern
- **The MVVM Pattern revisited with the MVVM Community Toolkit 8.0**: https://blogs.msmvps.com/bsonnino/2022/08/06/the-mvvm-pattern-revisited-with-the-mvvm-community-toolkit-8-0/
- **MVVM Source Generators: Advanced Scenarios**: https://blog.ewers-peters.de/mvvm-source-generators-advanced-scenarios

---

## = Recherches spécifiques effectuées

### AvaloniaList vs ObservableCollection
- **GitHub Issue - Collection\<T\> and ObservableCollection\<T\> do not support ranges**: https://github.com/dotnet/runtime/issues/18087
- **Blog - An Alternative to ObservableCollection**: https://baumbartsjourney.wordpress.com/2009/06/01/an-alternative-to-observablecollection/
- **BulkObservableCollection vs ObservableCollection**: https://www.arjarapu.com/wordpress/2011/11/bulkobservablecollection-vs-observablecollection/

**Conclusion de la recherche**:
- AvaloniaList offre `AddRange()`, `RemoveRange()`, `InsertRange()`
- ObservableCollection n'a pas ces méthodes
- Performance 10-100x meilleure avec batch operations
- Une seule notification CollectionChanged au lieu de N notifications

### Master-Detail Pattern
- **GitHub Discussion - How can I bind this event to the Viewmodel**: https://github.com/AvaloniaUI/Avalonia/discussions/12569
- **ContentControl with DataTemplate**: https://github.com/AvaloniaUI/Avalonia/discussions/15349

### WinForms to MVVM Migration
- **WinForms to WPF Migration Guide**: https://www.softacom.com/blog/migration/migration-from-winforms-to-wpf/
- **Using MVVM Design Pattern in Windows Forms**: https://www.reflectionit.nl/blog/2023/using-mvvm-design-pattern-in-windows-forms
- **Using Command Binding in Windows Forms apps to go Cross-Platform**: https://devblogs.microsoft.com/dotnet/winforms-cross-platform-dotnet-maui-command-binding/

---

## =æ Exemples de code et projets

### Avalonia Samples (GitHub)
- **Repository principal**: https://github.com/AvaloniaUI/Avalonia.Samples
- Contient des exemples avec CommunityToolkit.Mvvm
- Dialog Manager Sample
- Music Store app (exemple complet)

### Discussions GitHub pertinentes
- **Best architectural approach for MVVM**: https://github.com/AvaloniaUI/Avalonia/discussions/16200
- **Question regarding design philosophy with MVVM**: https://github.com/AvaloniaUI/Avalonia/discussions/7546
- **How to Navigate to different page using Community Toolkit MVVM**: https://github.com/AvaloniaUI/Avalonia/discussions/9988

---

## =Ê Articles de comparaison

### MVC vs MVVM
- **MVC vs MVVM  Difference Between Them**: https://www.guru99.com/mvc-vs-mvvm.html
- **MVC vs MVVM: what's the difference? (C# example)**: https://dev.to/dimension-zero/mvc-vs-mvvm-whats-the-difference-c-example-45ah
- **Exploring MVC vs MVVM: Choosing the Right Architecture**: https://shakuro.com/blog/mvc-vs-mvvm

### MVVM Advantages
- **Advantages of MVVM**: https://www.tutorialspoint.com/mvvm/mvvm_advantages.htm
- **The 5W's of MVVM**: https://www.sagitec.com/blog/the-5ws-of-mvvm

---

## <“ Concepts clés découverts

### Data Binding
- **INotifyPropertyChanged**: Interface standard .NET pour notifier les changements
- **Two-way binding**: Synchronisation bidirectionnelle automatique
- **Value converters**: Transformation de données pendant le binding (WPF/Avalonia uniquement)

### Source Generators (CommunityToolkit.Mvvm)
- Génération de code au compile-time
- Réduit drastiquement le boilerplate
- Convention de nommage: `[ObservableProperty] private string name;` ’ génère `public string Name`
- `[RelayCommand]` génère automatiquement `ICommand` avec CanExecute

### DataTemplates
- Définition de la représentation visuelle des données
- Sélection automatique selon le type (`DataType="vm:MyViewModel"`)
- Réutilisables et composables
- **Impossible à reproduire aussi élégamment en WinForms**

---

## =¡ Citations importantes

> "MVVM was created by Microsoft architects Ken Cooper and Ted Peters specifically to simplify event-driven programming of user interfaces."

> "The key benefit is allowing true separation between the View and Model. When your model needs to change, it can be changed easily without the view needing to and vice-versa."

> "ObservableCollection can be 10-100 times slower with batch operations since each Add operation fires off a CollectionChanged event."

> "AvaloniaList provides AddRange and RemoveRange methods that add/remove multiple items with a single notification."

---

## =Ý Notes pour les participants

Ces sources seront fournies aux participants de la conférence pour approfondir leur apprentissage.

**Recommandations d'apprentissage**:
1. Commencer par la documentation officielle Avalonia
2. Lire l'introduction à CommunityToolkit.Mvvm
3. Cloner Avalonia.Samples et explorer les exemples
4. Pratiquer avec un petit projet personnel

---

**Dernière mise à jour**: 26 décembre 2024
