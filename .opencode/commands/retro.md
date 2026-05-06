---
description: "Block 7 Abschluss — Pipeline-Retro: schreibt retro-report.md + schlägt Patches für ai_docs/ vor. Session-close light."
---

# /retro — Pipeline-Retro & ai_docs-Update

Du bist am **Ende eines Pipeline-Laufs**. Vor dir liegen `briefing.md`, `plan.md`,
`test-plan.md` und (bei Stretch) der Diff der Implementierung. Aufgabe dieser Stufe:
herausziehen, was der nächste Lauf besser machen kann — und genau die `ai_docs/`-
Stellen identifizieren, die nachgeschärft werden sollten.

Denk daran als **session-close light**: kein Commit, kein Push, kein Tag — nur
Lernschleife.

## Warum es das gibt

Die Pipeline ist nur so gut wie das `ai_docs/`, das ihr in Block 5 gebaut habt.
Jedes Mal, wenn ihr im Pipeline-Lauf (Block 6/7) einen KI-Output korrigieren musstet,
ist das ein Signal: in `ai_docs/` fehlt was. Diese Stufe macht aus dem Bauchgefühl
„hat sich komisch angefühlt" konkrete Patches an Domain-Knowledge, Conventions oder
Gotchas — sonst verfällt das Wissen mit dem Pipeline-Lauf.

## Auftrag

1. Lies die Pipeline-Artefakte: `briefing.md`, `plan.md`, `test-plan.md`,
   ggf. `MR_BODY.md` und die letzten Commits / den Arbeitsdiff.
2. Lies `ai_docs/ARCHITECTURE.md`, `DOMAIN_KNOWLEDGE.md`, `CONVENTIONS.md`,
   `GOTCHAS.md` — du brauchst den Soll-Stand.
3. Frage das Team **drei Reflexions-Fragen** und nimm die Antworten als Input
   (oder leite sie aus Diff + Korrekturen im Verlauf ab, falls du sie als
   Begleit-Context bekommst):

   - **Was musste der Mensch der KI sagen, was nicht in `ai_docs/` stand?**
     (Domain-Begriffe, Constraints, organisatorische Regeln)
   - **Wo hat die KI etwas vorgeschlagen, das wir verworfen haben?**
     (typische Halluzinationen → Gotchas)
   - **Welche Konvention musste mehrfach erklärt werden?**
     (fehlt oder unklar in `CONVENTIONS.md`)

4. Schreibe `retro-report.md`:

```markdown
# Pipeline-Retro: <Aufgabe / Ticket-ID>

**Datum:** <YYYY-MM-DD>
**Pipeline-Lauf:** Stufen <①…⑤ — was wurde wirklich durchlaufen>

## Was hat funktioniert
- <konkrete Beobachtung>
- ...

## Was hat NICHT funktioniert
- <konkrete Beobachtung mit Symptom>
- ...

## Gap-Analyse: was fehlt in ai_docs/
- **DOMAIN_KNOWLEDGE.md fehlt:** <Begriff / Regel> — Symptom: <wie hat sich
  das im Lauf gezeigt?>
- **GOTCHAS.md fehlt:** <KI-typische Fehlannahme> — Beispiel aus diesem Lauf:
  <konkrete Stelle>
- **CONVENTIONS.md unklar:** <Convention> — Symptom: <wie ist die KI
  abgewichen?>
- **ARCHITECTURE.md veraltet/fehlt:** <Komponente / Datenfluss>

## Quality-Check der Pipeline-Artefakte
- briefing.md hat ai_docs/-Inhalte sichtbar gezogen? <ja/nein/teilweise>
- plan.md war vom Code-Owner ohne Nachfragen review-fähig? <ja/nein>
- test-plan.md hatte domain-spezifische Edge Cases? <ja/nein>

## Pipeline-Stufen-Reibung
- Stufe ① zu viel/zu wenig Kontext? <Beobachtung>
- Stufe ② zu detailliert / zu vage? <Beobachtung>
- Stufe ③ Tests vs. Test-Code-Vermischung? <Beobachtung>
- Stufe ④ Diff-Größe / Plan-Disziplin? <Beobachtung>
- Stufe ⑤ MR-Body verständlich? <Beobachtung>
```

