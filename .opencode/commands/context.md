---
description: "Block 6 — Pipeline-Stufe ①: Context-Gather. Erzeugt briefing.md aus Aufgabenbeschreibung + Code + ai_docs/."
---

# /context — Scaffolding-Pipeline Stufe ① (Context Gather)

Du bist in **Block 6**, Stufe 1 von 5. Aufgabe dieser Stufe: alles Wissen über die
anstehende Aufgabe in einem **einzigen Briefing-Dokument** bündeln. Kein Code,
kein Plan — nur Kontext.

## Auftrag

Sammle den Kontext für die Aufgabe `$ARGUMENTS`:

1. Lies das Ticket aus Jira/Backlog (falls per MCP / `aidev jira` verfügbar) oder
   nimm die freie Aufgabenbeschreibung aus dem Argument.
2. Identifiziere **relevante Code-Pfade** — welche Klassen, welche Tests, welche
   Konfig-Dateien sind betroffen?
3. Lies `ai_docs/ARCHITECTURE.md` und `ai_docs/DOMAIN_KNOWLEDGE.md` — übernimm
   nur, was für **diese** Aufgabe relevant ist (nicht alles).
4. Lies `ai_docs/CONVENTIONS.md` und `ai_docs/GOTCHAS.md` — wieder nur das, was
   diese Aufgabe betrifft.
5. Schreibe `briefing.md` mit folgenden Sections:

```markdown
# Briefing: <Ticket-ID / Kurztitel>

## Aufgabe
[Was soll getan werden, in 3–5 Sätzen — fachlich, nicht technisch]

## Akzeptanzkriterien
- [ ] [Was muss am Ende beobachtbar funktionieren]
- [ ] ...

## Relevanter Code
- src/Foo/Bar.cs:42 — die zentrale Klasse
- src/Common/Utils.cs — wird mitgeändert
- (NICHT ANFASSEN: src/Legacy/* — deprecated)

## Domain-Kontext (aus ai_docs/)
- "<Begriff>" bedeutet ... (Quelle: DOMAIN_KNOWLEDGE.md)
- Business-Regel X gilt
- ...

## Codierichtlinien (relevant für diese Aufgabe)
- Test-Framework: ...
- Naming-Konvention: ...
- Async-Regel: ...

## Bekannte Gotchas (aus ai_docs/GOTCHAS.md)
- ...
```

## Was du NICHT tust

- **Nicht implementieren.** Nicht eine Zeile Code anfassen.
- **Keinen Plan schreiben.** Plan ist Stufe ②, das macht `/plan`.
- **Nicht alles aus ai_docs reinkopieren.** Nur, was für diese Aufgabe relevant ist —
  sonst wird das Briefing für die KI Lärm.
- **Keine Empfehlungen, keine Lösungsvorschläge.** Briefing ist Input, nicht Output.

## Mensch-Gate (≈2 Minuten)

Code-Owner liest `briefing.md` und beantwortet:
- Hat die KI verstanden, worum es geht?
- Fehlt was Wichtiges? (vor allem: Constraints, die nicht aus dem Code lesbar sind)
- Ist was drin, das **nicht** zur Aufgabe gehört? (Briefing-Bloat ist Pipeline-Gift)

Wenn ja → `/plan` als nächstes.
