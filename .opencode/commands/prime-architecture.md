---
description: "Block 5 — Runde 1/3: Architektur-Priming. Erzeugt ai_docs/ARCHITECTURE.md aus dem Brownfield-Code."
---

# /prime-architecture — Brownfield Onboarding, Runde 1 von 3

Du bist im **Block 5** des Workshops. Wir bauen das Kontext-Bündel `ai_docs/` für eine
bestehende Codebase auf — Schritt für Schritt, in drei Runden mit Rollen-Rotation.

**Diese Runde: Architektur.** Was ist das System, woraus besteht es, wie hängt es
zusammen?

## Rollen in dieser Runde

- **KI-Driver** (tippt): führt diesen Command aus, prompted nach
- **Code-Owner** (challenged): kennt den Code, korrigiert Halluzinationen
- **Context-Capturer** (schreibt): nimmt Korrekturen direkt in die Datei auf

## Auftrag

1. Lies oberste Verzeichnisse + zentrale Build-/Solution-/Project-Dateien
   (`*.sln`, `*.csproj`, `CMakeLists.txt`, `package.json`, …) — verstehe **Module-Grenzen
   und Tech-Stack**.
2. Lies pro Modul je 1–2 Schlüssel-Dateien (Entrypoint, zentrale Klasse, Public-API),
   nicht alles. Du sollst die Architektur **skizzieren**, nicht den Code referieren.
3. Identifiziere Datenflüsse zwischen Modulen — wer ruft wen auf, über welche
   Schnittstelle (REST, IPC, Message Queue, In-Process)?
4. Markiere ausdrücklich, was du **nicht aus dem Code rauslesen kannst** und
   was den Code-Owner gefragt werden müsste (Legacy-Status, Deprecated-Module,
   geplanter Umbau, organisatorische Constraints).
5. Schreibe das Ergebnis nach `ai_docs/ARCHITECTURE.md` mit folgenden Sections:

```markdown
# System Architecture

## Overview
[High-level Beschreibung des Systems in 3–5 Sätzen]

## Components
- **<Modul-Name>**: [Aufgabe]
  - Technology: <Sprache/Framework>
  - Communication: <REST/IPC/MQ/...>
  - Constraints: <Echtzeit, Hardware, GMP, ...>
- ...

## Data Flow
1. ...
2. ...

## Important Notes (vom Code-Owner zu validieren)
- [Annahme/Vermutung] — bitte vom Code-Owner bestätigen oder korrigieren
- ...

## Open Questions
- [Was ich nicht aus dem Code rauslesen konnte]
```

## Was du NICHT tust

- KEINE Code-Änderungen.
- KEIN Implementierungsplan, kein Refactoring-Vorschlag.
- KEINE generischen Architektur-Best-Practices („sollte microservice werden") — wir
  wollen den **Ist-Zustand** beschreiben, nicht den Soll.
- KEINE erfundenen Komponenten — wenn du etwas nicht im Code findest, schreib es in
  „Open Questions".

## Mensch-Gate (Code-Owner challenged, Context-Capturer schreibt)

Nach Lauf:

1. Code-Owner liest `ARCHITECTURE.md` und challenged jede Component-Beschreibung.
2. Context-Capturer trägt Korrekturen direkt in die Datei nach (nicht aus dem Kopf —
   Korrekturen sind das wertvollste Material für ai_docs).
3. Erst wenn der Code-Owner „passt" sagt, geht es in Runde 2 (`/prime-domain`).

## Argument

`$ARGUMENTS` (optional): konkrete Pfade oder Module, auf die du dich konzentrieren
sollst. Ohne Argument → Top-Level-Scan über das ganze Repo.
