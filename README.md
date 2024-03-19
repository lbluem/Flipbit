## 🕹 Kuti von Template

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
- 1BitPlayer
- Tilemaps
- SwapPad(s)
- (Platform Controller)
- (Boxes)

### 🕸 Skript Relationen
![Flipbit Skript Relations](https://github.com/lbluem/Kuti_von_Template/assets/66683993/62ba848e-a38f-4a88-80c1-d9ac59afff11)
(alle Relationen sind unidirektional)

### ♨ Liste externer Materialien

- Alle Grafiken stammen aus dem "1-Bit Platformer Pack" von "Kenney.nl".
- Die Fonts sind ebenfalls von "Kenney.nl".
- Der Soundtrack ist aus dem "Generic 8-bit JRPG Soundtrack" von "AVGVSTA".
