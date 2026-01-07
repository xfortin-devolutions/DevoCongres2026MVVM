# Projets de démonstration - MVVM Workshop

Ce dossier contient 2 projets unifiés pour les démonstrations pratiques de la conférence, comparant WinForms (event-driven) et Avalonia (MVVM).

---

## 📁 Structure des projets

```
Demos/
├── README.md                           (ce fichier)
├── WinForms.Demos/                     ← Projet WinForms avec sélecteur
│   ├── MainForm.cs                     (3 boutons pour sélectionner les démos)
│   ├── Demo1_MasterDetail/             (à implémenter)
│   ├── Demo2_MultipleViews/            (à implémenter)
│   └── Demo3_DynamicForm/              (à implémenter)
└── Avalonia.Demos/                     ← Projet Avalonia avec menu latéral
    ├── MainWindow.axaml                (menu + ContentControl pour démos)
    ├── ViewModels/
    │   └── MainWindowViewModel.cs
    ├── Demo1_MasterDetail/             (à implémenter)
    ├── Demo2_MultipleViews/            (à implémenter)
    └── Demo3_DynamicForm/              (à implémenter)
```

---

## 🌟 Vue d'ensemble des démos

### Demo 1: Master-Detail Pattern (~10 min)
**Status**: 📋 Structure créée - À implémenter

**Objectif**: LE "mind shift" fondamental

Comparaison:
- **WinForms**: ListView + SelectedIndexChanged event + switch/if + manipulation manuelle
- **Avalonia**: ListBox + ContentControl avec DataTemplates automatiques

**Why it matters**: Illustre le changement de paradigme complet - passer de l'impératif au déclaratif.

---

### Demo 2: Multiple Views du même data (~7 min)
**Status**: 📋 Structure créée - À implémenter

**Objectif**: Synchronisation automatique magique

Comparaison:
- **WinForms**: Events partout pour synchroniser manuellement ListBox, TreeView et compteur
- **Avalonia**: Une seule AvaloniaList, binding automatique sur tous les contrôles

**Why it matters**: Montre l'impossibilité de "perdre la sync" avec MVVM, tout est automatique.

---

### Demo 3: Composition dynamique de formulaires (~8 min)
**Status**: 📋 Structure créée - À implémenter

**Objectif**: Génération d'UI déclarative

Comparaison:
- **WinForms**: Boucle avec calcul manuel de positions + switch pour types + events manuels
- **Avalonia**: ItemsControl + DataTemplates = génération automatique

**Why it matters**: Démontre un avantage **impossible** à répliquer élégamment en WinForms.

---

## 🚀 Exécuter les projets

### WinForms
```bash
cd WinForms.Demos
dotnet run
```

### Avalonia
```bash
cd Avalonia.Demos
dotnet run
```

---

## 🛠️ Technologies utilisées

### WinForms.Demos
- .NET 10.0
- Windows Forms
- Programmation événementielle classique

### Avalonia.Demos
- .NET 10.0
- Avalonia UI 11.x
- CommunityToolkit.Mvvm 8.x
- Pattern MVVM

---

## 📋 Prochaines étapes

1. ✅ Structure des projets créée
2. ✅ Sélecteurs de démos implémentés (WinForms: boutons, Avalonia: menu latéral)
3. ⏳ Implémenter Demo 1: Master-Detail Pattern
4. ⏳ Implémenter Demo 2: Multiple Views
5. ⏳ Implémenter Demo 3: Dynamic Form Composition
6. ⏳ Tester toutes les démos
7. ⏳ Préparer le script de présentation

---

## 📝 Notes pour la présentation

### Ordre de présentation par démo

Pour chaque démo, suivre cet ordre:
1. **Introduire le concept** (30 sec)
2. **Montrer le code WinForms** (3-4 min)
   - Expliquer chaque partie
   - Souligner les problèmes
3. **Montrer le code Avalonia** (2-3 min)
   - Contraster avec WinForms
   - Souligner la simplicité
4. **Demo live** (1-2 min)
   - Exécuter l'application
   - Interagir avec l'UI
5. **Conclure** (30 sec)
   - Résumer les avantages

### Timing total

- Demo 1: ~10 minutes
- Demo 2: ~7 minutes
- Demo 3: ~8 minutes
- **Total: ~25 minutes** (sur 35 min de présentation, le reste étant la théorie)

### Conseils pour la présentation

- 💡 Avoir les deux projets (WinForms et Avalonia) ouverts côte-à-côte
- 💡 Utiliser des captures d'écran si problème technique
- 💡 Préparer des "one-liners" pour chaque démo
  - Demo 1: "Switch/if versus DataTemplates - laquelle voulez-vous maintenir?"
  - Demo 2: "Une seule source de vérité, zéro code de synchronisation"
  - Demo 3: "Calcul de positions versus layout automatique - pas de compétition"

---

**Dernière mise à jour**: 7 janvier 2025
