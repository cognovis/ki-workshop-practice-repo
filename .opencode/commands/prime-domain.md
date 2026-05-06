---
description: "Block 5 — Runde 2/3: Domain-Priming. Erzeugt ai_docs/DOMAIN_KNOWLEDGE.md."
---

# /prime-domain — Brownfield Onboarding, Runde 2 von 3

Du bist im **Block 5**, Runde 2. `ai_docs/ARCHITECTURE.md` ist da (aus
`/prime-architecture`). Jetzt extrahieren wir das **Domain-Wissen** — die Begriffe,
Business-Regeln und regulatorischen Constraints, die der Code allein nicht
verrät.

**Rollen rotieren** — wer in Runde 1 KI-Driver war, ist jetzt Code-Owner. Code-Owner →
Context-Capturer. Context-Capturer → KI-Driver.

## Warum diese Runde existiert

Architektur kannst du aus dem Code lesen. Domain nicht. „Charge" sieht aus wie
„Batch", ist aber regulatorisch was anderes. „Rezept" sieht aus wie ein Konfigurations-
Objekt, hat aber GMP-Validierungs-Pflicht. Genau das soll hier rein.

## Auftrag

1. Lies `ai_docs/ARCHITECTURE.md` — verstehe, was es schon gibt.
2. Scanne den Code nach **Fachbegriffen** (Klassen-, Methoden-, Variablennamen,
   Kommentaren, Strings in der UI, Doku-Kommentaren). Sammle die Top-15 Begriffe,
   die nicht-trivial sind — keine generischen IT-Wörter wie „Service" oder „Repository".
3. Für jeden Begriff: schreibe 1 Satz **wie du ihn aus dem Code interpretierst** —
   ausdrücklich als Vermutung markiert. Der Code-Owner wird gleich draufschauen.
4. Identifiziere **Business-Regeln** und **regulatorische Constraints**, die im Code
   sichtbar sind: Audit-Trail-Patterns, GMP-Hinweise, „nicht löschen"-Kommentare,
   Validierungs-Gates, Hardware-Timeout-Konstanten, …
5. Schreibe nach `ai_docs/DOMAIN_KNOWLEDGE.md`:

```markdown
# Domain Knowledge

## Glossar (vom Code-Owner zu validieren)
- **<Begriff>**: [Vermutung aus Code] — *bitte vom Code-Owner bestätigen/korrigieren*
- ...

## Business Rules
- [Beobachtete Regel + wo sie im Code sichtbar ist]
- ...

## Regulatorische / sicherheitsrelevante Constraints
- [GMP / Audit / Hardware-Timing / Datenschutz]
- ...

## Open Questions (Domain)
- [Was du nicht aus dem Code wissen konntest]
```

## Was du NICHT tust

- KEINE Architektur-Wiederholung — die steht in `ARCHITECTURE.md`.
- KEINE Code-Änderungen, kein Refactoring-Vorschlag.
- KEINE erfundenen Begriffe — nur was im Code wirklich vorkommt.
- KEINE Übersetzungen ins Englische, wenn das Team auf Deutsch arbeitet
  (z. B. „Charge" bleibt „Charge", nicht „Batch").

## Mensch-Gate

1. Code-Owner liest jeden Glossar-Eintrag und korrigiert. **Falsche Vermutungen sind
   das wertvollste Material** — sie zeigen genau, wo die KI ohne `ai_docs/` halluziniert
   hätte.
2. Context-Capturer trägt Korrekturen ein und ergänzt Begriffe, die der Agent
   übersehen hat.
3. Auch eine kurze „Common Misunderstandings"-Sektion am Ende anlegen mit den
   Top-3-Korrekturen — die sind in Runde 3 (Conventions/Gotchas) wieder relevant.

## Argument

`$ARGUMENTS` (optional): Pfade oder Module, auf die du dich konzentrieren sollst.
Ohne Argument → über die in `ARCHITECTURE.md` gelisteten Components iterieren.
