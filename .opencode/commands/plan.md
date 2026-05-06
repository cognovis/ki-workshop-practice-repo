---
description: "Block 6 — Pipeline-Stufe ②: Implementierungsplan. Liest briefing.md, schreibt plan.md."
---

# /plan — Scaffolding-Pipeline Stufe ② (Plan)

Du bist in **Block 6**, Stufe 2 von 5. Aus dem Briefing wird ein **fachlich-technischer
Plan**: was zu tun ist und wo, **nicht** Zeile für Zeile.

## Auftrag

1. Lies `briefing.md`. Falls fehlt → STOP, der Mensch soll erst `/context` laufen
   lassen.
2. Lies — sofern nicht schon im Briefing zitiert — die im Briefing genannten
   Code-Pfade. Verstehe den Ist-Zustand.
3. Leite einen **fachlich-technischen** Plan ab:
   - Was muss geändert werden? (auf Klassen-/Methoden-/Komponenten-Ebene)
   - In welcher Reihenfolge?
   - Welche Schnittstellen müssen mitgezogen werden?
4. Identifiziere **Risiken und Annahmen**. Vor allem: Wird ein Interface von außen
   genutzt? Bricht etwas? Gibt es einen Performance-Impact?
5. Schreibe `plan.md`:

```markdown
# Plan: <Aufgabe aus briefing.md>

## Vorgehen (high-level, fachlich)
1. [Schritt 1, fachlich beschrieben — nicht Code]
2. [Schritt 2]
3. ...

## Betroffene Dateien
- src/Foo/Bar.cs — Methode X um Parameter Y erweitern
- src/Foo/IBar.cs — Interface aktualisieren
- tests/Foo/BarTests.cs — neuer Test für Y

## Risiken / Annahmen
- Annahme: Modul Z wird nicht von außen aufgerufen → kann ohne Breaking-Change
  verändert werden
- Risiko: Schnittstelle X wird in 3 anderen Projekten genutzt → potential Breaking
  Change, vor Stufe ④ Code-Owner fragen

## Out-of-Scope
- [Was wir explizit NICHT in diesem Lauf tun — z. B. „Migration auf neue
  Async-Variante kommt in eigenem Plan"]
```

## Wichtig

- **Fachlich-technisch, nicht technisch-technisch.** Der Plan sagt *was* zu tun ist
  und *wo*, aber **nicht** wie jede einzelne Code-Zeile aussieht. Code-Details
  passieren in Stufe ④ (`/implement`).
- **Klein halten.** Wenn der Plan mehr als ~3 Dateien anfasst, schlag dem Menschen
  vor, ihn aufzuteilen. Große Pläne → schlechte Implementierung.

## Was du NICHT tust

- **Nicht implementieren.** Keine Zeile Code.
- **Keinen Test-Plan schreiben.** Tests sind Stufe ③, das macht `/test-plan`.
- **Keine Refactorings „nebenbei".** Wenn dir was auffällt, was nicht zur Aufgabe
  gehört → in „Out-of-Scope" listen, nicht in den Plan packen.

## Mensch-Gate (≈5 Minuten)

Reviewer liest `plan.md` und challenged:
- Ist das der richtige Weg? (vor allem: kein blinder Standard-Approach, der euer
  Domain-Setup ignoriert)
- Fehlt eine Datei?
- Werden Risiken realistisch abgeschätzt?

Bei Unklarheiten: lieber zurück zu `/context` und Briefing nachschärfen, als mit
schlechtem Plan in `/test-plan` zu gehen.
