---
description: "Block 6 — Pipeline-Stufe ④: Implementation. Liest briefing.md + plan.md + test-plan.md, schreibt Code + Tests."
---

# /implement — Scaffolding-Pipeline Stufe ④ (Implement)

Du bist in **Block 6**, Stufe 4 von 5. Jetzt entsteht **Code + Tests** — alles
Vorhergehende war Vorbereitung. Du nimmst genau drei Dokumente als Input
(`briefing.md`, `plan.md`, `test-plan.md`) und produzierst einen Diff.

> **Tool-Hinweis:** Diese Stufe lässt sich auch mit `opencode-cli run "..."`
> nicht-interaktiv scripten — selbe Custom Commands, andere Aufruf-Form. Siehe
> Handout `06-scaffolding-pipeline.md`.

## Auftrag

1. Lies `briefing.md`, `plan.md`, `test-plan.md`. Falls eines fehlt → STOP.
2. Lies die in `plan.md` gelisteten Dateien — **und nur die**. Du sollst nichts
   anfassen, was nicht im Plan steht.
3. Implementiere in dieser Reihenfolge:
   - **Red:** Schreibe zuerst die Tests aus `test-plan.md` als Test-Code
     (xUnit + FluentAssertions, oder das in `ai_docs/CONVENTIONS.md` festgelegte
     Framework). Lass sie rot sein.
   - **Green:** Schreibe den Produktionscode, bis die Tests grün sind.
   - **Clean:** Refactor — nur die in diesem Lauf neu/geänderten Stellen, nichts
     außerhalb.
4. Halte dich strikt an `ai_docs/CONVENTIONS.md`. Bei Konflikt mit Standard-
   Vorschlägen → Convention gewinnt.
5. Lass am Ende `dotnet test` (oder das projekt-übliche Test-Kommando) laufen und
   berichte: alles grün?

## Sicherheitsnetze (hard rules)

- **Nichts außerhalb des Plans anfassen.** Wenn du beim Implementieren merkst, dass
  Datei Z auch geändert werden müsste — STOP. Berichte das, lass den Menschen den
  Plan nachschärfen, dann nochmal.
- **Tests müssen vor Stufe ⑤ grün sein.** Falls rot bleiben → STOP, Menschen
  fragen.
- **Klein halten:** Wenn dein Diff plötzlich >300 Zeilen wird, obwohl der Plan
  „klein" wirkte — pausiere und challenge den Plan.
- **Kein Auto-Commit.** Du machst keine `git commit`-Aufrufe. Stufe ⑤ ist immer ein
  Mensch-Gate (Syntegon-Policy / Risikobeurteilung Matti Meyer).

## Was du NICHT tust

- **Keine `git commit` / `git push` / `git rebase`-Operationen.** Auch keine
  Branch-Operationen.
- **Keine Refactorings „on the side"** — auch wenn der Code an dir vorbei
  „aufräumend" schreit. In `plan.md` „Out-of-Scope" gehört das, oder als
  Refactor-Bead ins Backlog.
- **Keine neuen Pakete / Dependencies hinzufügen**, ohne dass das im Plan
  steht.
- **Keine Docs-Updates an `ai_docs/`** in dieser Stufe — die kommen in einem
  separaten Lauf, falls die Aufgabe Konventionen geändert hat.

## Mensch-Gate

Nach Stufe ④ schaut der Reviewer:
- Sind die Tests grün?
- Hält sich der Diff an `plan.md` (keine fremden Dateien)?
- Liest sich der Code wie unser Stil oder wie Generic-LLM-Code?

Wenn ja → `/review` als letzte Stufe.

## Argument

`$ARGUMENTS` (optional): keine erwartet — alles steht in den drei Eingabe-
Dokumenten. Falls trotzdem etwas mitgegeben wird, behandle es als zusätzliche
Hinweise vom Menschen (z. B. „beachte zusätzlich X").