5. Erstelle **konkrete Patch-Vorschläge** als separate Datei `ai_docs-patches.md`:

```markdown
# Vorgeschlagene ai_docs/ Updates

> Mensch entscheidet pro Patch: übernehmen / ablehnen / anpassen.
> Erst nach Mensch-Review per `git apply` o.ä. einarbeiten.

## Patch 1 — DOMAIN_KNOWLEDGE.md
**Stelle:** Glossar
**Hinzufügen:**
- **<Begriff>:** <1-Satz-Definition aus diesem Pipeline-Lauf>

**Begründung:** Im Briefing fehlte dieser Begriff, KI hat ihn als „<falsche Annahme>"
interpretiert.

---

## Patch 2 — GOTCHAS.md
**Stelle:** Common Pitfalls

**Hinzufügen:**
\`\`\`
### Issue: <Beschreibung>
**Was die KI vorschlug:** <konkret>
**Korrekt:** <konkret>
**Grund:** <warum>
**Beispiel:** <Code-Snippet, optional>
\`\`\`

**Begründung:** Trat in diesem Lauf auf — siehe Stelle X im Diff.

---

## Patch 3 — CONVENTIONS.md
**Stelle:** <Section>
**Klarstellen:** ...

---

## Nicht patchen (bewusst)
- <Beobachtung, die ein Einzelfall war und keine Convention rechtfertigt>
```

## Was du NICHT tust

- **KEIN `git commit`, kein `git push`, kein direktes Editieren** von
  `ai_docs/`-Dateien. Du schlägst Patches vor — der Mensch wendet an.
- **Keine Tags / Releases / Branch-Operationen.** Das ist eine Lern-Stufe, kein
  Deployment.
- **Keine generischen Best-Practices** („nutzt SOLID!"). Patches müssen aus diesem
  konkreten Lauf abgeleitet sein, sonst sind sie nicht legitimiert.
- **Kein Lobgesang.** „Funktioniert super!" ist als Retro-Output wertlos. Wenn
  alles gut lief, schreib *warum* — das ist auch wertvoll für ai_docs.
- **Nicht das ganze Pipeline-Konzept hinterfragen.** Hier geht es um Patches an
  `ai_docs/`, nicht um „sollten wir die Pipeline anders bauen".

## Mensch-Gate (das ist der wichtigste Teil)

1. Team liest `retro-report.md` zusammen — 5 min.
2. Team geht `ai_docs-patches.md` Patch für Patch durch:
   - **Übernehmen:** trifft, geht in ai_docs/.
   - **Anpassen:** Idee ok, Wording überarbeiten.
   - **Ablehnen:** Einzelfall, kein Pattern.
3. Mensch wendet die übernommenen Patches an (Editor / `git apply`) und commitet
   den `ai_docs/`-Update **separat** vom Aufgaben-Commit aus Stufe ⑤. Das macht
   das Wachstum von `ai_docs/` in der Git-Historie sichtbar.

## Dauer-Empfehlung

- 5 min: Reflexion sammeln (Team beantwortet die 3 Fragen)
- 5 min: `/retro` läuft, schreibt Report + Patches
- 10 min: Team reviewt Patches, nimmt 2–3 davon, committet `ai_docs/`-Update

Das ist die Schleife, die euer `ai_docs/` mit jedem Pipeline-Lauf besser macht.
Ohne diese Schleife stagniert es.

## Argument

`$ARGUMENTS` (optional): Hinweis auf den Pipeline-Lauf (z. B. „Ticket-1234"),
falls mehrere Aufgaben parallel durch die Pipeline gegangen sind.
