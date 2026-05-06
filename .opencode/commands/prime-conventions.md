---
description: "Block 5 — Runde 3/3: Conventions & Gotchas Priming. Erzeugt ai_docs/CONVENTIONS.md + ai_docs/GOTCHAS.md."
---

# /prime-conventions — Brownfield Onboarding, Runde 3 von 3

Du bist im **Block 5**, Runde 3 — die letzte. `ARCHITECTURE.md` und
`DOMAIN_KNOWLEDGE.md` sind da. Jetzt holen wir die **stillen Konventionen** und die
**Fallen**, in die jeder neue Mensch (und jede KI) einmal tappt.

**Rollen rotieren erneut.** Jeder hat jetzt einmal jede Rolle gehabt.

## Worum es geht

- **Conventions:** Wie schreibt das Team Code? Naming, Layering, async-Regeln, DI,
  Test-Konventionen, Git-Workflow, Branch-Naming, Commit-Messages.
- **Gotchas:** Wo halluziniert die KI typischerweise? Was sieht aus wie Standard,
  ist aber bei euch anders? Welche Patterns hat das Team explizit verworfen?

Die Korrekturen aus Runde 1+2 (`ARCHITECTURE.md`, `DOMAIN_KNOWLEDGE.md` „Common
Misunderstandings") sind euer **Rohmaterial** für die Gotchas.

## Auftrag

1. Lies `ai_docs/ARCHITECTURE.md` und `ai_docs/DOMAIN_KNOWLEDGE.md` — vor allem die
   „Open Questions"- und „Common Misunderstandings"-Sektionen.
2. Scanne den Code nach **wiederkehrenden Patterns**:
   - Naming-Konventionen (PascalCase / camelCase / Async-Suffix / Interface-Präfix)
   - DI-Stil, Layering (Repo/Service/Controller, oder Modul-basiert?)
   - Async-Regeln (überall async? oder Native/Hot-Path sync?)
   - Error-Handling-Stil (Exceptions / Result-Type / Returncodes)
   - Test-Stil (Framework, Naming, Fixtures, Coverage-Erwartung)
   - Build-/CI-/Lint-Konventionen (`*.editorconfig`, `*.gitlab-ci.yml`, `Directory.Build.props`)
3. Sammle aus den Korrekturen der vorigen Runden die **typischen
   KI-Halluzinationen** für genau diese Codebase.
4. Schreibe **zwei** Dokumente:

### ai_docs/CONVENTIONS.md

```markdown
# Code Conventions

## Naming
- ...

## Layering / Module-Grenzen
- ...

## Async / Sync
- ...

## Error Handling
- ...

## Tests
- Framework: ...
- Naming: ...
- Coverage-Erwartung: ...

## Git Workflow
- Branch naming: ...
- Commit messages: ...
- PR/MR Review-Regeln: ...
```

### ai_docs/GOTCHAS.md

```markdown
# Common Pitfalls & KI-typische Halluzinationen

## Issue: <Beschreibung>
**Was die KI typischerweise vorschlägt**: ...
**Korrekt für unsere Codebase**: ...
**Grund**: ...
**Beispiel** (optional): <code>

## Issue: ...
```

## Was du NICHT tust

- KEINE generischen Best-Practices („nutzt SOLID-Prinzipien!") — wir wollen, was
  **dieses Team** wirklich macht, nicht was es laut Lehrbuch tun sollte.
- KEINE Empfehlungen zur Verbesserung — Gotchas beschreiben **Ist-Stand**, nicht
  Soll-Stand. Verbesserungsvorschläge gehen in einen Refactor-Backlog, nicht
  in `ai_docs/`.
- KEIN Refactoring, keine Code-Änderungen.

## Mensch-Gate (alle drei Rollen)

1. Code-Owner: Stimmen die Naming-/Layering-/Async-Beschreibungen?
2. KI-Driver: Würdest du als „Outsider" diese Conventions verstehen und anwenden
   können?
3. Context-Capturer: Sind die Gotchas konkret genug, dass die KI beim nächsten Lauf
   davon profitiert? (Vage Gotchas wie „pass auf bei XYZ" helfen nicht — Beispiele
   sind Gold.)

## Abschluss von Block 5

Nach Runde 3 liegt vor:

```
ai_docs/
├── ARCHITECTURE.md
├── DOMAIN_KNOWLEDGE.md
├── CONVENTIONS.md
└── GOTCHAS.md
```

Empfehlung danach: lege noch ein `AGENTS.md` im Repo-Root an, das auf `ai_docs/*`
verweist — OpenCode liest `AGENTS.md` automatisch als Standardkontext für jede
Session. Siehe Handout `05-context-documentation.md`.

## Argument

`$ARGUMENTS` (optional): konkretes Modul oder Schwerpunkt
(z. B. „nur Test-Conventions", „nur Native-C++-Teil"). Ohne Argument → über alle
Module iterieren.
