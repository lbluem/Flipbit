## 🕹 Flipbit

Ein Videospiel für den Kuti Spieltisch auf der Basis eines bereitgestellten Unity Template Projekts.

---

### ℹ Spielbeschreibung

Unser Spiel trägt den Namen **FLIPBIT** und ist ein kooperativer Retro Plattformer. \
"**FLIP**" soll dafür für das abwechselnde Spielgeschehen und "**BIT**" für den gewählten Grafiksstil stehen. \
Namensgebend lösen die Spieler:innen Level in dem sie abwechselnd den Spielercharakter und bewegbare Plattformen steuern.

### 🧾 Projektstruktur

Die von uns angepassten und hinzugefügten Elemente befinden sich unter dem "/Assets/KutiGame" Verzeichnis.
- Fonts \
_Font Dateien und TextMeshPro Versionen_
- KutiScenes \
_Level und Credit Szenen_
- Materials \
_Ein Material für den Spielcharakter_
- Prefabs \
_Prefabs aller Elemente_
- Scripts \
_Alle C# Skripte_
- Sounds \
_Alle Sounds und Soundtracks_
- Sprites (und Animationen) \
_Alle visuellen Elemente_
- TilePalettes \
_Prefabs der erstellten Tile Paletten_

### 🎬 Szenenaufbau

Alle Szenen bestehen aus
- AndroidInputAdapter
- EventSystem
- Main Camera
- AudioManager

Zusätzlich haben alle Level
- LevelTransition
- Player
- Tilemaps
- SwapPad(s)
- (Platform Controller)
- (Boxes)

### 🕸 Skript Relationen
![Flipbit Skript Relations](https://github.com/lbluem/Kuti_von_Template/assets/66683993/d6fc6424-b8ce-4334-823b-fee78c052b93)
(alle Relationen sind unidirektional)

