---
description: "Block 6 — Pipeline-Stufe ③: Test-Plan aus Beobachter-Sicht. Liest briefing.md + plan.md, schreibt test-plan.md."
---

# /test-plan — Scaffolding-Pipeline Stufe ③ (Test-Plan)

Du bist in **Block 6**, Stufe 3 von 5. Du beschreibst aus **Beobachter-Sicht**,
woran wir später erkennen, dass Stufe ④ (`/implement`) erfolgreich war.

## Schlüssel-Insight

Der Test-Plan ist **kein Test-Code**. Er beschreibt aus *menschlicher Beobachtersicht*,
wie Erfolg aussieht. Der nächste Agent (oder ihr selbst) übersetzt das später in
Test-Code.

**Warum getrennt von „Tests schreiben"?** Weil das Skill „wie schreiben wir Tests in
unserem Projekt" (xUnit-Pattern, Fixtures, Naming) **konstant** ist. Das Skill „was
muss getestet werden" ist **pro Aufgabe verschieden**. Trennt man die zwei, wird die
Pipeline wiederverwendbar.

## Auftrag

1. Lies `briefing.md` und `plan.md`. Falls eines fehlt → STOP, vorherige Stufe
   nachholen lassen.
2. Schreibe `test-plan.md` mit folgenden Sections:

```markdown
# Test-Plan: <Aufgabe>

## Akzeptanztests (Given/When/Then)
1. **Wenn** <Vorbedingung>, **und** <Aktion>, **dann** <erwartetes beobachtbares
   Ergebnis>
2. ...

## Edge Cases
- Was passiert bei null/empty-Input?
- Was passiert bei sehr großen Werten?
- Was passiert bei gleichzeitigem Zugriff?
- Was passiert, wenn Subsystem X nicht erreichbar ist?

## Wie wir es prüfen
- **Automatisiert** (bevorzugt):
  - Unit-Tests in tests/.../...
  - Integrations-Test mit Mock von Z
  - End-to-End/CLI-Aufruf gegen Eingabe/Ausgabe-Werte
- **Manuell** (nur wenn nicht automatisiert geht):
  - Smoke-Test: <konkrete Schritte>
  - Hardware-In-The-Loop: <was, wo, wer>
```

## Test-Strategie für Anlagenbau-Kontext

Fokus auf **Gesamt-Applikations-Tests** (CLI-Aufruf mit Eingabe/Ausgabe-Werten,
HTTP-Port-Abgriff via Playwright CLI), **nicht jede einzelne Unit-Test-Methode
separat**. Was den Agent (und damit die Pipeline) interessiert:

> „Kann ich nachweisen, dass das Feature funktioniert?" — egal ob via Unit-Test,
> Integration-Test oder Screenshot-Vergleich.

Wenn ein Akzeptanzkriterium nur durch echte Hardware/Anlage prüfbar ist — explizit
als „manuell" markieren mit der genauen Schrittfolge. Nicht versuchen, das automatisch
abzubilden.

## Was du NICHT tust

- **Keinen Test-Code schreiben.** Test-Code ist Stufe ④. Hier nur Beobachter-
  Beschreibung.
- **Keine internen Implementierungs-Details testen.** „Methode X wird mit
  Parameter Y aufgerufen" ist falsche Abstraktion. Statt: „Bei Eingabe Y zeigt das
  System Z."
- **Keine generischen Test-Listen** („80% Coverage erreichen"). Konkrete
  Akzeptanzkriterien aus dem Briefing sind die Quelle.

## Mensch-Gate

Code-Owner / Reviewer liest:
- Decken die Akzeptanztests die Akzeptanzkriterien aus `briefing.md` ab?
- Sind Edge Cases realistisch für unsere Domain (z. B. „was passiert bei
  Pharma-spezifischer Constraint X")?
- Ist klar, **wie** geprüft wird (automatisiert vs. manuell)?

Wenn ja → `/implement` als nächstes.
