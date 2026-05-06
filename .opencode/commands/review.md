---
description: "Block 6 — Pipeline-Stufe ⑤: Review + MR. Erzeugt Commit-Message + MR-Body aus Diff + allen Vor-Dokumenten."
---

# /review — Scaffolding-Pipeline Stufe ⑤ (Review + MR)

Du bist in **Block 6**, Stufe 5 von 5 — die letzte. Aus dem Diff der `/implement`-Stufe
und den Vor-Dokumenten machst du eine **reviewfähige Merge-Request-Beschreibung**
und eine **gute Commit-Message**.

> **Stufe ⑤ ist ein Mensch-Gate, kein Auto-Commit.** Du schreibst MR-Body und
> Commit-Message vor — der Mensch liest, korrigiert wenn nötig, committed dann
> selbst. Das ist Syntegon-Policy (Risikobeurteilung Matti Meyer für GitHub
> Copilot). „Alles dürfen beim Coden, nur NICHT automatisch committen."

## Auftrag

1. Lies `briefing.md`, `plan.md`, `test-plan.md` und führe `git diff --stat`
   sowie `git diff` aus, um den realen Diff zu sehen.
2. Verifiziere drei Dinge:
   - **Tests sind grün** (`dotnet test` oder projekt-übliches Kommando).
   - **Diff hält sich an Plan** — keine Dateien außerhalb von `plan.md` „Betroffene
     Dateien" sollten geändert sein. Falls doch → in der MR-Beschreibung explizit
     auflisten und begründen (oder zurück zu Stufe ④).
   - **Test-Plan-Akzeptanzkriterien sind durch Tests abgedeckt** — Mapping
     dokumentieren.
3. Erzeuge **zwei Outputs**:

### Commit-Message (Conventional Commits)

```
<type>(<scope>): <kurz, imperativ, max 72 Zeichen>

<body in 1–3 Bullet-Points: was, warum>

Refs: <Ticket-ID falls vorhanden>
```

Types: `feat`, `fix`, `refactor`, `chore`, `docs`, `test`. Im Zweifel `feat` oder
`fix`.

### MR-Body

```markdown
# MR: <Ticket-ID> — <Kurzbeschreibung>

## Was wurde geändert
- <Bullet pro fachlich-relevante Änderung, nicht pro Datei>
- ...

## Warum
[1–3 Sätze aus briefing.md zusammengefasst — fachlicher Anlass]

## Wie verifiziert
[aus test-plan.md zusammengefasst: Akzeptanztests + Edge Cases + manuelle Schritte]

## Reviewer-Hinweise
- Bitte besonders auf <Risiko aus plan.md> achten
- Test-Lauf-Status: <pass/fail>
- Diff-Größe: <X Dateien, +Y/-Z Zeilen>

## Out-of-Scope (bewusst nicht gemacht)
- ... (aus plan.md übernehmen)
```

4. Lege beide als Artefakte ab — entweder als separate Dateien (`COMMIT_MSG.txt`,
   `MR_BODY.md`) oder direkt im Output. **Führe selbst keinen `git commit`,
   `git push` oder `gh pr create` aus.**

## Was du NICHT tust

- **Kein Auto-Commit, kein Auto-Push, kein Auto-MR.** Mensch-Gate ist hart.
- **Keine zusätzlichen Code-Änderungen** mehr in dieser Stufe — wenn was fehlt,
  zurück zu `/implement`.
- **Keine Files modifizieren, die nicht direkt zur MR-Beschreibung gehören.**

## Mensch-Gate

Reviewer:
- Tests grün? Lokal nachgeprüft?
- MR-Body verständlich für jemanden, der den Code nicht kennt?
- Commit-Message conventional + ohne Bullshit-Marker („Generated with Claude Code"
  etc. raus)?
- Diff entspricht Plan?

Bei „ja" → Mensch macht selbst:
1. `git add <files>`
2. `git commit -F COMMIT_MSG.txt` (oder eigene Variante)
3. Push + MR/PR erstellen mit `MR_BODY.md` als Beschreibung.

## Argument

`$ARGUMENTS` (optional): Branch-Name, Ziel-Branch, Ticket-ID, falls die Pipeline das
nicht aus den Dokumenten ziehen konnte.
