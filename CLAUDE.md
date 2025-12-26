# 🤖 CLAUDE.md - Point d'entrée pour Claude Code

**Bienvenue dans le projet DevoCongres2026MVVM!**

Ce document sert de point d'entrée pour Claude Code et toute personne qui travaille sur ce projet.

---

## 📂 Structure du projet

```
DevoCongres2026MVVM/
├── CLAUDE.md                        ← Vous êtes ici! (Point d'entrée)
├── PLAN.md                          ← TODO list détaillée de la préparation
├── CONTEXT.md                       ← Aide-mémoire technique et spécificités RDM
├── Templates/                       ← Templates PowerPoint
│   ├── template-DevoCongres_2026.pptx   (template officiel)
│   └── Exemple-Bilingue.pptx            (exemple format bilingue)
├── Presentation/                    ← Slides PowerPoint et script (à créer)
├── Demos/                           ← Projets de démonstration (à créer)
└── Resources/                       ← Documentation et sources (à créer)
```

---

## 🎯 À propos du projet

### Objectif
Préparer une conférence/workshop de 45 minutes sur l'architecture MVVM dans le contexte d'Avalonia, destinée aux développeurs RDM qui connaissent principalement WinForms.

### Titre de la conférence
**Français**: MVVM – Brisez les chaînes de la programmation événementielle
**Anglais**: MVVM - Cast off the shackles of event-driven development

### Date de présentation
**22 janvier 2025**

### Format
- 35 minutes de présentation (PowerPoint + démos pratiques)
- 10 minutes de questions/réponses
- **⚠️ BILINGUE**: Toutes les diapositives doivent être en français ET anglais

---

## 📖 Documents clés

### 1. [PLAN.md](./PLAN.md) - TODO List complète
**Utilité**: Savoir quoi faire et dans quel ordre

**Contient**:
- [ ] Phase 1: Structure du projet
- [ ] Phase 2: Contenu PowerPoint (15-20 slides)
- [ ] Phase 3: Projets de démonstration (4 démos)
- [ ] Phase 4: Documentation et sources
- [ ] Phase 5: Tests et révisions

**Quand l'utiliser**: Pour suivre la progression et savoir quelle est la prochaine étape.

---

### 2. [CONTEXT.md](./CONTEXT.md) - Aide-mémoire technique
**Utilité**: Se rappeler des spécificités techniques RDM et décisions architecturales

**Contient**:
- Stack technique RDM (CommunityToolkit.Mvvm, AvaloniaList)
- Pattern de collection mutable auto-initialisée (très important!)
- Justifications des choix techniques
- Exemples de code spécifiques à RDM
- Notes sur les démonstrations clés

**Quand l'utiliser**:
- Au début de chaque session de travail (pour se remémorer le contexte)
- Quand vous ajoutez des spécificités techniques RDM
- Avant d'écrire du code pour les démos

---

## 🚀 Comment démarrer

### Si c'est votre première session:
1. ✅ Vous avez déjà lu ce document!
2. 📋 Lire [PLAN.md](./PLAN.md) pour comprendre les phases du projet
3. 🔧 Lire [CONTEXT.md](./CONTEXT.md) pour comprendre les spécificités techniques
4. 🎬 Commencer par la Phase 1 du plan (créer la structure)

### Si vous revenez travailler sur le projet:
1. 📋 Consulter [PLAN.md](./PLAN.md) pour voir où vous en êtes
2. 🔧 Relire rapidement [CONTEXT.md](./CONTEXT.md) pour rafraîchir les spécificités
3. 💡 Vérifier la section "Notes additionnelles" dans CONTEXT.md
4. ▶️ Reprendre là où vous vous étiez arrêté

---

## 🎓 Objectifs de la conférence

1. **Comprendre les avantages de l'architecture MVVM**
   - Testabilité
   - Séparation des préoccupations
   - Maintenabilité

2. **Prendre connaissance de son utilisation dans RDM présentement**
   - CommunityToolkit.Mvvm (pas ReactiveUI)
   - AvaloniaList avec pattern auto-initialisé
   - Pratiques et conventions RDM

3. **Faciliter l'entrée au développement d'Avalonia**
   - Comparaisons WinForms vs Avalonia
   - Exemples pratiques et concrets
   - Focus sur le "mind shift" nécessaire

---

## 🔑 Points techniques clés (résumé rapide)

### Stack RDM
- ✅ **CommunityToolkit.Mvvm** (pas ReactiveUI)
- ✅ **AvaloniaList** (pas ObservableCollection)

### PowerPoint
- ✅ **Format BILINGUE** (français + anglais) requis
- ✅ Utiliser `Templates/template-DevoCongres_2026.pptx`
- ✅ S'inspirer du format de `Templates/Exemple-Bilingue.pptx` (PAS du contenu!)

### Pattern de collection RDM
```csharp
public AvaloniaList<ItemViewModel> Items { get; } = new();
```
- Readonly property (pas de setter)
- Auto-initialisée (jamais null)
- Permet binding direct sur Count

### Attributs CommunityToolkit.Mvvm
```csharp
[ObservableProperty]  // Génère propriété avec INotifyPropertyChanged
[RelayCommand]        // Génère ICommand
```

---

## 🎯 Démonstration la plus importante

**Demo 3: Master-Detail Pattern**

C'est LA démo qui illustre le mieux le "mind shift" entre WinForms et MVVM:
- WinForms: événements + switch/if + manipulation manuelle de contrôles
- Avalonia: binding sur SelectedItem + ContentControl = magie! ✨

Voir [CONTEXT.md](./CONTEXT.md) pour les détails complets.

---

## 📝 Notes pour Claude Code

Quand vous (Claude) commencez à travailler sur ce projet:

1. **Toujours lire ces 3 fichiers en premier**:
   - CLAUDE.md (celui-ci)
   - PLAN.md
   - CONTEXT.md

2. **Respecter les spécificités RDM**:
   - Utiliser CommunityToolkit.Mvvm (jamais ReactiveUI)
   - Utiliser AvaloniaList (jamais ObservableCollection)
   - Utiliser le pattern de collection auto-initialisée readonly

3. **Mettre à jour CONTEXT.md**:
   - Quand de nouvelles informations techniques sont fournies
   - Quand des décisions architecturales sont prises
   - Dans la section "Notes additionnelles"

4. **Cocher les items dans PLAN.md**:
   - Au fur et à mesure de la progression
   - Pour donner visibilité à l'utilisateur

---

## 📅 Timeline

- **Aujourd'hui (26 déc 2024)**: Création du plan et de la structure
- **Avant le 15 janvier**: Tout le matériel doit être prêt
- **22 janvier 2025**: Jour de la présentation! 🎤

---

## 🆘 Besoin d'aide?

### Questions fréquentes
- **Où est la TODO list?** → [PLAN.md](./PLAN.md)
- **Quelles sont les spécificités RDM?** → [CONTEXT.md](./CONTEXT.md)
- **Quel est le prochain task?** → Vérifier les checkboxes dans [PLAN.md](./PLAN.md)
- **Comment utiliser CommunityToolkit.Mvvm?** → Exemples dans [CONTEXT.md](./CONTEXT.md)

### Ressources externes
- [Avalonia Docs](https://docs.avaloniaui.net/)
- [CommunityToolkit.Mvvm Docs](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- [Avalonia Samples](https://github.com/AvaloniaUI/Avalonia.Samples)

---

**Prêt à commencer? Consultez [PLAN.md](./PLAN.md) pour la Phase 1!** 🚀
