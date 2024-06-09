# Projektplanung

## Must-haves
- [ ] Artikel hinzufügen  (Artikelnummer, Artikelname, Bild)
- [ ] Produktauswahl window
- [ ] Warenkorb(Bestell) window
- [ ] Serialisierung(Produktdaten und Rechnung(Bestellung))
- [ ] grafik



## Nice-to-haves
- [ ] mit Datenbank (sqlite)
- [ ] Rechnung  als PDF erzeugen.
- [ ] Bestellhistorie 
- [ ] ...

---

## Umsetzung
Die Umsetzung erfolgt in folgenden Schritten:
1. Analyse der Anforderungen
2. Entwurf der Architektur
3. Implementierung der Kernfunktionalitäten
4. Testen und Debuggen sowie Demoversion  erstellen
5. Implementierung von Nice-to-have-Funktionen
6. Endgültige Tests und Fehlerbehebung

## Klassen:
    - `Artikel` : Name, Bild und Preis für das Mainwindow (Auswahlseite).
    - `Atikellist`: Liste der hinzugefügten Artikel die in den Warenkorb  gehen können.
    - `Rechnung`: enthält eine Liste aller Artikel die Bestellt werden Möchten inkl. Menge und Preis pro Einheit sowie Gesamtpreis.
## Windows:
    - `MainWindow`: Startfenster mit den Produkten die zur Auswahl stehen;
    - `Warenkorb window`: Alle Produkte mit Preis werden dort angezeigt und man kann dann da seine Bankdaten eingeben;
    - `Kaufbestätigung`: Bestellbestätigung mit Bestellnummer und Button zum download der Rechnung;
    

## Wer macht was?
- **Maximilian:** Liste: Rechnung.
- **Valentin:** Liste: Artikel und Artikelliste.
- **Valentin:** Mainwindow (Produktauswahl).
- **Maximilian:** Warenkorb mit Bestellfunktion, Bestellbestätigung. 
- **Maximilian:** Datenbank,Statistik, Logging.

## Milestoneso
- **Milestone 1 (11.Mai):** MainWindow und Bestellwindow  fertig, Basisfunktinalität implementiert.(Demoversion)
- **Milestone 2 (25. Mai):** Bestellbestätigung und Rechnung und Datenbankenkommunikation.
- **Milestone 3 (1. Juni):** Logging und Testen der Endversion und  Bugfixing.
- **Projektabschluss (5.Juni):** Projekt abgeschlossen und an Lehrer übergeben