# DevoCongres2026MVVM

**Conférence MVVM - 22 janvier 2025**

Matériel pour la conférence/workshop sur l'architecture MVVM dans le contexte d'Avalonia, destinée aux développeurs RDM.

---

## 🎯 Titre de la conférence

**Français**: MVVM – Brisez les chaînes de la programmation événementielle
**Anglais**: MVVM - Cast off the shackles of event-driven development

---

## 📋 Prérequis

Pour suivre cette conférence et exécuter les projets de démonstration, vous aurez besoin de :

### Logiciels requis

- ✅ **.NET 10 SDK** (ou version ultérieure)
  - [Télécharger .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0)
  - Vérifier l'installation : `dotnet --version`

- ✅ **IDE au choix** :
  - Visual Studio 2022 (17.12+) - Recommandé
  - Visual Studio Code avec extensions C# et Avalonia
  - JetBrains Rider

- ✅ **Git** (pour cloner le repository)

### Connaissances recommandées

- Expérience avec WinForms ou Windows Forms
- Connaissances de base en C#
- Familiarité avec Visual Studio

---

## 📂 Structure du projet

```
DevoCongres2026MVVM/
├── README.md                    ← Vous êtes ici!
├── CLAUDE.md                    ← Point d'entrée pour Claude Code
├── PLAN.md                      ← TODO list de la préparation
├── CONTEXT.md                   ← Aide-mémoire technique RDM
├── Templates/                   ← Templates PowerPoint
├── Presentation/                ← Slides et script
├── Demos/                       ← Projets de démonstration
│   ├── WinForms.Demos/          (projet WinForms unifié)
│   └── Avalonia.Demos/          (projet Avalonia unifié)
└── Resources/                   ← Documentation et sources
```

---

## 🚀 Démarrage rapide

### 1. Cloner le repository

```bash
git clone [URL_DU_REPO]
cd DevoCongres2026MVVM
```

### 2. Tester les projets de démonstration

**WinForms :**
```bash
cd Demos/WinForms.Demos
dotnet run
```

**Avalonia :**
```bash
cd Demos/Avalonia.Demos
dotnet run
```

---

## 📖 Documentation

- **[CLAUDE.md](./CLAUDE.md)** - Point d'entrée et guide du projet
- **[PLAN.md](./PLAN.md)** - TODO list détaillée de la préparation
- **[CONTEXT.md](./CONTEXT.md)** - Spécificités techniques RDM
- **[Demos/README.md](./Demos/README.md)** - Guide des démonstrations

---

## 🎓 Objectifs de la conférence

1. Comprendre les avantages de l'architecture MVVM
   - Testabilité
   - Séparation des préoccupations
   - Maintenabilité

2. Découvrir son utilisation dans RDM actuellement
   - CommunityToolkit.Mvvm (Devolutions.MvvmToolkit)
   - AvaloniaList avec pattern auto-initialisé
   - Pratiques et conventions RDM

3. Faciliter l'entrée au développement Avalonia
   - Comparaisons WinForms vs Avalonia
   - Exemples pratiques et concrets
   - Focus sur le "mind shift" nécessaire

---

## 🔑 Stack technique

### RDM utilise actuellement :
- ✅ **Devolutions.MvvmToolkit** (basé sur CommunityToolkit.Mvvm)
- ✅ **AvaloniaList** (pas ObservableCollection)
- ✅ Pattern de collection auto-initialisée readonly

### Projets de démonstration :
- **.NET 10.0**
- **Avalonia UI 11.x**
- **CommunityToolkit.Mvvm 8.x**
- **Windows Forms** (pour comparaison)

---

## 📅 Timeline

- **26 décembre 2024** : Création du plan et de la structure
- **7 janvier 2025** : Restructuration des projets de démos
- **Avant le 15 janvier** : Tout le matériel doit être prêt
- **22 janvier 2025** : Jour de la présentation! 🎤

---

## 📞 Contact

Pour toute question concernant la conférence ou le matériel, contactez [VOTRE_CONTACT].

---

**Dernière mise à jour** : 7 janvier 2025
