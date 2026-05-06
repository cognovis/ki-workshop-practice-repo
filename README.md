# Agentic Coding Practice Repository (C# / .NET 8)

Übungs-Repository für KI-Workshops mit Coding-Agenten (z.B. OpenCode, Claude Code, Codex CLI).

Cognovis nutzt dieses Repo in Workshops, um Teilnehmer den Einstieg in **Stufe 2** der KI-gestützten Entwicklung zu ermöglichen — mit *einem* Coding-Agent prompt-basiert arbeiten, Code im Diff/MR reviewen.

## Repo holen

```bash
git clone https://github.com/cognovis/ki-workshop-practice-repo.git
cd ki-workshop-practice-repo
dotnet build
dotnet test
```

Der erste Test-Run **muss Failures zeigen** — das ist Absicht. Dort lauern die Bugs, die ihr im Workshop fixen werdet (siehe unten, primär in `Utils.cs`).

## Voraussetzungen

- .NET SDK installiert — Standard ist `net8.0` (`dotnet --version` muss funktionieren)
- Ein Coding-Agent CLI eurer Wahl (OpenCode, Claude Code, Codex)
- Optional: API-Zugang über LiteLLM-Routing oder direkt

> **Andere .NET-Version installiert?** Das ist ein perfekter erster Use Case für den Agenten — lasst ihn die Migration planen und durchführen (Plan zuerst, dann implementieren, dann verifizieren). Siehe Workshop Block 2 Bonus-Übung.

## Struktur

```
practice-repo/
├── PracticeRepo.sln
├── .opencode/
│   └── commands/          # Workshop-Reference Commands für Block 5–7 (siehe README darin)
├── src/
│   ├── Calculator/        # Calculator-Modul (sauber implementiert, dient als Demo)
│   │   └── Calculator.cs
│   └── Utils/             # Utility-Funktionen MIT versteckten Bugs (eure Spielwiese)
│       └── Utils.cs
└── tests/
    ├── Calculator.Tests/  # xUnit-Tests, teilweise vorhanden
    └── Utils.Tests/       # xUnit-Tests, sehr unvollständig — eure Aufgabe
```

## Workshop-Reference Commands (Block 5–7)

Im Verzeichnis [`.opencode/commands/`](.opencode/commands/README.md) findet ihr
fertig formulierte Custom Commands für die Workshop-Blöcke 5–7:

- **Block 5 (Brownfield-Onboarding):** `/prime-architecture`, `/prime-domain`,
  `/prime-conventions` — drei Runden mit Rollen-Rotation, erzeugen `ai_docs/`.
- **Block 6 + 7 (Scaffolding-Pipeline):** `/context`, `/plan`, `/test-plan`,
  `/implement`, `/review` — die 5 Pipeline-Stufen.

Kopiert sie in euer eigenes Repo unter `.opencode/commands/` und passt sie an
euren Stack an. Funktionieren ebenso unter `.claude/commands/` für Claude Code.

## Bug-Status

| Datei | Status | Was zu tun ist |
|-------|--------|----------------|
| `Calculator.cs` | ✅ sauber | Demo-Beispiel — kann erweitert werden (z.B. neue Methoden) |
| `Utils.cs` | 🐛 enthält Bugs | Hier ist die Spielwiese — Bug-Hunt + Tests + Fix |

In `Utils.cs` versteckt sind:

- **`FindMax`** — off-by-one Fehler (das letzte Element wird nie verglichen)
- **`ParseJson<T>`** — kein Try/Catch, wirft bei malformed JSON
- **`RemoveDuplicates`** — O(n²) Implementierung, läuft lange bei großen Listen
- **`ValidateEmail`** — prüft nur auf "@", keine echte Validation
- **`CalculateAge`** — berücksichtigt nicht, ob Geburtstag dieses Jahr schon war

`IsPalindrome` und `Capitalize` sind sauber.

## Workshop-Übungen

### Übung 1 — Codebase verstehen lassen

```bash
opencode "Was macht dieses Projekt? Welche Klassen sind drin und wofür?"
```

Notiert eine Erkenntnis und eine Überraschung.

### Übung 2 — Bug-Hunt in Utils.cs

```bash
opencode "Analysiere src/Utils/Utils.cs gründlich. Liste alle möglichen Bugs,
fehlende Validation, Performance-Issues und Edge-Cases auf — mit Begründung."
```

### Übung 3 — Roter Test schreiben

Wählt EINEN Bug aus Übung 2 (Empfehlung: `FindMax` off-by-one — versteckter):

```bash
opencode "Schreibe einen FAILING xUnit-Test mit FluentAssertions für den
FindMax-Bug. Nutze Should_X_When_Y Naming. Lass den Test rot bleiben."
dotnet test --filter FindMax
```

### Übung 4 — Bug fixen + Diff lesen

```bash
opencode "Fixe den FindMax-Bug so, dass alle Tests grün werden. Ändere NUR
Utils.cs FindMax — nichts anderes. Schlag mir die Commit-Message vor,
ich committe selbst."
dotnet test
```

> **Wichtig:** Den `git commit` macht ihr selbst. Auto-Commit durch den Agent ist Workshop-Anti-Pattern.

### Übung 5 — Refactoring

```bash
opencode "RemoveDuplicates in Utils.cs ist O(n²). Refaktoriere auf O(n) mit
HashSet. Bestehende Tests müssen grün bleiben. Schreibe einen
Performance-Test mit Stopwatch, der den Unterschied dokumentiert."
```

### Übung 6 — Tests vervollständigen

`Utils.Tests/UtilsTests.cs` ist fast leer. Erweitert auf hohe Coverage:

```bash
opencode "Schreibe umfassende xUnit-Tests für alle Methoden in Utils.cs.
Decke ab: Happy Path, Edge Cases, Null-Inputs, Error-Cases.
Nutze FluentAssertions und unsere Should_X_When_Y-Naming-Konvention."
```

## Lernziele

- Verstehen, wie ein Coding-Agent mit C# / .NET arbeitet
- Praktisch Bugs finden + analysieren + fixen lassen
- Tests aus Beobachter-Sicht beschreiben + generieren
- Konversationsstil statt Tab-Tab-Auto-Completion
- Diff-Review als Standard-Praxis etablieren
- Mensch macht den Commit (kein Auto-Commit)

## Meta-Hinweise

- Die Bugs in `Utils.cs` sind **bewusst** drin. Auch wo der Code "funktioniert", lauern Edge Cases.
- Wenn der Agent etwas vorschlägt, **nicht blind übernehmen** — review jede Änderung.
- Wenn ihr fertig seid, schreibt einen kurzen Eintrag in `ai_docs/CORRECTIONS.md`: was hat der Agent falsch verstanden, was musstet ihr korrigieren? Material für Tag-2-Reflexion.

## Lizenz

MIT — bedient euch, baut weiter, teilt mit anderen Teams. Pull Requests willkommen.

## Kontakt

[cognovis GmbH](https://cognovis.de) — Malte Sussdorff
