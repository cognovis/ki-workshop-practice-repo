# Workshop-Reference Commands für OpenCode

Diese Custom Commands gehören zum **Syntegon KI-Workshop** (5./6. Mai 2026,
Crailsheim). Sie sind als **Vorlage** gedacht — kopiert sie in euer eigenes
Repository unter `.opencode/commands/`, passt sie an euren Stack an, baut weiter.

> **Gilt auch für Claude Code / Codex CLI:** Die Konvergenz ist `.opencode/commands/`
> oder `.claude/commands/`. Inhalt der Markdown-Dateien funktioniert in beiden
> Tools — der Frontmatter-Teil (`---`) ist OpenCode-spezifisch und wird von
> anderen Tools ignoriert.

## Block 5 — Brownfield-Onboarding (3 Runden, Rollen-Rotation)

3er-Teams, drei Rollen rotieren pro Runde:
**KI-Driver** (tippt) · **Code-Owner** (challenged) · **Context-Capturer** (schreibt)

| Runde | Command | Output |
|-------|---------|--------|
| 1 | `/prime-architecture` | `ai_docs/ARCHITECTURE.md` |
| 2 | `/prime-domain` | `ai_docs/DOMAIN_KNOWLEDGE.md` |
| 3 | `/prime-conventions` | `ai_docs/CONVENTIONS.md` + `ai_docs/GOTCHAS.md` |

**Faustregel:** Falsche KI-Annahmen aus Runde 1+2 sind das wertvollste Material
für Runde 3 — sie zeigen exakt, wo `ai_docs/` ohne diese Datei halluziniert hätte.

## Block 6 — Scaffolding-Pipeline (5 Stufen)

Pro Aufgabe einmal von oben nach unten durchlaufen. Jede Stufe produziert ein
Dokument, das Input für die nächste ist.

| Stufe | Command | Input | Output |
|-------|---------|-------|--------|
| ① | `/context` | Ticket-ID / Aufgabenbeschreibung + `ai_docs/` | `briefing.md` |
| ② | `/plan` | `briefing.md` | `plan.md` |
| ③ | `/test-plan` | `briefing.md` + `plan.md` | `test-plan.md` |
| ④ | `/implement` | alle drei Dokumente | Code + Tests (Diff) |
| ⑤ | `/review` | Diff + alle Dokumente | `COMMIT_MSG.txt` + `MR_BODY.md` |

**Mensch-Gates** liegen zwischen jeder Stufe — am wichtigsten zwischen ② und ③
(„ist der Plan richtig?") und nach ⑤ (Mensch macht den Commit, **nie** der
Agent).

## Block 7 — Anwendung auf eigene Aufgabe

Block 7 hat **keine eigenen Commands** — er nutzt die Pipeline aus Block 6 mit
einer realen, mitgebrachten Aufgabe aus eurem Backlog. Falls Zeit reicht, lauft
Stufe ① + ② + ③ durch (oft schon Realismus genug). Stufe ④ + ⑤ als Stretch.

## Wie ihr das nutzt

### Im interaktiven OpenCode (TUI):
```
opencode-cli
> /prime-architecture
> /prime-domain
> /prime-conventions
> /context Ticket-1234: Refactor Charge-Repository
> /plan
> /test-plan
> /implement
> /review
```

### Nicht-interaktiv (skriptbar):
```bash
opencode-cli run "/prime-architecture"
opencode-cli run "/context Ticket-1234: Refactor Charge-Repository"
opencode-cli run "/plan"
# ...
```

## Anpassen an euren Stack

Die Commands sind C#/.NET-lastig formuliert (`xUnit`, `dotnet test`,
`FluentAssertions`). Ändert das in den Markdown-Dateien auf euer
Test-Framework, eure Build-Tools, eure Naming-Konventionen — die Struktur der
Pipeline bleibt gleich.

Domain-Beispiele (Charge / Rezept / GMP) ersetzt durch eure echte Domäne — je
konkreter, desto weniger halluziniert die KI.

## Anti-Patterns

- **Pipeline überspringen, weil „die Aufgabe klein ist".** Wenn sie wirklich klein
  ist (Rename, Typo) → kein Agent, mach es selbst. Wenn sie nicht klein ist → ganze
  Pipeline.
- **Alles in eine riesige Custom-Command-Datei.** Pro Stufe ein Command. Macht
  Stufen austauschbar.
- **Domain-Wissen in Custom Commands hardcoden.** Domain gehört nach `ai_docs/`,
  von **allen** Commands gelesen. Custom Commands sind Verben, `ai_docs/` sind
  Nomen.
- **Auto-Commit aktivieren.** Verstößt gegen Syntegon-Policy
  (Risikobeurteilung Matti Meyer). Mensch macht den Commit.

## Hintergrund

- Pipeline-Konzept: 5 Stufen sind eine Vereinfachung der bei cognovis intern
  genutzten 17-stufigen `beads-workflow` Phase-0–16 Orchestrator-Pipeline. Reduziert
  auf das, was in 1,5 Tagen Workshop trainierbar ist.
- Vollständiger Workflow / Ausbau in Folge-Sessions à 290 €/h (siehe Angebot).

## Lizenz

MIT — bedient euch, baut weiter, teilt mit anderen Teams.
