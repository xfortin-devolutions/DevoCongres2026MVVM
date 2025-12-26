# Projets de démonstration - MVVM Workshop

Ce dossier contient les 3 démonstrations pratiques de la conférence, comparant WinForms (event-driven) et Avalonia (MVVM).

---

## Vue d'ensemble des démos

### 🌟 Demo 1: Master-Detail Pattern (~10 min)
**Status**: 📋 Planifié

**Objectif**: LE "mind shift" fondamental

Comparaison:
- **WinForms**: ListView + SelectedIndexChanged event + switch/if + manipulation manuelle
- **Avalonia**: ListBox + ContentControl avec DataTemplates automatiques

**Why it matters**: Illustre le changement de paradigme complet - passer de l'impératif au déclaratif.

📁 [Voir les détails](./Demo1-Master-Detail/README.md)

---

### 🔄 Demo 2: Multiple Views du même data (~7 min)
**Status**: 📋 Planifié

**Objectif**: Synchronisation automatique magique

Comparaison:
- **WinForms**: Events partout pour synchroniser manuellement ListBox, TreeView et compteur
- **Avalonia**: Une seule AvaloniaList, binding automatique sur tous les contrôles

**Why it matters**: Montre l'impossibilité de "perdre la sync" avec MVVM, tout est automatique.

📁 [Voir les détails](./Demo2-Multiple-Views/README.md)

---

### 🎨 Demo 3: Composition dynamique de formulaires (~8 min)
**Status**: 📋 Planifié

**Objectif**: Génération d'UI déclarative

Comparaison:
- **WinForms**: Boucle avec calcul manuel de positions + switch pour types + events manuels
- **Avalonia**: ItemsControl + DataTemplates = génération automatique

**Why it matters**: Démontre un avantage **impossible** à répliquer élégamment en WinForms.

📁 [Voir les détails](./Demo3-Dynamic-Form-Composition/README.md)

---

## Structure

```
Demos/
├── README.md                           (ce fichier)
├── Demo1-Master-Detail/
│   ├── README.md                       (détails de la démo)
│   ├── WinForms-MasterDetail/          (projet WinForms à créer)
│   └── Avalonia-MasterDetail/          (projet Avalonia à créer)
├── Demo2-Multiple-Views/
│   ├── README.md
│   ├── WinForms-MultipleViews/         (projet WinForms à créer)
│   └── Avalonia-MultipleViews/         (projet Avalonia à créer)
└── Demo3-Dynamic-Form-Composition/
    ├── README.md
    ├── WinForms-DynamicForm/           (projet WinForms à créer)
    └── Avalonia-DynamicForm/           (projet Avalonia à créer)
```

---

## Timing total

- Demo 1: ~10 minutes
- Demo 2: ~7 minutes
- Demo 3: ~8 minutes
- **Total: ~25 minutes** (sur 35 min de présentation, le reste étant la théorie)

---

## Technologies utilisées

### WinForms
- .NET 8.0
- Windows Forms
- Programmation événementielle classique

### Avalonia
- .NET 8.0
- Avalonia UI 11.x
- CommunityToolkit.Mvvm 8.x
- Pattern MVVM

---

## Prochaines étapes

1. ✅ Structure des dossiers créée
2. ✅ README pour chaque démo créé
3. ⏳ Créer les projets WinForms
4. ⏳ Créer les projets Avalonia
5. ⏳ Tester toutes les démos
6. ⏳ Préparer le script de présentation

---

## Notes pour la présentation

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

### Conseils pour la présentation

- 💡 Avoir les deux projets (WinForms et Avalonia) ouverts côte-à-côte
- 💡 Utiliser des captures d'écran si problème technique
- 💡 Préparer des "one-liners" pour chaque démo
  - Demo 1: "Switch/if versus DataTemplates - laquelle voulez-vous maintenir?"
  - Demo 2: "Une seule source de vérité, zéro code de synchronisation"
  - Demo 3: "Calcul de positions versus layout automatique - pas de compétition"

---

**Dernière mise à jour**: 26 décembre 2024
